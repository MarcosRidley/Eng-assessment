using Eng_assessment.Controllers.Base;
using Eng_assessment.Services;
using Eng_assessment.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Models.Entities.User;
using Models.Entities.User.RequestDTOs;
using Models.Entities.User.ResponseDTOs;

namespace Eng_assessment.Controllers
{
    public class UserController : RootController<User, IUserService, UserGetDTO, UserCreateDTO, UserUpdateDTO>
    {
        public UserController(IUserService service) : base(service)
        {
        }

        [HttpPut("toggle-active/{id}")]
        public async Task<IActionResult> ToggleActive(long id)
        {
            //This is an example of a method that is not in the base generic class, but is specific to the User entity, just to show that we can have specific methods for each entity
            //I made this method because it seemed to me like the requested update method was basically only being used as an active toggle anyway, so this specialized method does that in a more explicit way and frees up the update method to be used for actual updates to name/birthdate/etc
            return Ok(await _service.ToggleUserActiveAsync(id));
        }
    }
}
