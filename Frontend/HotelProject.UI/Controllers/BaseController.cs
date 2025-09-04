using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HotelProject.UI.Controllers
{
    public abstract class BaseController : Controller
    {
        protected async Task<bool> ValidateAsync<T>(
      T model,
      IValidator<T> validator,
      ModelStateDictionary? modelState = null)
        {
            var result = await validator.ValidateAsync(model);

            if (!result.IsValid && modelState != null)
            {
                foreach (var error in result.Errors)
                {
                    modelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }

            return result.IsValid;
        }
    }
}
