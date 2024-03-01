using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AngularAppTest.Server.Models;

[Table("Classroom")]
public partial class Classroom
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Code { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreateDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public bool? IsDelete { get; set; }

    public int? CreateBy { get; set; }

    public int? UpdateBy { get; set; }

    [Column("SchoolID")]
    public int? SchoolId { get; set; }

    [ForeignKey("SchoolId")]
    [InverseProperty("Classrooms")]
    public virtual School? School { get; set; }

    [InverseProperty("Classroom")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    [InverseProperty("Classroom")]
    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
