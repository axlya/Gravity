using System.Linq;

namespace GravityWebExt.Models
{
    /// <summary>
    /// Инициализация БД с параметрами по-умолчанию
    /// </summary>
    public class InitAuthData
    {
        public static void Initialize(AuthContext context)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminName = "admin";
            string adminPassword = "123456";

            // добавляем роли
            UserGroup adminRole = new UserGroup { Name = adminRoleName };
            UserGroup userRole = new UserGroup { Name = userRoleName };
            User adminUser = new User { Name = adminName, Password = adminPassword, RoleId = 1 };

            // Роли
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                    new UserGroup[] {
                    adminRole,
                    userRole
                    }
                );
                context.SaveChanges();
            }

            // Пользователи
            if (!context.Users.Any())
            {
                context.Users.Add(
                    adminUser
                );
                context.SaveChanges();
            }
        }
    }
}
