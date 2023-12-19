using UsersAPI.Data;
using UsersAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace UsersAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet("GetAllUsers")]
        public IActionResult Index()
        {
            return Json(_context.Set<User>().ToList()); 
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser(User user)
        {
            try
            {
                user.id = _context.Set<User>().Any() ? _context.Set<User>().Max(o => o.id)+1 : 1;
                // For npgsql
                //_context.Database.ExecuteSqlRaw("INSERT INTO User ");

                // For NoSql
                _context.Set<User>().Add(user);
                _context.SaveChanges();
                return Json("Success");

            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
          
           
        }

        [HttpGet("SearchUser")]
        public ActionResult SearchUser(string email)
        {
            return Json(_context.User.Where(e=>e.EmailAddress==email));
        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var user = _context.User.Where(i => i.id == id).FirstOrDefault();
                _context.Remove(user);
                _context.SaveChanges();
                return Json("Successfully deleted user");

            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }

        [HttpPost("UpdateUser")]
        public IActionResult UpdateUser(User user)
        {
            try
            {
                _context.Update(user);
                _context.SaveChanges();
                return Json("Successfully updated user");

            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }
    }
}
