using System;
using System.Collections.Generic;
using DAL;
using System.Linq;
using DAL.Models;

namespace DAL
{
    public class Customers_DAL : ICustomers_DAL
    {
        //DB-מופע מסוג ה
        Jewelry_dbContext _db;

        //constarctor
        //מנהל התלויות יזריק מסד נתונים
        public Customers_DAL(Jewelry_dbContext _mydb)
        {
            _db = _mydb;
        }

        //הוספת לקוח חדש
        public string AddCustomer(CustomersTbl c)
        {
            try
            {
                _db.CustomersTbls.Add(c);
                _db.SaveChanges();
                return "Succeeded!";
            }
            catch
            {
                return "Fails!";
            }

        }

        //בדיקה האם לקוח קיים לפי שם וסיסמה
        public CustomersTbl GetCustomerByNameAndPassword(string Name, int Password)
        {
            return _db.CustomersTbls.FirstOrDefault(p => p.CustomerName == Name && p.CustomerPassword == Password);

        }

        //קבלת רשימת לקוחות
        public List<CustomersTbl> getAllCustomer()
        {
            return _db.CustomersTbls.ToList();
        }

       

        //מחיקת לקוח
        public CustomersTbl RemoveCustomerById(short id)
        {
            var CustomerToRemove = _db.CustomersTbls.FirstOrDefault(p => p.CustomerId == id);
            _db.CustomersTbls.Remove(CustomerToRemove);
            _db.SaveChanges();
            return CustomerToRemove;
        }

        //עדכון פרטי לקוח
        public List<CustomersTbl> UpdateCustomer(CustomersTbl c)
        {
            var CustomerToEdit = _db.CustomersTbls.FirstOrDefault(p => p.CustomerId == c.CustomerId);
            if (CustomerToEdit != null)
            {
                CustomerToEdit.CustomerId = c.CustomerId;
                CustomerToEdit.CustomerName = c.CustomerName;
                CustomerToEdit.CustomerPassword = c.CustomerPassword;
                CustomerToEdit.CreditNumber = c.CreditNumber;

                _db.SaveChanges();
                return _db.CustomersTbls.ToList();
            }
            return null;
        }
    }
}
