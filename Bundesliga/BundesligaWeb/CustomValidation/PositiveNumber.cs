using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BundesligaWeb.CustomValidation
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =false,Inherited =true)]
    public sealed class PositiveNumber:ValidationAttribute
    {
        public PositiveNumber()
        {
            ErrorMessage = "Score must be positive";
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            var errorMessage = FormatErrorMessage(context.ModelMetadata.GetDisplayName());
            MergeAttribute(context.Attributes, "data-val-positiveNumber", errorMessage);
        }


        private bool MergeAttribute(
       IDictionary<string, string> attributes,
       string key,
       string value)
        {
            if (attributes.ContainsKey(key))
            {
                return false;
            }
            attributes.Add(key, value);
            return true;
        }

        public override bool IsValid(object value)
        {
            var number = (int) value;
            return number>=0;
        }

      
    }
}
