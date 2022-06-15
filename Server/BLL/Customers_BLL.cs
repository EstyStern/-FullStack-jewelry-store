using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DAL;
using Entities_DTO;
using DAL.Models;

namespace BLL
{
    public class Customers_BLL : ICustomers_BLL
    {
        ICustomers_DAL _customer_DAL;
        IMapper _imapper;

        public Customers_BLL(ICustomers_DAL custDAL)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Auto>();

            });
            _imapper = config.CreateMapper();
            _customer_DAL = custDAL;
        }

        //הוספת לקוח חדש
        public string AddCustomer(Customers_DTO c)
        {
            CustomersTbl custMap = _imapper.Map<Customers_DTO, CustomersTbl>(c);
            try
            {
                _customer_DAL.AddCustomer(custMap);
                
                return "Succeeded!";
            }
            catch
            {
                return "Fails";
            }
        }

        //בדיקה האם לקוח קיים לפי שם וסיסמה
        public Customers_DTO GetCustomerByNameAndPassword(string Name, int Password)
        {
            //CustomersTbl custMap = _imapper.Map<Customers_DTO, CustomersTbl>(Name,Password);
            CustomersTbl c = _customer_DAL.GetCustomerByNameAndPassword(Name, Password);
            return _imapper.Map<CustomersTbl, Customers_DTO>(c);
        }





    }
}
