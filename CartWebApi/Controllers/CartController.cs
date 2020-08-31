using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BussinessLogic;
using BussinessObject;

namespace CartWebApi.Controllers
{
    public class CartController : ApiController
    {
        // GET: api/Cart
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Cart/2 Read 
        public Cart Get(int id)
        {
            CartLogic cl = new CartLogic();
            return cl.GetCart(id);
        }

        // POST: api/Cart Create 
        public void Post([FromBody] Cart newCart)
        {
            var cl = new CartLogic();
            cl.InsertCart(newCart);
        }

        // PUT: api/Cart/2 update
        public void Put(int id, [FromBody] Cart updateCart)
        {
            var cl = new CartLogic();
            updateCart.Id = id;
            cl.UpdateCart(updateCart);
        }

        // DELETE: api/Cart/2 Delete 
        public void Delete(int id)
        {
            CartLogic cl = new CartLogic();
            cl.DeleteCart(id);
        }
    }
}
