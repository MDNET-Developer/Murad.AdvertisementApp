using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murad.AdvertisementApp.Entity
{
    public class Advertisement:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; } //= DateTime.Now
        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}
