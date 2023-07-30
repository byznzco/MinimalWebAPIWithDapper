using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalWebAPI.Queries;

namespace MinimalWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateUserController : ControllerBase
    {
        private readonly ILogger<UpdateUserController> _logger;
        private readonly IUserData _userData;

        public UpdateUserController(ILogger<UpdateUserController> logger, IUserData userData)
        {
            _logger = logger;
            _userData = userData;
        }

        [HttpPost]
        public async Task<IResult> UpdateUser(int id, string firstName, string lastName)
        {
            try
            {
                UserModel model = new UserModel();
                model.Id = id;
                model.FirstName = firstName;
                model.LastName = lastName;

                await _userData.Execute(StoredProcedures.SP_UPDATE_USER, model);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}

