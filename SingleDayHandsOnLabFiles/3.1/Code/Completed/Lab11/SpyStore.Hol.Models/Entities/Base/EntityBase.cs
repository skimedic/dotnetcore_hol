// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Models - EntityBase.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/03/07
// See License.txt for more information
// ==================================

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpyStore.Hol.Models.Entities.Base
{
    public abstract class EntityBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Timestamp] public byte[] TimeStamp { get; set; }
    }
}