using System.Collections.Generic;
using ShopAssist2.Common.DataTransferObjects;
using ShopAssist2.Common.Entities;

namespace ShopAssist2.Business.Interfaces
{
    public interface ITransactionService
    {
        IEnumerable<Transaction> GetAll();

        TransactionDto GetByTransactionId(int transactionId);

        void RecordTransaction(TransactionDto transaction);
    }
}