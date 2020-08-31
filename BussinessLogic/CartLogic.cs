using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject;
using DataAccess;

namespace BussinessLogic
{
    public class CartLogic
    {
        public Cart GetCart(int id)
        {
            DataManager cartDM = new DataManager();
            Cart cart = cartDM.GetCart(id);

            return cart;
        }

        public void InsertCart(Cart newCart)
        {
            DataManager cartDM = new DataManager();
            cartDM.InsertCart(newCart);
        }

        public void DeleteCart(int id)
        {
            DataManager cartDM = new DataManager();
            cartDM.DeleteCart(id);
        }

        public void UpdateCart(Cart updateCart)
        {
            DataManager cartDM = new DataManager();
            cartDM.UpdateCart(updateCart);
        }
    }
}
