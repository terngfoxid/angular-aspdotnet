using AngularAppTest.Server.Data;
using AngularAppTest.Server.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularAppTest.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CRUDController : ControllerBase
    {
        private EducationContext db = new EducationContext();

        [HttpGet(Name = "GetCRUD")]
        public ActionResult Get(int? ID)
        {
            Object json;
            if (ID == null)
            {
                json = new
                {
                    message = "ID can't be null"
                };
                return BadRequest(json);
            }
            try
            {
                School? school = db.Schools.Find(ID);
                if(school == null || school.IsDelete == true)
                {
                    json = new
                    {
                        message = "Not Found"
                    };
                    return NotFound();
                }

                json = new
                {
                    message = "Get Method Work",
                    school = school
                };
                return Ok(json);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost(Name = "PostCRUD")]
        public ActionResult Post(School school)
        {
            Object json;
            if (school.Name == null)
            {
                json = new
                {
                    message = "Name can't be null"
                };
                return BadRequest(json);
            }
            try
            {
                school.Create(db);
                db.SaveChanges();
                json = new
                {
                    message = "Post Method Work",
                    school = school
                };
                return Ok(json);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut(Name = "PutCRUD")]
        public ActionResult Put(School school)
        {
            School? schoolBuffer = db.Schools.Where(q => q.Id == school.Id).AsNoTracking().FirstOrDefault();
            Object json;

            if (schoolBuffer == null)
            {
                json = new
                {
                    message = "Not Found"
                };
                return NotFound(json);
            }
            
            if (school.Name == null)
            {
                json = new
                {
                    message = "Name can't be null"
                };
                return BadRequest(json);
            }else if(school.Name == schoolBuffer.Name)
            {
                json = new
                {
                    message = "Name is not get any change"
                };
                return BadRequest(json);
            }
            try
            {
                school.Update(db,schoolBuffer);
                db.SaveChanges();
                json = new
                {
                    message = "Post Method Work",
                    school = school
                };
                return Ok(json);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete(Name = "DeleteCRUD")]
        public ActionResult Delete(int? ID)
        {
            Object json;
            if (ID == null)
            {
                json = new
                {
                    message = "ID can't be null"
                };
                return BadRequest(json);
            }
            try
            {
                School? school = db.Schools.Find(ID);
                if (school == null)
                {
                    json = new
                    {
                        message = "Not Found"
                    };
                    return NotFound();
                }

                school.Delete(db);
                db.SaveChanges();

                json = new
                {
                    message = "Delete Method Work",
                    school = school
                };
                return Ok(json);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("test")]//<--- Subpath
        public ActionResult Test()
        {
            Object json = new
            {
                message = "test subpath working"
            };
            return Ok(json);
        }
    }
}
