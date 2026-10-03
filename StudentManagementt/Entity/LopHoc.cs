using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentManagementt.Entity
{
    public class LopHoc
    {
        [Required]
        [RegularExpression(@"^CSE[0-9]{4}$", ErrorMessage = "Mã lớp phải có định dạng: CSE followed by 4 digits.")]
        public string MaLop { get; set; }
        [Required]
        [Range(5, 30, ErrorMessage = "ten lop must be between 5 and 30 character!")]
        public string TenLop { get; set; }
        public List<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            // Custom validation logic for MaLop
            if (!string.IsNullOrEmpty(MaLop) && !System.Text.RegularExpressions.Regex.IsMatch(MaLop, @"^CSE[0-9]{4}$"))
            {
                results.Add(new ValidationResult("Mã lớp phải có định dạng: CSE followed by 4 digits.", new[] { nameof(MaLop) }));
            }
            // Custom validation logic for TenLop
            if (!string.IsNullOrEmpty(TenLop) && (TenLop.Length < 5 || TenLop.Length > 30))
            {
                results.Add(new ValidationResult("ten lop must be between 5 and 30 character!", new[] { nameof(TenLop) }));
            }
            return results;
        }
    }
}
