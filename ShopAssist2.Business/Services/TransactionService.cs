using ShopAssist2.Common.DataTransferObjects;
using ShopAssist2.Common.Persistence;

namespace ShopAssist2.Business.Services
{
    public class TransactionService /*:ITransactionService*/
    {
        private readonly ShopAssist2Context _ctx;

        public TransactionService(ShopAssist2Context ctx)
        {
            _ctx = ctx;
        }
        //public IEnumerable<Transaction> GetAll() {
        //    return _ctx.
        //}

        //public TransactionDto GetByTransactionId( int transactionId ) {

        //}

        public void RecordTransaction(TransactionDto transaction)
        {
        }
    }
}