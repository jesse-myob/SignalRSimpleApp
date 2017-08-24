using SignalRDev.BusinessLogic.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalRDev.DataAccess.Interfaces.Common;
using SignalRDev.DataAccess.Models.Users;
using SignalRDev.Svc.Dashboard.Users;
using SignalRDev.BusinessLogic.Common;
using SignalRDev.BusinessLogic.Interfaces;

namespace SignalRDev.BusinessLogic.Dashboard
{
    public class UserBll: SignalRBusinessLogicBase, IUserBll
    {
        private readonly IRepository<CoopUser> _coopUser;
        private readonly IRepository<UserProfile> _userProfile;

        public UserBll(IRepository<CoopUser> pCoopUserRepo, IRepository<UserProfile> pUserProfileRepo, ICustomObjectMapper pCusObjMapper) : base(objMapper: pCusObjMapper)
        {
            _coopUser = pCoopUserRepo;
            _userProfile = pUserProfileRepo;
        }

        public async Task AddNewUserAsync(UserVm newUser)
        {
            try
            {
                if (newUser == null)
                    throw new ArgumentNullException("User to add is empty.");

                CoopUser mappedDbUser = _objMapper.MapToObject<UserVm, CoopUser>(newUser);
                UserProfile mappedDbUserProfile = _objMapper.MapToObject<UserVm, UserProfile>(newUser);
                
                await Task.WhenAll(AddUserToRepo(mappedDbUser), AddUserProfileToRepo(mappedDbUserProfile));
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task AddUserToRepo(CoopUser newUser)
        {
            try
            {
                if (newUser == null)
                    throw new ArgumentNullException("User Data is empty.");

                _coopUser.Add(newUser);
                await _coopUser.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task AddUserProfileToRepo(UserProfile newUserProfile)
        {
            try
            {
                if (newUserProfile == null)
                    throw new ArgumentNullException("User Profile is Empty.");

                _userProfile.Add(newUserProfile);
                await _userProfile.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserVm GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<UserVm> GetUserList()
        {
            throw new NotImplementedException();
        }
    }
}
