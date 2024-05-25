using ASPCRUD.Model;
using ASPCRUD.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ASPCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly CRUDContext _context;
        public HomeController(CRUDContext context)
        {
            _context = context;
        }
        [HttpGet("getstudent/{pageno}/{pagesize}")]
        public async Task<ActionResult<ListResponse<Student>>> Get(int pageno, int pagesize)
        {
            ListResponse<Student> response = new ListResponse<Student>();

            response.Count= await _context.students.CountAsync();
            if (response.Count > 0)
                response.Model = await _context.students.Skip((pageno - 1) * pagesize).Take(pagesize).ToListAsync();
            else
                response.Message = "No record found";
            response.PageNo = pageno;
            response.PageSize = pagesize;   
            return Ok(response);
        }
        [HttpPost("addstudent")]
        public async Task<ActionResult<ReponseBase>> Add(Student student)
        {
            ReponseBase reponse = new ReponseBase();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); ;
            }
            _context.students.Add(student);
            reponse.Message= await _context.SaveChangesAsync()>0?"Student added successfully":"Student add failed";

            return Ok(reponse);
        }
    }
}
