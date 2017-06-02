using Beamore.API.BusinessLogics.UnitOfWorks;
using Beamore.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Beamore.Tests
{
    public class TestUserPrinciple : IPrincipal
    {
        private TestUserIdentitiyModel _identity;
        public TestUserPrinciple(string username)
        {
            _identity = new TestUserIdentitiyModel(username);
        }
        public IIdentity Identity
        {
            get
            {
                return _identity;
            }
        }

        public bool IsInRole(string role)
        {
            return _identity.Role.Contains(role);
        }
    }
    public class TestUserIdentitiyModel : IIdentity
    {
        private string _username;
        public TestUserIdentitiyModel(string username)
        {
            _username = username;
        }

        public string AuthenticationType
        {
            get
            {
                return "Bearer";
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return true;
            }
        }

        public string Name
        {
            get
            {
                return _username;
            }
        }

        public string Role
        {
            get
            {
                return "Manager,endUser";
            }
        }
    }
    public class ServiceProxy<T> : RealProxy
    {
        private static Dictionary<Type, Type> _apiRegistration = new Dictionary<Type, Type>();
        static ServiceProxy()
        {
            _apiRegistration.Add(typeof(IEventService), typeof(EventController));
        }

        private object _instance = null;
        public ServiceProxy(string username) : base(typeof(T))//: base(_apiRegistration[typeof(T)])
        {
            _instance = Activator.CreateInstance(_apiRegistration[typeof(T)]);
            ((ApiController)_instance).User = new TestUserPrinciple(username);
        }

        public override IMessage Invoke(IMessage msg)
        {
            var methodCall = msg as IMethodCallMessage;
            try
            {
                var methodInfo = methodCall.MethodBase as MethodInfo;

                //var authAttrs = methodInfo.GetCustomAttributes<AuthorizeAttribute>();
                //if (authAttrs.Count() == 1)
                //{
                //    AuthorizeAttribute authAttr = (AuthorizeAttribute)authAttrs.ElementAt(0);
                //    //authAttr.Roles
                //    if(((BaseApiController)_instance).User.IsInRole(authAttr.Roles) == false)
                //    {
                //        throw new UnauthorizedAccessException();
                //    }

                //}

                var result = methodInfo.Invoke(_instance, methodCall.InArgs);
                return new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);

            }
            catch (Exception ex)
            {
                return new ReturnMessage(ex, methodCall);
            }
        }

        public T Service
        {
            get
            {
                return (T)this.GetTransparentProxy();
            }
        }

        //public static T GetService<T>()
        //{


        //   object serviceInstance = Activator.CreateInstance(serviceImpl);
        //    ((BaseApiController)serviceInstance).User;
        //    return (T)serviceInstance;


        //}

    }

    public class GenericProxy
    {
        public static T GetService<T>(string username)
        {
            ServiceProxy<T> proxy = new ServiceProxy<T>(username);
            return proxy.Service;
        }

    }
}
