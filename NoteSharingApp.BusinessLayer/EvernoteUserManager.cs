using NoteSharingApp.BusinessLayer.Abstract;
using NoteSharingApp.BusinessLayer.Results;
using NoteSharingApp.Common;
using NoteSharingApp.Entities;
using NoteSharingApp.Entities.Messages;
using NoteSharingApp.Entities.ValueObjects;
using System;

namespace NoteSharingApp.BusinessLayer
{
    public class EvernoteUserManager : ManagerBase<EvernoteUser>
    {

        public BusinessLayerResult<EvernoteUser> Login(LoginViewModel model)
        {
            BusinessLayerResult<EvernoteUser> res = new BusinessLayerResult<EvernoteUser>();
            res.Result = Find(x => x.Username == model.Username && x.Password == model.Password);

            if (res.Result != null)
            {
                if (res.Result.IsActive == false)
                {
                    res.AddError(ErrorMessageEnum.AccountInactive, "User Inactive Check Your Mailbox!");
                }
            }
            else
            {
                res.AddError(ErrorMessageEnum.UserCouldNotFound, "Check Your Username or Password");
            }
            return res;
        }

        public BusinessLayerResult<EvernoteUser> Register(RegisterViewModel model)
        {
            BusinessLayerResult<EvernoteUser> res = new BusinessLayerResult<EvernoteUser>();
            res.Result = Find(x => x.Username == model.Username || x.Email == model.EMail);

            if (res.Result != null)
            {
                if (res.Result.Username == model.Username)
                {
                    res.AddError(ErrorMessageEnum.UsernameAlreadyExists, "Username Already Exists");
                }
                if (res.Result.Email == model.EMail)
                {
                    res.AddError(ErrorMessageEnum.EmailAlreadyExists, "Email Already Exists");
                }
                return res;
            }
            EvernoteUser user = new EvernoteUser()
            {
                Username = model.Username,
                Password = model.Password,
                Email = model.EMail,
                CreatedOn = DateTime.Now,
                IsActive = true,
                ModifiedUsername = App.Common.GetCurrentUsername(),
                ActivateGuid = Guid.NewGuid(),
                IsAdmin = false,
                ModifiedOn = DateTime.Now
            };
            Insert(user);
            res.Result = user;
            return res;
        }
    }
}
