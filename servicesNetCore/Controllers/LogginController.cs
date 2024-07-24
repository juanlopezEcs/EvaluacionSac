using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiEvaluacion.Models;
using Microsoft.AspNetCore.Connections.Features;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApiEvaluacion.Controllers
{
    [Route("api/Loggin")]
    [ApiController]
    public class LogginController : ControllerBase
    {
        private readonly DbApiContext _context;

        public LogginController(DbApiContext context)
        {
            _context = context;
        }

        // POST: api/Loggin
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Loggin")]
        public async Task<ActionResult<object>> Loggin(User user)
        {
            bool userExists = _context.user.Any(e => e.userName == user.userName);
            if (!userExists)
            {
                return false;
            }

            User userDb = await _context.user.Where(w => w.userName == user.userName).FirstAsync();

            string sha = encripy.GenerateSHA256Hash(user.pass);

            if (sha != userDb.pass)
            {
                return false;
            }
            userDb.pass = "";
            var claims = new[] { new Claim(ClaimTypes.Name, JsonConvert.SerializeObject(userDb)) };

            var token = new JwtSecurityToken
                (
                    issuer: null,
                    audience: null,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(1),
                    notBefore: DateTime.UtcNow
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // DELETE: api/Loggin/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {

            var user = await _context.user.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.user.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
