using System.ComponentModel.DataAnnotations;
using SpyStore.Hol.Models.ViewModels;

namespace SpyStore.Hol.Mvc.Models.ViewModels
{
    public class CartRecordViewModel : CartRecordWithProductInfo
    {
        [Required]
        public new int Quantity { get; set; }
    }
}
