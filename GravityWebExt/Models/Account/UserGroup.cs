using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GravityWebExt.Models
{
    /// <summary>
    /// Группы пользователей
    /// </summary>
    public class UserGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserAccount> Users { get; set; }
        public UserGroup()
        {
            Users = new List<UserAccount>();
        }
    }
}
