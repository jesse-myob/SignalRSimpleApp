using SignalRDev.DataAccess.Dashboard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignalRDev.DataAccess.Dashboard.Interface
{
    public interface IUserLogDataAccess
    {
        void InsertNewUserLog(CoopbaseUserLogData newUserData);
    }
}
