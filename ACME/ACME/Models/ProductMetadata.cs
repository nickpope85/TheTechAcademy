using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACME.Models
{
    [MetadataType(typeof(Product.Metadata))]
    public partial class Product //<-- Two partial classes can have the same name
    {
        sealed class Metadata
        {
            [Key]
            public System.Guid ProductId { get; set; }

            [Required]
            [Display(Name = "Product Name")]
            [StringLength(10)]
            public string Name { get; set; }

            [Required]
            //[Range(0.01, 1000.0)]
            [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
            public decimal Price { get; set; }
        }
    }
}