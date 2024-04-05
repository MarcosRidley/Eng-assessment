using AutoMapper;
using Eng_assessment.Repositories.Interface;
using Eng_assessment.Services.Base;
using Eng_assessment.Services.Interface;
using Models.Entities.User;
using Models.Entities.User.RequestDTOs;
using Models.Entities.User.ResponseDTOs;

namespace Eng_assessment.Services
{
    public class UserService : RootService<User, UserGetDTO, UserCreateDTO, UserUpdateDTO>, IUserService
    {
        public UserService(IUserRepository userRepository, IMapper mapper ) : base (userRepository, mapper)
        {
        }

        public async Task<UserGetDTO> ToggleUserActiveAsync(long id)
        {
            //This is an example of a method that is not in the base generic class, but is specific to the User entity, just to show that we can have specific methods for each entity
            User user = await _repository.GetAsync(id, true) ?? throw new KeyNotFoundException("Entity not found for this ID");
            user.Active = !user.Active;
            await _repository.SaveChangesAsync();
            return _mapper.Map<UserGetDTO>(user);
        }
    }
}
