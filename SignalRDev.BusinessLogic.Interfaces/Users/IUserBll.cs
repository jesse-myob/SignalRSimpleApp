using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalRDev.Svc.Dashboard.Users;

namespace SignalRDev.BusinessLogic.Interfaces.Users
{
    public interface IUserBll
    {
        ICollection<UserVm> GetUserList();

        UserVm GetUserById(int id);

        Task AddNewUserAsync(UserVm newUser);
    }
}
