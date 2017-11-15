using System;
using System.Collections.Generic;
using AutoMapper;
using ShopAssist2.Common.DataTransferObjects;
using ShopAssist2.Common.Entities;
using ShopAssist2.Common.Persistence;
using System.Linq;
using ShopAssist2.Business.Interfaces;
using ShopAssist2.Common.Enums;

namespace ShopAssist2.Business.Services {
    public class TransactionService : ITransactionService {
        private readonly ShopAssist2Context _ctx;
        private readonly IMapper _mapper;

        public TransactionService(ShopAssist2Context ctx, IMapper mapper) {
            _ctx = ctx;
            _mapper = mapper;
        }
        public IEnumerable<TransactionDto> GetAll(bool includeItems) {
            if(!includeItems)
                return _ctx.Transactions.ToList().Select(t => _mapper.Map<TransactionDto>(t));

            var transacs = _ctx.Transactions.ToList();
            var transacDtos = transacs.Select(t => _mapper.Map<TransactionDto>(t)).ToList();

            // TO-DO: linqify this:
            for(var i = 0; i <= transacDtos.Count - 1; i++) {
                var items = new List<ItemDto>();
                if(transacDtos[i].TransactionId != transacs[i].TransactionId) continue;
                items.AddRange(transacs[i].TransactionItems.Select(transactionItem => _mapper.Map<ItemDto>(transactionItem.Item)));
                transacDtos[i].Items = items;
            }
            return transacDtos;
        }
        public TransactionDto GetByTransactionId(int transactionId) {
            var transac = _ctx.Transactions.Find(transactionId);
            return transac == null ? null : _mapper.Map<TransactionDto>(transac);

        }

        public List<TransactionStatistics> GetStats(DateTime date) {
            var transacStatsList = new List<TransactionStatistics>();
            var transacs = _ctx.Transactions.Where(t => t.Date.Year == date.Year).ToList();

            //List<IEnumerable<Transaction>> queryList = new List<IEnumerable<Transaction>>();


            for(var i = 1; i <= 12; i++) {
                var monthlyTransacStats = new TransactionStatistics {
                    Month = i - 1
                };
                var i1 = i;
                var transacsThisMonth = transacs.Where(t => t.Date.Month == i1);
                foreach(var transactionOfMonth in transacsThisMonth) {
                    var transaclyStats = new TransactionStatistics();
                    foreach(var transactionItem in transactionOfMonth.TransactionItems) {
                        var transacItemlyStats = new TransactionStatistics();
                        switch(transactionOfMonth.TransactionType) {
                            case TransactionType.Sale:
                                transacItemlyStats.Sales += transactionItem.Amount;
                                transacItemlyStats.Purchases += transactionItem.Item.PurchaseCost * transactionItem.Quantity;
                                break;
                            case TransactionType.Purchase:
                                break;
                            default:
                                throw new Exception("Invalid TransactionType");
                        }
                        // for each transactionItem, add its stats to the containing transaction's stats
                        transaclyStats.Sales += transacItemlyStats.Sales;
                        transaclyStats.Purchases += transacItemlyStats.Purchases;
                    }
                    // for each transaction, add its stats to that month's transaction stats
                    monthlyTransacStats.Sales += transaclyStats.Sales;
                    monthlyTransacStats.Purchases += transaclyStats.Purchases;

                }
                // calculate profit for that month, and add that month's stats to list of monthly stats
                monthlyTransacStats.ProfitLoss = monthlyTransacStats.Sales - monthlyTransacStats.Purchases;
                transacStatsList.Add(monthlyTransacStats);

            }

            return transacStatsList;

        }
        public void RecordTransaction(TransactionDto transaction) {
            // get the transaction entity
            var transac = _mapper.Map<Transaction>(transaction);

            foreach(var item in transaction.Items) {
                var transactionItem = new TransactionItem { Transaction = transac };
                // attempt to look for item in db
                var itemToAdd = _ctx.StockItems.FirstOrDefault(i => i.ItemName == item.ItemName);
                // if it doesn't exist
                if(itemToAdd == null) {
                    var newItem = _mapper.Map<Item>(item);
                    switch(transaction.TransactionType) {
                        // if sale, set custom quantity
                        case 1:
                            newItem.Quantity = 0;
                            transactionItem.Item = newItem;
                            break;
                        // if purchase, add as is
                        case 0:
                            transactionItem.Item = newItem;
                            break;
                        default:
                            throw new KeyNotFoundException("invalid transaction type");
                    }

                    _ctx.TransactionItems.Add(transactionItem);

                    // if it does exist, update its quantity
                } else if(transaction.TransactionType == 1) {
                    // if sale, subtract quantity from items table,leave all others intact
                    // TO-DO: find a better way to do this, maybe a partial model that updates
                    // only the properties i want updated
                    itemToAdd.Quantity -= item.Quantity;
                    _ctx.Entry(itemToAdd).State = System.Data.Entity.EntityState.Modified;
                    _ctx.Entry(itemToAdd).Property(x => x.Unit).IsModified = false;
                    _ctx.Entry(itemToAdd).Property(x => x.SellingPrice).IsModified = false;
                    _ctx.Entry(itemToAdd).Property(x => x.PurchaseCost).IsModified = false;

                    transactionItem.Item = itemToAdd;

                    // update transasctionItem's other fields: quantity and amount
                    transactionItem.Quantity = item.Quantity;
                    transactionItem.Amount = item.Quantity * item.SellingPrice;

                    _ctx.TransactionItems.Add(transactionItem);

                } else {
                    // if purchase, add quantity, update purchase field, leave all others intact
                    itemToAdd.Quantity += item.Quantity;
                    itemToAdd.PurchaseCost += item.PurchaseCost;
                    _ctx.Entry(itemToAdd).State = System.Data.Entity.EntityState.Modified;
                    _ctx.Entry(itemToAdd).Property(x => x.Unit).IsModified = false;
                    _ctx.Entry(itemToAdd).Property(x => x.SellingPrice).IsModified = false;
                    _ctx.Entry(itemToAdd).Property(x => x.PurchaseCost).IsModified = false;

                    transactionItem.Item = itemToAdd;

                    // update transasctionItem's other fields: quantity and amount
                    transactionItem.Quantity = item.Quantity;
                    transactionItem.Amount = item.Quantity * item.PurchaseCost;

                    _ctx.TransactionItems.Add(transactionItem);
                }
            }

            _ctx.Transactions.Add(transac);
            _ctx.SaveChanges();
        }
    }
}
