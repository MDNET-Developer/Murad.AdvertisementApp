using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murad.AdvertisementApp.Entity
{
    public class Gender:BaseEntity
    {
        public string Definition { get; set; }
         public List<AppUser> AppUsers { get; set; }
    }
}
