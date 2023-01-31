using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.DataModels.CustomModels
{
    public class ShippingModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*Shipping Status is required")]
        public string Name { get; set; }
    }
}
