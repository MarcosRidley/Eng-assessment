using AutoMapper;
using Models.Entities.User.ResponseDTOs;
using Models.Entities.User;
using Models.Entities.User.RequestDTOs;

namespace Eng_assessment.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            #region User
            CreateMap<User, UserGetDTO>().ReverseMap();
            CreateMap<User, UserUpdateDTO>().ReverseMap();
            CreateMap<User, UserCreateDTO>().ReverseMap();
            #endregion
        }
    }
}
