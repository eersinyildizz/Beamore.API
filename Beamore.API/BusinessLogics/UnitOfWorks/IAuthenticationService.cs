using Beamore.Contracts.DataTransferObjects.Account;

namespace Beamore.API.BusinessLogics.UnitOfWorks
{
    public interface IAuthenticationService
    {
        RegistrationResultDTO Register(RegisterDTO registerModel);              
    }
}
