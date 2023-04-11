using Tutor_SP23_BL2_NET104.Models.Base;
using System;
using System.Collections.Generic;

namespace Tutor_SP23_BL2_NET104.Models
{
    public partial class ProductBill : EntityBase
    {
        public Guid IdBill { get; set; }
        public Guid IdProduct { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public double ReducedPrice { get; set; }
        public virtual Product Product { get; set; }
        public virtual Bill Bill { get; set; }

    }
}
