using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Online_Store.Models;
using System.ComponentModel.DataAnnotations;

namespace Online_Store.CustomAttributes
{
    public class UniqueUserUsername : ValidationAttribute, IClientValidatable
    {
        StoreContext db;
        public UniqueUserUsername()
        {
            db = new StoreContext();
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                var user = db.Users.Where(u => u.Username == (string)value).FirstOrDefault();
                if(user == null)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("This username is used");
                }
            }
            return new ValidationResult("no username found");
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
