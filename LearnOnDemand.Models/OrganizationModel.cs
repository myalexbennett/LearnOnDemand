using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LearnOnDemand.Models
{
    public class OrganizationModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Address { get; set; }
        [Required]
        [StringLength(255)]
        public string City { get; set; }

        [Required]
        [StringLength(2, ErrorMessage = "2 Characters Required", MinimumLength = 2)]
        public string State { get; set; }
        [Required]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zipcode")]
        public string Zip { get; set; }

        public List<UserModel> Users { get; set; }
    }
}
