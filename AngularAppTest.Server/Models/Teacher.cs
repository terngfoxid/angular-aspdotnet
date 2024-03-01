using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AngularAppTest.Server.Models;

[Table("Teacher")]
public partial class Teacher
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? FirstName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LastName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreateDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public bool? IsDelete { get; set; }

    public int? CreateBy { get; set; }

    public int? UpdateBy { get; set; }

    [Column("SchoolID")]
    public int? SchoolId { get; set; }

    [Column("ClassroomID")]
    public int? ClassroomId { get; set; }

    [ForeignKey("ClassroomId")]
    [InverseProperty("Teachers")]
    public virtual Classroom? Classroom { get; set; }

    [ForeignKey("SchoolId")]
    [InverseProperty("Teachers")]
    public virtual School? School { get; set; }
}
