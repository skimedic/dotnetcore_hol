using SpyStore_HOL.MVC.ViewModels.Base;

namespace SpyStore_HOL.MVC.ViewModels
{
    public class AddToCartViewModel : CartViewModelBase
    {
        public int Quantity { get; set; }
    }
}