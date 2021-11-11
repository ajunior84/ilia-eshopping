using System;
using System.Collections.Generic;
using System.Text;

namespace IliaEShopping.Domain.ObjectValues
{
    public enum OrderStatusType
    {
        Created = 1,
        Approved,
        Repproved,
        Canceled,
        Shipped,
        Delivered,
        Finished
    }
}
