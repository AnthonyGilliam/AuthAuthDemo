using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthAuthDemo.Web.CustomAttributes
{
    /// <summary>
    /// Sets a model property as required when another property is NOT equal to given notEqualToValue
    /// </summary>
    public class RequiredWhenNotAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly ValidationAttribute _requireAttribute;

        public RequiredWhenNotAttribute(string dependingOnPropertyName, object notEqualToValue, string errorMessage = null)
        {
            _requireAttribute = new RequiredAttribute();
            DependingOnProperty = dependingOnPropertyName;
            NotEqualToValue = notEqualToValue;
            ErrorMessage = errorMessage;
        }

        public string DependingOnProperty { get; set; }
        public object NotEqualToValue { get; set; }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = ErrorMessage ?? FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "requiredwhennot"
            };

            var validatingPropName = metadata.PropertyName;
            var dependentPropId = ((ViewContext)context).ViewData.TemplateInfo.GetFullHtmlFieldId(DependingOnProperty);
            if (dependentPropId.StartsWith(validatingPropName))
                dependentPropId = dependentPropId.Substring(validatingPropName.Length);

            rule.ValidationParameters.Add("dependingonproperty", dependentPropId);
            rule.ValidationParameters.Add("notequalto", NotEqualToValue);

            yield return rule;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var modelType = validationContext.ObjectType;
            var dependingOnPropInfo = modelType.GetProperty(DependingOnProperty);

            //Return valid if the Depending On property doesen't exist in the model
            if (dependingOnPropInfo == null)
                return ValidationResult.Success;

            var dependentValue = dependingOnPropInfo.GetValue(validationContext.ObjectInstance, null);

            if (NotEqualToValue == null && dependentValue != null ||
                 NotEqualToValue != null && !NotEqualToValue.Equals(dependentValue))
                return _requireAttribute.IsValid(value)
                    ? ValidationResult.Success
                    : new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });

            return ValidationResult.Success;
        }
    }
}