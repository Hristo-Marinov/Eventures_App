using Microsoft.AspNetCore.Identity;

namespace Eventures.App_2._0.Domain
{
    public class EventuresUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
