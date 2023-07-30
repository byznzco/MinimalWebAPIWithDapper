using Microsoft.AspNetCore.Mvc;
using MinimalWebAPI.Queries;

namespace MinimalWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUsersController : ControllerBase
    {
        private readonly ILogger<GetUsersController> _logger;
        private readonly IUserData _userData;

        public GetUsersController(ILogger<GetUsersController> logger, IUserData userData)
        {
            _logger = logger;
            _userData = userData;
        }

        [HttpGet]
        public async Task<IResult> GetUsers()
        {
            try
            {
                return Results.Ok(await _userData.GetAllUsers(StoredProcedures.SP_SELECT_ALL_USERS));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}