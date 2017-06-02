using Beamore.API.BusinessLogics.CO;
using Beamore.Contracts.DataTransferObjects.Account;

namespace Beamore.API.BusinessLogics.Validation
{
    /// <summary>
    /// All control about register, login are checked this class.
    /// </summary>
    public static class AccountValidationBL
    {
        private static ValidationCO ValidationResult = new ValidationCO();
        private static RegexUtilities util = new RegexUtilities();

        /// <summary>
        /// Checking for RegisterDTO is null or not 
        /// </summary>
        /// <param name="registerUser">RegisteredUser</param>
        /// <returns></returns>
        public static ValidationCO NullControlRegisterDTO(RegisterDTO registerUser)
        {
            ValidationResult.IsValid = true;
            ValidationResult.Message = "Success";

            if (registerUser.Email == null || registerUser.Username == null || registerUser.Password == null || registerUser.Role == null)
            {
                ValidationResult.IsValid = false;
                ValidationResult.Message = Resources.Resource_tr.ValidationNullErrorMessage;
                return ValidationResult;
            }
            if (!util.IsValidEmail(registerUser.Email))
            {
                ValidationResult.IsValid = false;
                ValidationResult.Message = Resources.Resource_tr.ValidationInvalidEmail;
                return ValidationResult;
            }

            if (registerUser.Role.Equals("endUser") || registerUser.Role.Equals("Manager"))
            {
                return ValidationResult;
            }
            ValidationResult.IsValid = false;
            ValidationResult.Message = Resources.Resource_tr.Validation_RoleTypeError;

            return ValidationResult;
        }
    }


}