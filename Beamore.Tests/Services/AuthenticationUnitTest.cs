using Beamore.API.Controllers;
using Beamore.Contracts.DataTransferObjects.Account;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;

namespace Beamore.Tests.Services
{
    [TestClass]
    public class AuthenticationUnitTest
    {

        /// <summary>
        /// New User should register the system. Return type must be true
        /// </summary>
        [TestMethod]
        public void TestRegisterUserSuccess()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var user = new RegisterDTO
                {
                    Email = "eersinyildizzd@gmail.com",
                    Username = "ersin yildiz",
                    Password = "123",
                    Role = "endUser"
                };

                var service = new UserController();
                var result = service.RegisterUser(user);

                Assert.AreEqual(true,result.IsSuccess);
                Assert.IsNotNull(result.Message);

            }
        }

        /// <summary>
        /// If user is exist on system than it must denied the request 
        /// </summary>
        [TestMethod]
        public void TestRegisterUserIsExists()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var user = new RegisterDTO
                {
                    Email = "ersinyildiz@gmail.com",
                    Username = "ersin yildiz",
                    Password = "123",
                    Role = "endUser"
                };

                var service = new UserController();
                var result = service.RegisterUser(user);

                Assert.AreEqual(false, result.IsSuccess);
                Assert.IsNotNull(result.Message);               

            }
        }

        /// <summary>
        /// Register information will not be null - EMAIL
        /// </summary>
        [TestMethod]
        public void TestRegisterUserNullControlFor_Email()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var user = new RegisterDTO
                {                    
                    Username = "ersin yildiz",
                    Password = "123",
                    Role = "endUser"
                };

                var service = new UserController();
                var result = service.RegisterUser(user);

                Assert.AreEqual(false, result.IsSuccess);
                Assert.IsNotNull(result.Message);

            }
        }

        /// <summary>
        /// Register information will not be null - PASSWORD
        /// </summary>
        [TestMethod]
        public void TestRegisterUserNullControlFor_Password()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var user = new RegisterDTO
                {
                    Email = "ersinyildiz@gmail.com",
                    Username = "ersin yildiz",
                    Role = "endUser"
                };

                var service = new UserController();
                var result = service.RegisterUser(user);

                Assert.AreEqual(false, result.IsSuccess);
                Assert.IsNotNull(result.Message);

            }
        }

        /// <summary>
        /// Register information will not be null - USERNAME
        /// </summary>
        [TestMethod]
        public void TestRegisterUserNullControlFor_Username()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var user = new RegisterDTO
                {
                    Email = "ersinyildiz@gmail.com",
                    Password = "123",
                    Role = "endUser"
                };

                var service = new UserController();
                var result = service.RegisterUser(user);

                Assert.AreEqual(false, result.IsSuccess);
                Assert.IsNotNull(result.Message);

            }
        }

        /// <summary>
        /// Register information will not be null - ROLE
        /// </summary>
        [TestMethod]
        public void TestRegisterUserNullControlFor_Role()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var user = new RegisterDTO
                {
                    Email = "ersinyildiz@gmail.com",
                    Username = "ersin yildiz",
                    Password = "123"
                };

                var service = new UserController();
                var result = service.RegisterUser(user);

                Assert.AreEqual(false, result.IsSuccess);
                Assert.IsNotNull(result.Message);

            }
        }

        /// <summary>
        /// Role can only "endUser" or "Manager"
        /// </summary>
        [TestMethod]
        public void TestRegisterUserNullControlFor_RoleTypeControl()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var user = new RegisterDTO
                {
                    Email = "ersinyildiz@gmail.com",
                    Username = "ersin yildiz",
                    Password = "123",
                    Role = "admin"
                };

                var service = new UserController();
                var result = service.RegisterUser(user);

                Assert.AreEqual(false, result.IsSuccess);
                Assert.IsNotNull(result.Message);

            }
        }

        /// <summary>
        /// Email validation test
        /// </summary>
        [TestMethod]
        public void TestRegisterUserInvalidEmailControl()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var user = new RegisterDTO
                {
                    Email = "ersinyildiz@gmail",
                    Username = "ersin yildiz",
                    Password = "123",
                    Role = "admin"
                };

                var service = new UserController();
                var result = service.RegisterUser(user);

                Assert.AreEqual(false, result.IsSuccess);
                Assert.IsNotNull(result.Message);

            }
        }


        /// <summary>
        /// If email not register the system do result sdtatus must be false and sent6 warning
        /// </summary>
        [TestMethod]
        public void TestForgotPassword()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                ForgotPasswordDTO fp = new ForgotPasswordDTO
                {
                    Email = "eersinyildizza@gmail.com"
                };

                var service = new UserController();
                var result = service.ForgetPassword(fp);

                Assert.AreEqual(false, result.IsSuccess);
                Assert.IsNotNull(result.Message);
            }
            
        }

        /// <summary>
        /// If email is already have a forgotpasssword email then, system should sent new email
        /// </summary>
        [TestMethod]
        public void TestForgotPassword_SentBeforeForgotPassword()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                ForgotPasswordDTO fp = new ForgotPasswordDTO
                {
                    Email = "eersinyildizz@gmail.com"
                };

                var service = new UserController();
                var result = service.ForgetPassword(fp);

                Assert.AreEqual(true, result.IsSuccess);
                Assert.IsNotNull(result.Message);
            }

        }


    }
}
