using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalWebAPI.Queries;

namespace MinimalWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteUserController : ControllerBase
    {
        private readonly ILogger<DeleteUserController> _logger;
        private readonly IUserData _userData;

        public DeleteUserController(ILogger<DeleteUserController> logger, IUserData userData)
        {
            _logger = logger;
            _userData = userData;
        }

        [HttpPost]
        public async Task<IResult> DeleteUser(int id)
        {
            try
            {
             
                await _userData.Delete(StoredProcedures.SP_DELETE_USER, id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
