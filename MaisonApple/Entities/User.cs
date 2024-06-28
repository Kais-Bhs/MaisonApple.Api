using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Entities
{
    public class User : IdentityUser
    {
        public int points { get; set; }
        public bool IsBlocked { get; set; }
        public List<Command> payments { get; set; }
        public List<Notification> Notifications { get; set; }
        public ICollection<Favoris>? Favoris { get; set;}
    }
}
