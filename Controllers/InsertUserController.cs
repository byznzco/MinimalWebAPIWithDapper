using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalWebAPI.Queries;

namespace MinimalWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsertUserController : ControllerBase
    {
        private ILogger<InsertUserController> _logger;
        private IUserData _userData;

        public InsertUserController(ILogger<InsertUserController> logger, IUserData userData)
        {
            _logger = logger;
            _userData = userData;
        }

        [HttpPost]
        public async Task<IResult> InsertUser(string firstName, string lastName)
        {
            try
            {
                UserModel model = new UserModel();
                model.FirstName = firstName;
                model.LastName = lastName;
                await _userData.Execute(StoredProcedures.SP_INSERT_USER, model);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
