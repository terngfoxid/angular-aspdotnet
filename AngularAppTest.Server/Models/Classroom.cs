using System;
using System.Collections.Generic;

namespace AngularAppTest.Server.Models;

public partial class Classroom
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public bool? IsDelete { get; set; }

    public int? CreateBy { get; set; }

    public int? UpdateBy { get; set; }

    public int? SchoolId { get; set; }

    public virtual School? School { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
