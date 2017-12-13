using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Microsoft.Web.Http;
using ShopAssist2.Business.Services;
using ShopAssist2.Common.DataTransferObjects;

namespace ShopAssisst.Controllers {
    [ApiVersion("1.0"), RoutePrefix("api/v{version}/items")]
    public class ItemsController : ApiController {
        private readonly ItemService _itemService;

        public ItemsController(ItemService itemService) {
            _itemService = itemService;

        }
        [HttpGet, Route("g")]
        public IHttpActionResult GetAll() {
            try {
                var allItems = _itemService.GetAll();
                if(allItems == null) {
                    return Content(HttpStatusCode.NotFound, "No items found");
                }
                return Ok(allItems);

            } catch(Exception e) {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }

        }
        [HttpGet, Route("g/names")]
        public IHttpActionResult GetAllNames() {
            try {
                var allItems = _itemService.GetAll().ToList();
                if(allItems.Count == 0) {
                    return Content(HttpStatusCode.NotFound, "No items found");
                }

                var itemNames = new string[allItems.Count()];
                var items = allItems.ToArray();

                for(var i = 0; i <= itemNames.Length - 1; i++) {
                    itemNames[i] = items[i].ItemName;

                }
                return Ok(itemNames);

            } catch(Exception e) {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpPost, Route("p")]
        public IHttpActionResult PostItems(ICollection<ItemDto> items) {
            try {
                if(items == null) {
                    return Content(HttpStatusCode.BadRequest, "Cannot post null");
                }
                _itemService.AddItems(items);
                return Ok();
            } catch(Exception e) {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut, Route("u")]
        public IHttpActionResult UpdateItems(ICollection<ItemDto> updatedItems) {
            try {
                if(updatedItems.Count <= 0) {
                    return Content(HttpStatusCode.Accepted, "Zero records updated though");
                }
                _itemService.UpdateItems(updatedItems);
                return Ok();
            } catch(Exception e) {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete, Route("d")]
        public IHttpActionResult DeleteItems(ICollection<int> itemsToDelete) {
            try {
                if(itemsToDelete.Count <= 0) {
                    return Content(HttpStatusCode.Accepted, "Zero records deleted though");
                }
                var newItems = _itemService.DeleteItems(itemsToDelete);
                return Ok(newItems);
            } catch(Exception e) {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}