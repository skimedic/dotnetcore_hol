using System.ComponentModel.DataAnnotations;
using SpyStore.Hol.Models.Entities.Base;

namespace SpyStore.Hol.Models.ViewModels
{
	public class CartRecordWithProductInfo : ShoppingCartRecordBase
	{
	    public new int Id { get; set; }
	    public string Description { get; set; }
	    public string ModelNumber { get; set; }
	    public string ModelName { get; set; }
	    public string ProductImage { get; set; }
	    public string ProductImageLarge { get; set; }
	    public string ProductImageThumb { get; set; }
	    public int UnitsInStock { get; set; }
	    public decimal CurrentPrice { get; set; }
	    public int CategoryId { get; set; }
	    public string CategoryName { get; set; }
	}
	}
