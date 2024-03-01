using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AngularAppTest.Server.Models;

[Table("School")]
public partial class School
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Unicode(false)]
    public string? Name { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreateDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public bool? IsDelete { get; set; }

    public int? CreateBy { get; set; }

    public int? UpdateBy { get; set; }

    [InverseProperty("School")]
    public virtual ICollection<Classroom> Classrooms { get; set; } = new List<Classroom>();

    [InverseProperty("School")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    [InverseProperty("School")]
    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
