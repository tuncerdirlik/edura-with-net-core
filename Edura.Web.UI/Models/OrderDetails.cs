using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.Web.UI.Models
{
    public class OrderDetails
    {
        [Required(ErrorMessage = "Adres tanımı giriniz")]
        public string AdresTanimi { get; set; }

        [Required(ErrorMessage = "Adres giriniz")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Şehir giriniz")]
        public string Sehir { get; set; }

        [Required(ErrorMessage = "Semt giriniz")]
        public string Semt { get; set; }

        [Required(ErrorMessage = "Telefon giriniz")]
        public string Telefon { get; set; }
    }
}
