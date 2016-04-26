using System.Web.Mvc;
using AuthAuthDemo.Web.Models;

namespace AuthAuthDemo.Web.Validators
{
    public class AccountValidator : IAccountValidator
    {
        public bool Validate(ModelStateDictionary modelState, RegisterViewModel viewModel)
        {
            if (viewModel.Password != null && viewModel.Password.ToLower() == "password")
            {
                modelState.AddModelError("Password", "Your password is lame :-P");
            }

            return modelState.IsValid;
        }
    }
}