// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ISB.CLWater.Data.Entities;

[Index("STATE_DESC", Name = "IX_LK_STATE")]
public partial class LK_STATE
{
    [Key]
    public int STATE_ID { get; set; }

    [StringLength(75)]
    [Unicode(false)]
    public string STATE_NAME_LONG { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string STATE_DESC { get; set; } = null!;

    public bool IS_ACTIVE { get; set; }

    public int CREATED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CREATED_DATE { get; set; }

    public int EDITED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EDITED_DATE { get; set; }

    [InverseProperty("STATE")]
    public virtual ICollection<TBL_ADDRESS> TBL_ADDRESS { get; set; } = new List<TBL_ADDRESS>();
}