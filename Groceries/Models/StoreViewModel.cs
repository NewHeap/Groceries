using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceriesTool.Models
{
    public class StoreViewModel
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the name of the store.")]
        [Display(Name = "*Store")]
        [DataType(DataType.Text)]
        public string StoreName { get; set; }

        [Required(ErrorMessage = "Please enter the location of the store.")]
        [Display(Name = "*Location")]
        [DataType(DataType.Text)]
        public string StoreLocation { get; set; }

        [Required(ErrorMessage = "Please enter the openings houres.")]
        [Display(Name = "*Openinghours")]
        [DataType(DataType.Time)]
        public string Openinghours { get; set; }

        [Required(ErrorMessage = "Please enter the closinghours.")]
        [Display(Name = "*closinghours")]
        [DataType(DataType.Time)]
        public string Closinghours { get; set; }
    }
}
