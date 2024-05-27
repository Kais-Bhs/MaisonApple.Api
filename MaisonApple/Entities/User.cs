using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Entities
{
    public class User : IdentityUser
    {
        public List<Command> payments { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}
