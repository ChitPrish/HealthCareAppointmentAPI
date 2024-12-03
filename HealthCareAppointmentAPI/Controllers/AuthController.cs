using HealthcareAppointmentModels;
using HealthcareAppointmentRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User = HealthcareAppointmentModels.User;

namespace HealthCareAppointmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtTokenHelper _jwtTokenHelper;

        private readonly HealthcareAppointmentContext _context;

        private readonly IUoWUser _user;

        public AuthController(IJwtTokenHelper jwtTokenHelper, HealthcareAppointmentContext context, IUoWUser IOWuser)
        {
            _jwtTokenHelper = jwtTokenHelper;
            _context = context;
            _user = IOWuser;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            var users = _context.Users.SingleOrDefault(x => x.UserName == loginModel.UserName && x.Password == loginModel.Password);
            if (users != null)
            {
                var token = _jwtTokenHelper.GenerateToken(loginModel.UserName);
                return Ok(new { Token = token });
            }
            return new UnauthorizedResult();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(Register registerModel)
        {
            User user = new()
            {
                UserName = registerModel.UserName,
                Password = registerModel.Password,
                UserEmail = registerModel.UserEmail,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow
            };
            _context.Users.Add(user);
            _context.SaveChangesAsync();
            return Ok(new { message = "Registration successful" });
        }
    }
}
