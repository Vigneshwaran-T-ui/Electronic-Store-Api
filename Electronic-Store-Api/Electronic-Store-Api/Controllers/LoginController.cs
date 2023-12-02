using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Electronic_Store_Api.Services;
using Microsoft.AspNetCore.Authorization;
using Electronic_Store_Api.DataModels;
using Electronic_Store_Api.ViewModels;
using Electronic_Store_Api.Common;

namespace Electronic_Store_Api.Controllers
{

    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    { 
        private readonly ILogger<LoginController> _logger;
        private readonly IMapper _mapper;
        private readonly ILoginService _LoginService;
        private int _status;
        private string _message;

        public LoginController(ILogger<LoginController> logger, IMapper mapper, ILoginService loginService)
        {
            _logger = logger;
            _mapper = mapper;
            _LoginService = loginService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult EsUsersLogin([FromBody] Login loginDetails) 
        {
            TraceLog.LogActivity(ConstantProp.controllerIn, 0, "", RouteData, "", "");
            var user = _LoginService.EsUsersLogin(loginDetails, out _status, out _message);
            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            TraceLog.LogActivity(ConstantProp.controllerIn, 0, "", RouteData, "", "");

            return (ActionResult)this.StatusCode(200, (object)new
            {
                data = user,
                status = this._status,
                message = this._message
            });
        }
    }
 
}
