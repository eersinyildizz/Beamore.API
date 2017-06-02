using Beamore.API.BusinessLogics.CO;
using Beamore.API.BusinessLogics.Utilities.AccountUtilities;
using Beamore.API.BusinessLogics.Validation;
using Beamore.Contracts.DataTransferObjects;
using Beamore.Contracts.DataTransferObjects.Account;
using Beamore.DAL.Contents.Models;
using Beamore.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace Beamore.API.BusinessLogics.UnitOfWorks
{
    public class AuthenticationService : IAuthenticationService
    {
        private IRepository<User> _userRepo;

        private IRepository<TempUser> _tempUserRepo;
        private RegistrationResultDTO result = new RegistrationResultDTO();
        private ForgotPasswordResultDTO forgotPasswordResult = new ForgotPasswordResultDTO();


        public AuthenticationService(IRepository<User> userRepository, IRepository<TempUser> tempUserRepository)
        {
            this._userRepo = userRepository;
            this._tempUserRepo = tempUserRepository;
        }

        /// <summary>
        /// Register model is controlling and if there is no validation error than newUser will add to database
        /// </summary>
        /// <param name="registerModel"></param>
        /// <returns></returns>
        public RegistrationResultDTO Register(RegisterDTO registerModel)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var ValidationControl = AccountValidationBL.NullControlRegisterDTO(registerModel);
                result.Message = ValidationControl.Message;
                result.IsSuccess = ValidationControl.IsValid;

                if (ValidationControl.IsValid)
                {
                    var resultDec = PasswordUtilies.EncryptPassword(registerModel.Password);
                    var isExist = _userRepo.FindByExxpression(p => p.Email == registerModel.Email);
                    if (isExist.Count != 0)
                    {
                        result.Message = "Kullanıcı daha önceden sisteme kayıtlıdır.";
                        result.IsSuccess = false;
                        return result;
                    }

                    User newUser = _userRepo.add(new User
                    {
                        Username = registerModel.Username,
                        Email = registerModel.Email,
                        Password = resultDec.Password,
                        PasswordSalt = resultDec.Salt,
                        Role = registerModel.Role
                    });

                    if (newUser == null)
                    {
                        result.Message = "Hata oluştu";
                        result.IsSuccess = false;
                    }
                }
                _userRepo.Save();
                scope.Complete();

                return result;
            }
        }

        public LoginCO Login(string email, string password)
        {
            var resultUser = new LoginCO
            {
                UserEmail = email,
                Status = false
            };
            User getUser = _userRepo.FindByExpBySingle(p => p.Email == email);
            if (getUser != null)
            {

                var resultDec = PasswordUtilies.EncryptPasswordForLogin(password, getUser.PasswordSalt);
                if (getUser.Password == resultDec.Password)
                {
                    resultUser.Role = getUser.Role;
                    resultUser.Status = true;
                    return resultUser;
                }
            }
            return resultUser;
        }

        public ForgotPasswordResultDTO ForgotPassword(ForgotPasswordDTO model)
        {


            List<User> user = _userRepo.FindByExxpression(p => p.Email == model.Email);
            if (user.Count != 0)
            {
                var tempUser = _tempUserRepo.FindByExxpression(p => p.Email == model.Email);
                if (tempUser.Count != 0)
                {
                    _tempUserRepo.Delete(tempUser[0]);
                }

                Guid guid = Guid.NewGuid();
                TempUser Temp = new TempUser
                {
                    Email = model.Email,
                    TempGuid = guid.ToString()
                };
                _tempUserRepo.add(Temp);
                //string callBackUrl = "http://localhost:63168/Account/ForgotPassword" + "?key=" + guid;
                string callBackUrl = "http://beamorewebportal.azurewebsites.net/Account/ForgotPassword" + "?key=" + guid;
                ForgotPasswordModelCO mailModel = new ForgotPasswordModelCO
                {
                    Email = model.Email,
                    GuidPassword = guid.ToString(),
                    Link = callBackUrl
                };

                _tempUserRepo.Save();
                var se = new SentEmail();
                se.SendMail(mailModel);
                forgotPasswordResult.Message = "Password yenilemek için şifre email hesabınıza gönderilmiştir.";
                forgotPasswordResult.IsSuccess = true;
                return forgotPasswordResult;

            }
            else
            {
                forgotPasswordResult.Message = "Email adresi sisteme kayıtlı değildir.";
                forgotPasswordResult.IsSuccess = false;
                return forgotPasswordResult;
            }

        }

        public bool UpdatePassword(UpdatePasswordCO model)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                List<TempUser> TmpUsr = _tempUserRepo.FindByExxpression(p => p.TempGuid.Equals(model.GuidPassword));
                if (TmpUsr.Count != 0)
                {
                    var em = TmpUsr[0].Email;
                    var getUser = _userRepo.FindByExxpression(p => p.Email.Equals(em));
                    var resultDec = PasswordUtilies.EncryptPassword(model.NewPassword);
                    getUser[0].Password = resultDec.Password;
                    getUser[0].PasswordSalt = resultDec.Salt;
                    _userRepo.update(getUser[0]);
                    _tempUserRepo.Delete(TmpUsr[0]);
                    _userRepo.Save();
                    _tempUserRepo.Save();
                    scope.Complete();
                    return true;
                }
                return false;
            }
        }

        public UserDTO UserInformation(string email)
        {
            var re = _userRepo .FindByExpBySingle(p => p.Email == email);
            var result = new UserDTO
            {
                Email = re.Email,
                Username = re.Username
            };
            return result;

        }
    }
}