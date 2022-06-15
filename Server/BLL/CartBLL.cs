using System;
using System.Collections.Generic;
using System.Text;
using Entities_DTO;
using DAL;
using DAL.Models;

namespace BLL
{
    public class CartBLL : ICartBLL
    {
        IDetailsShoppingDAL _IDetailsShoppingDAL;
        IShoppingDAL _IShoppingDAL;
        IJewelry_DAL _IJewelry_DAL;

        public CartBLL(IDetailsShoppingDAL DetailsShoppingDAL, IShoppingDAL ShoppingDAL, IJewelry_DAL jewelryDAL)
        {
            _IDetailsShoppingDAL = DetailsShoppingDAL;
            _IShoppingDAL = ShoppingDAL;
            _IJewelry_DAL = jewelryDAL;

        }

        public List<bool> AddCart(short id, List<CartDTO> c)
        {
            List<bool> l = new List<bool>();
            try
            {
                double sum = 0;
                //double sum = 0;
                BuyTbl sp = new BuyTbl();
                foreach (var item in c)
                {
                    sum += item.totalPrice;
                }

                //sp.DateBuy = new DateTime();
                sp.CustomerId = id;
                sp.DateBuy = null;
                sp.AmountToPay = sum;

                _IShoppingDAL.AddShopping(sp);

                foreach (var item in c)
                {
                    if (Check(item.idJewelry, item.amount) == true)
                    {
                        l.Add(true);
                        BuyDetailsTbl s = new BuyDetailsTbl();

                        s.JewelryId = item.idJewelry;
                        s.Qty = item.amount;
                        s.IdBuy = sp.IdBuy;

                        _IDetailsShoppingDAL.AddDetailsShopping(s);
                    }
                    else { 
                    l.Add(false);
                    }
                }

                return l;
            }
            catch
            {
                return l;
            }
        }

        public bool Check(short id, int amount)
        {
            var jewelry = _IJewelry_DAL.getJewelryById(id);
            if (jewelry != null)
            {
                if (jewelry.UnitsInStock >= amount)
                {
                    jewelry.UnitsInStock = jewelry.UnitsInStock - amount;
                    _IJewelry_DAL.UpdateJewelry(jewelry);
                    return true;
                }
            }
                return false;
        }

       
    }
}
