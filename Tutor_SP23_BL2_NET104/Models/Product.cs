using Tutor_SP23_BL2_NET104.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Tutor_SP23_BL2_NET104.Models
{
    public partial class Product : EntityBase
    {
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage ="Không được để trống trường này")]
        public Guid IdCategory { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Không được để trống trường này")]
        //[MaxLength(50, ErrorMessage = "Tên chỉ chứa tối đa 50 kí tự")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Không được để trống trường này")]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Không được để trống trường này")]
        [Range(2, Double.MaxValue, ErrorMessage = "Giá niêm yết phải lớn hơn 1")]
        public double? Price { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Không được để trống trường này")]
        [Range(2, Double.MaxValue, ErrorMessage = "Giá bán phải lớn hơn 1")]
        public double? ReducedPrice { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Không được để trống trường này")]
        [Range(2, Int32.MaxValue, ErrorMessage = "Số lượng tồn phải lớn hơn 1")]
        public int? Amount { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Không được để trống trường này")]
        public string Image { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<CartDetails>? CartDetails { get; set; }
        public virtual ICollection<ProductBill>? ProductBills { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            var property = new[] { "ReducedPrice" };
            double b = (double)ReducedPrice;

            if (ReducedPrice >= Price)
            {
                yield return new ValidationResult("Giá bán <= giá niêm yết", property);
            }
        }
    }
}
