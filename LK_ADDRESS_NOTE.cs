// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ISB.CLWater.Data.Entities;

public partial class LK_ADDRESS_NOTE
{
    [Key]
    public int ADDRESS_NOTES_ID { get; set; }

    [StringLength(50)]
    public string NOTES_DESC { get; set; } = null!;

    [InverseProperty("address_note")]
    public virtual ICollection<TBL_PERSON> TBL_PERSON { get; set; } = new List<TBL_PERSON>();
}