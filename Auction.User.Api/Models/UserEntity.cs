using Auction.Common.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.User.Api.Models
{
    public class UserEntity: EntityBase
    {
        public string Username { get; set; }
        public string Password { get; set; }


        public UserEntity(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
