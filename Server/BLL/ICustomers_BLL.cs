using System;
using System.Collections.Generic;
using System.Text;
using Entities_DTO;

namespace BLL
{
    public interface ICustomers_BLL
    {
        //הוספת לקוח חדש
        string AddCustomer(Customers_DTO c);
        //בדיקה האם לקוח קיים לפי שם וסיסמה
        Customers_DTO GetCustomerByNameAndPassword(string Name, int Password);
       
    }
}
