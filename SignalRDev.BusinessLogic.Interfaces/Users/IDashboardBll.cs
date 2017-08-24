using SignalRDev.Svc.Dashboard.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDev.BusinessLogic.Interfaces.Users
{
    public interface IDashboardBll
    {
        Task AddNewUserLog(UserLogInformationVM UserLogInfo);

        IEnumerable<UserLogInformationVM> GetCurrentUserLogById(int userId);
    }
}
