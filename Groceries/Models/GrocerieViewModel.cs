using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace GroceriesTool.Models
{
    public class GrocerieViewModel
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the Productname.")]
        [Display(Name = "*Product")]
        [DataType(DataType.Text)]
        public string Product { get; set; }


        [Display(Name = "Code")]
        [MaxLength(4)]
        [MinLength(4)]
        [DataType(DataType.Text)]
        public string Code { get; set; }

        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public string Price { get; set; }


        [Required(ErrorMessage = "Please enter the how menny we have.")]
        [Display(Name = "*Stock")]
        [DataType(DataType.Text)]
        public string Stock { get; set; }


        [Required(ErrorMessage = "Whare is the store locaded.")]
        [Display(Name = "*Storelocation")]
        [DataType(DataType.Text)]
        public string BuyLocation { get; set; }

        [Required(ErrorMessage = "Please enter the name of the store.")]
        [Display(Name = "*Store name")]
        [DataType(DataType.Text)]
        public string StoreName { get; set; }
    }
}
