using DataAccess.Models;

namespace DataAccess.Data;
public interface IUserData
{
    Task DeleteUser(int Id);
    Task<UserModel?> GetUser(int Id);
    Task<IEnumerable<UserModel>> GetUsers();
    Task InsertUser(UserModel user);
    Task Updateuser(UserModel user);
}