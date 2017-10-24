using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Autofac.Integration.WebApi;
using ShopAssist2.Business.Interfaces;
using ShopAssist2.Common.DataTransferObjects;

namespace ShopAssisst.Controllers {
    [RoutePrefix( "users" )]
    [AutofacControllerConfiguration]
    public class UsersController :ApiController {
        private readonly IUserService _userService;

        public UsersController( IUserService userService ) {
            _userService = userService;
        }

        [Route( "p" ), HttpPost]
        public HttpResponseMessage PostUser( UserDto user ) {
            try {
                _userService.AddUser( user );
                return Request.CreateResponse( HttpStatusCode.OK );
            }
            catch( Exception ex ) {
                return Request.CreateResponse( HttpStatusCode.InternalServerError, ex.Message );
            }
        }
    }
}
