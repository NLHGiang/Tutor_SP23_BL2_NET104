using Tutor_SP23_BL2_NET104.Models.Base;
using System;
using System.Collections.Generic;

namespace Tutor_SP23_BL2_NET104.Models
{
    public partial class Bill : EntityBase
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ProductBill> ProductBills { get; set; }
    }
}
