using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AngularAppTest.Server.Models
{
    public class SchoolMetadata
    {
    }

    public partial class School
    {
        public void Create(DbContext db)
        {
            this.UpdateDate = DateTime.Now;
            this.CreateDate = this.UpdateDate;
            this.IsDelete = false;
            this.CreateBy = 0;
            this.UpdateBy = 0;
            db.Add(this);
        }

        public void Update(DbContext db,School buffer) {
            this.CreateBy = buffer.CreateBy;
            this.CreateDate = buffer.CreateDate;
            this.IsDelete = buffer.IsDelete;

            this.UpdateDate = DateTime.Now;
            this.CreateBy = 0;
            this.UpdateBy = 0;

            db.Update(this);
        }

        public void Delete(DbContext db) {
            this.IsDelete = true;
            db.Update(this);
        }

        /**/
        public void TrueDelete(DbContext db)
        {
            db.Remove(this);
        }
    }
}
