using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities.User.RequestDTOs
{
    public class UserCreateDTO
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; } = true;
        //Due to an arbitrary decision, I took the route of allowing the possibility of creating an inactive user to be activated through the update method.
        //It is equally likely that every user should be created Active, but that would be a business rule defined by the project itself.
    }
}
