using Models.Entities.User;
using Models.Entities.User.RequestDTOs;
using Models.Entities.User.ResponseDTOs;

namespace Eng_assessment.Services.Interface
{
    public interface IUserService : IService<User, UserGetDTO, UserCreateDTO, UserUpdateDTO>
    {
        public Task<UserGetDTO>ToggleUserActiveAsync(long id);
    }
}
