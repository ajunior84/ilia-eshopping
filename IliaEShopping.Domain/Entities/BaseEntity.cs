﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IliaEShopping.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedAt { get; set; }
    }
}
