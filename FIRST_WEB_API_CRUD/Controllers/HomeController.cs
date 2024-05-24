using FIRST_WEB_API_CRUD.Data;
using FIRST_WEB_API_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIRST_WEB_API_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public StudentDbContext studentdb { get; set; }
        public HomeController(StudentDbContext studentDb)
        {
            studentdb = studentDb;  
        }


        //THIS METHOD I WILL CREATED FOR GET ALL STUDENT DATA
        [Route("GetStudent")]
        [HttpGet]
        public async Task<IActionResult> GetStudent()
        {
            var student_data = await studentdb.STUDENT.ToListAsync();
            return Ok(student_data);    
        }

        //THIS NETHOD I WILL CREATED FOR GET A SINGLE STUDENT DATA
        [Route("GetAParticularStudent")]
        [HttpGet]
        public async Task<IActionResult> GetAParticularStudent(int Id)
        {
            var student_par_data = await studentdb.STUDENT.Where(a => a.ID == Id).FirstOrDefaultAsync();
            return Ok(student_par_data);
        }

        //THIS METHOD I WILL CREATED FOR INSERT A STUDENT DATA
        [Route("CreateAStudent")]
        [HttpPost]
        public async Task<IActionResult> CreateStudent(STUDENT student)
        {
            if(student != null)
            {
                if(student.ID == 0)
                {
                    await studentdb.STUDENT.AddAsync(student);
                    await studentdb.SaveChangesAsync();
                    return Ok("Student created successfully !!!");
                }
                else
                {
                    var existing_student_data = await studentdb.STUDENT.Where(s => s.ID == student.ID).FirstOrDefaultAsync();
                    existing_student_data.NAME = student.NAME;
                    existing_student_data.AGE = student.AGE;
                    existing_student_data.ADDRESS = student.ADDRESS;
                    await studentdb.SaveChangesAsync();
                    return Ok("Student updated successfully !!!");
                }

            }
            else
            {
                return NotFound("Please provide student data !!!");
            }
        }

        //THIS METHOD I WILL CREATED FOR DELETE A STUDENT USING IT'S ID
        [Route("DeleteStudent")]
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int Id)
        {
            if(Id != 0)
            {
                var existing_student_data = await studentdb.STUDENT.Where(s => s.ID == Id).FirstOrDefaultAsync();
                studentdb.STUDENT.Remove(existing_student_data);
                await studentdb.SaveChangesAsync();
                return Ok("Student deleted successfully !!!");
            }
            else
            {
                return NotFound("Please provide student id !!!");
            }
        }
    }
}
