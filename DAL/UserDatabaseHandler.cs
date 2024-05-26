using DTO;

namespace DAL
{
    public class UserDatabaseHandler
    {
        DBContext context;
        public UserDatabaseHandler()
        {
            context = new DBContext();
        }

        public void CreateUser(UserDTO user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void UpdateUser(UserDTO user)
        {
            UserDTO DbUser = context.Users.Where(t => t.Id == user.Id).FirstOrDefault();
            if (DbUser != null)
            {
                DbUser.Id = user.Id;
                DbUser.Name = user.Name;
                DbUser.FirstName = user.FirstName;
                DbUser.LastName = user.LastName;
                DbUser.InFix = user.InFix;
                DbUser.Email = user.Email;
                context.SaveChanges();
            }
        }

        public void DeleteUser(UserDTO user)
        {
            UserDTO toDelete = this.GetUser(user.Id);
            context.Users.Remove(toDelete);
            context.SaveChanges();
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            return context.Users;
        }

        public UserDTO GetUser(int UserId)
        {
            return context.Users.Where(t => t.Id == UserId).FirstOrDefault();
        }
    }
}
