using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace BussinessObject
{
    public class Cart
    {
        private int _Id { get; set; }
        private int _UserId;
        private int _ProductId;
        private int _Quantity;
        private Decimal _Price;
        private DateTime _DateCreated;


        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }
        public int UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
            }
        }
        
        public int ProductId
        {
            get
            {
                return _ProductId;
            }
            set
            {
                _ProductId = value;
            }
        }
        public int Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                _Quantity = value;
            }
        }
        public Decimal Price
        {
            get
            {
                return _Price;
            }
            set
            {
                _Price = value;
            }
        }
        public DateTime DateCreated
        {
            get
            {
                return _DateCreated;
            }
            set
            {
                _DateCreated = value;
            }
        }
    }
}