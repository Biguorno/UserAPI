using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UserAPI.Data;
using UserAPI.Modeles;

namespace UserAPI.Controllers
{

    public class UsersController : Controller
    {
        private readonly UserApiContext _context;

        public UsersController(UserApiContext context)
        {
            _context = context;
        }

        // GET: Users
        [HttpGet ("GetUser")]
        public async Task<ActionResult<List<User>>> Index()
        {
            var user = await _context.User.ToListAsync();

              return Ok(user);
        }

        // GET: Users/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Details(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Uti_Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return Ok();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost ("/post")]
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Uti_Id,Uti_Nom,Uti_Prenom,Uti_Adresse,Uti_Ville,Uti_Cp,Uti_Telephone,Uti_Email,Uti_Mdp,Uti_TypeUtil")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return Ok("Success !");
            }
            else
            {
                return BadRequest();
            }
            
            
        }
        [HttpDelete ("/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id != null && _context != null)
            {
                var userDelete = await _context.User.FirstOrDefaultAsync(u => u.Uti_Id == id);
                _context.Remove(userDelete);
                _context.SaveChanges();
                return Ok("Suppresion success !");
            }
            else
            {
                return NoContent();
            }
           
        }

        [HttpGet ("/UserExist")]
        private bool UserExists(int id)
        {
          return (_context.User?.Any(e => e.Uti_Id == id)).GetValueOrDefault();
        }
    }
}
