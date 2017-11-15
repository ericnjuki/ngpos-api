using System;
using System.Net;
using System.Web.Http;
using Microsoft.Web.Http;
using ShopAssist2.Business.Interfaces;
using ShopAssist2.Common.DataTransferObjects;

namespace ShopAssisst.Controllers {
    [ApiVersion("1.0"), RoutePrefix("api/v{version}/transacs")]
    public class TransactionsController : ApiController {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService) {
            _transactionService = transactionService;

        }
        [HttpGet, Route("g")]
        public IHttpActionResult GetAllTransactions(bool includeItems = false) {
            try {
                var transactions = _transactionService.GetAll(includeItems);
                if(transactions == null) {
                    return Content(HttpStatusCode.NoContent, "");

                }
                return Ok(transactions);
            } catch(Exception e) {
                return Content(HttpStatusCode.InternalServerError, e.Message);

            }

        }
        [HttpGet, Route("g/stats")]
        //public IHttpActionResult GetTransactionStats(DateTime date)
        public IHttpActionResult GetTransactionStats(string forYear) {
            try {
                var transactions = _transactionService.GetStats(new DateTime(int.Parse(forYear), DateTime.Today.Month, DateTime.Today.Day));
                if(transactions == null) {
                    return Content(HttpStatusCode.NoContent, "");

                }
                return Ok(transactions);
            } catch(Exception e) {
                return Content(HttpStatusCode.InternalServerError, e.Message);

            }

        }
        [HttpGet, Route("g/{id}")]
        public IHttpActionResult GetTransaction(int id) {
            try {
                var transaction = _transactionService.GetByTransactionId(id);
                if(transaction == null) {
                    return NotFound();
                }
                return Ok(transaction);
            } catch(Exception e) {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }

        }
        [HttpPost, Route("p")]
        public IHttpActionResult PostTransaction(TransactionDto transaction) {
            try {
                if(transaction == null) {
                    return Content(HttpStatusCode.BadRequest, "Cannot post null");
                }
                _transactionService.RecordTransaction(transaction);
                return Ok();
            } catch(Exception e) {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }

        }
    }
}
