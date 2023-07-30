using Microsoft.AspNetCore.Mvc;
using MinimalWebAPI.Queries;

namespace MinimalWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUserController : ControllerBase
    {
        private readonly ILogger<GetUsersController> _logger;
        private readonly IUserData _userData;

        public GetUserController(ILogger<GetUsersController> logger, IUserData userData)
        {
            _logger = logger;
            _userData = userData;
        }

        [HttpGet]
        public async Task<IResult> GetUser(string id)
        {
            try
            {
                var result = await _userData.GetUser(StoredProcedures.SP_SELECT_USER, int.Parse(id));
                if(result == null)
                    return Results.NotFound();
                
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
