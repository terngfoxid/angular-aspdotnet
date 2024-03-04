using System;
using System.Collections.Generic;

namespace AngularAppTest.Server.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public bool? IsDelete { get; set; }

    public int? CreateBy { get; set; }

    public int? UpdateBy { get; set; }

    public int? SchoolId { get; set; }

    public int? ClassroomId { get; set; }

    public virtual Classroom? Classroom { get; set; }

    public virtual School? School { get; set; }
}
