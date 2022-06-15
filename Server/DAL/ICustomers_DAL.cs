using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Models;

namespace DAL
{
    public interface ICustomers_DAL
    {
        //הוספת לקוח חדש
        string AddCustomer(CustomersTbl c);
        //בדיקה האם לקוח קיים לפי שם וסיסמה
        CustomersTbl GetCustomerByNameAndPassword(string Name, int Password);

        //קבלת כל רשימת הלקוחות
        public List<CustomersTbl> getAllCustomer();
        //מחיקת לקוח
        public CustomersTbl RemoveCustomerById(short id);
        //עדכון פרטי לקוח
        public List<CustomersTbl> UpdateCustomer(CustomersTbl c);

    }
}
