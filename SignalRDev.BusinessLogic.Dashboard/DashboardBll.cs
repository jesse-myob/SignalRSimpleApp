using SignalRDev.BusinessLogic.Common;
using SignalRDev.BusinessLogic.Interfaces;
using SignalRDev.BusinessLogic.Interfaces.Users;
using SignalRDev.DataAccess.Interfaces.Common;
using SignalRDev.DataAccess.Models;
using SignalRDev.Svc.Dashboard.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDev.BusinessLogic.Dashboard
{
    public class DashboardBll : SignalRBusinessLogicBase, IDashboardBll
    {
        private readonly IRepository<UserLog> _userRepo;

        public DashboardBll(ICustomObjectMapper objMapper, IRepository<UserLog> userRepo) : base(objMapper)
        {
            _userRepo = userRepo;
        }

        public async Task AddNewUserLog(UserLogInformationVM UserLogInfo)
        {
            if (UserLogInfo == null)
                throw new ArgumentException("Log Information is Empty.");

            try
            {
                var userLogData = _objMapper.MapToObject<UserLogInformationVM, UserLog>(UserLogInfo);

                _userRepo.Add(userLogData);

                await _userRepo.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<UserLogInformationVM> GetCurrentUserLogById(int userId)
        {
            var userActivity = _userRepo.All()
                                        .Where(u => u.UserId == userId && u.LogDate == DateTime.UtcNow);

            var mappedData = _objMapper.MapToEnumerable<UserLog, UserLogInformationVM>(userActivity);

            return mappedData;
        }
    }
}
