using Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace ReactorControlSystem.Core.Helpers
{
    public abstract class NotifyDataErrorInfo : BindableBase, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public bool HasErrors => _errors.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                return _errors[propertyName];
            }
            return Enumerable.Empty<string>();
        }

        public void Validate(string propertyName, object propertyValue)
        {
            var results = new List<ValidationResult>();

            Validator.TryValidateProperty(
                propertyValue, 
                new ValidationContext(this) { MemberName = propertyName }, 
                results
            );

            if (results.Count > 0)
            {
                _errors[propertyName] = results.Select(result => result.ErrorMessage).ToList();
            }
            else
            {
                _errors.Remove(propertyName);
            }
        }
    }
}
