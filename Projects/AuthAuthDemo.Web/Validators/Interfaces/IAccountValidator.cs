using System.Web.Mvc;
using AuthAuthDemo.Web.Models;

namespace AuthAuthDemo.Web.Validators
{
    public interface IAccountValidator
    {
        bool Validate(ModelStateDictionary modelState, RegisterViewModel viewModel);
    }
}