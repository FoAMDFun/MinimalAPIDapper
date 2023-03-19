using DataAccess.DBAccess;
using DataAccess.Models;

namespace DataAccess.Data;
public class UserData : IUserData
{
    private readonly ISqlDataAccess Db;
    public UserData(ISqlDataAccess db)
    {
        Db = db;
    }

    public async Task<IEnumerable<UserModel>> GetUsers() => await Db.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { });

    public async Task<UserModel?> GetUser(int Id)
    {
        var result = await Db.LoadData<UserModel, dynamic>("dbo.spUser_GetById", new { Id });
        return result.FirstOrDefault();
    }

    public async Task InsertUser(UserModel user) => await Db.SaveData("dbo.spUser_Insert", new { user.FirstName, user.LastName });
    public async Task Updateuser(UserModel user) => await Db.SaveData("dbo.spUser_Update", user);
    public async Task DeleteUser(int Id) => await Db.SaveData("dbo.spUser_Delete", new { Id });
}
