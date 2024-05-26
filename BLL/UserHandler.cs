using DAL;
using DTO;

namespace BLL
{
    public class UserHandler
    {
        private UserDatabaseHandler databaseHandler;
        public UserHandler()
        {
            databaseHandler = new UserDatabaseHandler();
        }

        public void CreateUser(UserDTO user)
        {
            databaseHandler.CreateUser(user);
        }

        public void UpdateUser(UserDTO user)
        {
            databaseHandler.UpdateUser(user);
        }

        public void DeleteUser(UserDTO user)
        {
            databaseHandler.DeleteUser(user);
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            return databaseHandler.GetAllUsers();
        }

        public UserDTO GetUser(int UserId)
        {
            return databaseHandler.GetUser(UserId);
        }
    }
}
