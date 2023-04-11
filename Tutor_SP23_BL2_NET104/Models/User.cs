using Tutor_SP23_BL2_NET104.Models.Base;
using System;
using System.Collections.Generic;

namespace Tutor_SP23_BL2_NET104.Models
{
    public partial class User : EntityBase
    {
        public Guid Id { get; set; }
        public Guid IdRole { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<CartDetails> CartDetails { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
