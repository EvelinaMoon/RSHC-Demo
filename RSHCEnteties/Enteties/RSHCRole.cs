using Microsoft.AspNet.Identity;
using System.Net.NetworkInformation;

namespace RSHCEnteties
{
    public enum RSHCRole
    {
        Admin = 1,       // Manage everything
        Manager = 2,     // Manage most aspects of the site
        Editor = 3,      // Scheduling and managing content
        Author = 4,     //  Write important content
        Contributors = 5, //Authors with limited rights
        Moderator = 6,    //Moderate user content
        Member = 7,       //Special user access
        Subscriber = 8,   //Paying Average Joe
        User = 9,        // Average Joe
        Guest = 10,      // duh
        Emeritus = 11,   // retired key users who no longer contribute, but whose contributions are honored
    }
}