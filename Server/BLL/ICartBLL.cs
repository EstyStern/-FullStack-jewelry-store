using System;
using System.Collections.Generic;
using System.Text;
using Entities_DTO;

namespace BLL
{
    public interface ICartBLL
    {
        List<bool> AddCart(short id,List<CartDTO> c);
    }
}
