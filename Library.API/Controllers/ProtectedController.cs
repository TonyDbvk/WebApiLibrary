using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.API.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProtectedController : ControllerBase
    {
        // GET: api/protected
        [HttpGet]
        // Доступен только авторизованным пользователям
        public ActionResult<string> GetProtectedData()
        {
            return DateTime.Now.ToString();
        }
    }
}
