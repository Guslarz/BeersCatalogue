using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Kaczmarek.BeersCatalogue.Ui.ViewModel
{
    public class ValidatableViewModel : ViewModel, INotifyDataErrorInfo
    {
        private IDictionary<string, ICollection<string>> _validationErrors;
        private bool _isDirty;

        public bool HasErrors => _validationErrors.Count > 0;
        public bool IsDirty
        {
            get => _isDirty;
            set
            {
                _isDirty = value;
                NotifyProperyChanged();
            }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public ValidatableViewModel()
        {
            _validationErrors = new Dictionary<string, ICollection<string>>();
            _isDirty = false;
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || !_validationErrors.ContainsKey(propertyName))
            {
                return null;
            }
            return _validationErrors[propertyName];
        }

        protected override void NotifyProperyChanged([CallerMemberName] string propertyName = "")
        {
            base.NotifyProperyChanged(propertyName);
            if (propertyName != nameof(HasErrors) && propertyName != nameof(IsDirty))
            {
                Validate();
                if (!IsDirty)
                {
                    IsDirty = true;
                }
            }
        }

        protected void NotifyDataErrorInfo(string propertyName)
        {
            if (propertyName != null)
            {
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }
            NotifyProperyChanged(nameof(HasErrors));
        }

        private void Validate()
        {
            var validationContext = new ValidationContext(this, null, null);
            var validationResults = new List<ValidationResult>();

            Validator.TryValidateObject(this, validationContext, validationResults, true);
            SetValidationResults(validationResults);
        }

        private void SetValidationResults(IEnumerable<ValidationResult> results)
        {
            var groupedResults = GroupValidationResults(results);

            foreach (var key in _validationErrors.Keys.ToList())
            {
                if (!groupedResults.ContainsKey(key))
                {
                    _validationErrors.Remove(key);
                    NotifyDataErrorInfo(key);
                }
            }

            foreach (var entry in groupedResults)
            {
                var key = entry.Key;
                var messages = entry.Value;

                _validationErrors[key] = messages;

                NotifyDataErrorInfo(key);
            }
        }

        private Dictionary<string, List<string>> GroupValidationResults(IEnumerable<ValidationResult> results)
        {
            return results
                .SelectMany(result => Enumerable
                    .Range(0, result.MemberNames.Count())
                    .Select(i => Tuple.Create(result.MemberNames.ElementAt(i), result.ErrorMessage)))
                .GroupBy(t => t.Item1, t => t.Item2)
                .ToDictionary(g => g.Key, g => g.ToList());
        }
    }
}
