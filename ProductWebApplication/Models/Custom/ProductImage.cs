using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ProductWebApplication.Models.Custom
{
    public class ProductImage
    {
        [Key]
        public int ProductImageId { get; set; }
        public string ImageName { get; set; }
    }
}
