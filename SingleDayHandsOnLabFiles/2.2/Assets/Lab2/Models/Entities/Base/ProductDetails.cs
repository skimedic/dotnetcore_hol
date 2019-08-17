using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SpyStore.Hol.Models.Entities.Base
{
  public class ProductDetails
  {
	public string Description { get; set; }
	public string ModelNumber { get; set; }
	public string ModelName { get; set; }
	public string ProductImage { get; set; }
	public string ProductImageLarge { get; set; }
	public string ProductImageThumb { get; set; }
  }
}