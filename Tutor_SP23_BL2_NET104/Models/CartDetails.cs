using Tutor_SP23_BL2_NET104.Models.Base;
using System;
using System.Collections.Generic;

namespace Tutor_SP23_BL2_NET104.Models
{
    public partial class CartDetails : EntityBase
    {
        public Guid IdUser { get; set; }
        public Guid IdProduct { get; set; }
        public int Amount { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
