using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities.Base
{
    public abstract class DatabaseEntity
    {
        public long Id { get; set; }
        public bool Active { get; set; } = true;
        //I'd rather avoid using IDs as the default way of identifying entities during responses and would rather use GUIDs for that, but for the sake of simplicity and to follow the required table structure, I'll use IDs.

        //public Guid Guid { get; set; }
    }
}
