#region copyright

// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Models - ShoppingCartRecordBase.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2019/10/04
// See License.txt for more information
// ==================================

#endregion

using System;
using System.ComponentModel.DataAnnotations;

namespace SpyStore.Hol.Models.Entities.Base
{
    public class ShoppingCartRecordBase : EntityBase
    {
        [DataType(DataType.Date), Display(Name = "Date Created")]
        public DateTime? DateCreated { get; set; }

        [Required] public int CustomerId { get; set; }
        [Required] public int Quantity { get; set; }

        [DataType(DataType.Currency), Display(Name = "Line Total")]
        public decimal LineItemTotal { get; set; }

        [Required] public int ProductId { get; set; }
    }
}