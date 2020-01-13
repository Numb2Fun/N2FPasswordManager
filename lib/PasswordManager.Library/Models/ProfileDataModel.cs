using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Library.Models
{
    public class ProfileDataModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Website { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string SignUpEmail { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
