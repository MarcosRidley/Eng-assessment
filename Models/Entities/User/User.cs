using Models.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Models.Entities.User
{
    public class User : DatabaseEntity
    {
        [Required]
        public string Name { get; set; }
        //Many operations do not yet support DateOnly, so I'll use DateTime for now.
        public DateTime BirthDate { get; set; }
    }
}
