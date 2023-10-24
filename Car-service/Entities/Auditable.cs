using Car_service.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Entities
{
    public abstract class Auditable : BaseEntity
    {
        public DateTime CreatedAt  { get; set; }
        public DateTime UpdatedAt  { get; set;}
        public Auditable()
        {
            CreatedAt = TimeHelper.GetDateTime();
            UpdatedAt = TimeHelper.GetDateTime();
        }
    }
}
