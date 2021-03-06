using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GravityWebExt.Models
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class UserAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public UserGroup Role { get; set; }
    }
}
