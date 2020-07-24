using System.Collections.Generic;
using System.Linq;

namespace FinancialControl.Domain.Base
{
    public abstract class EntityError
    {
        private List<string> _errors;

        protected EntityError()
        {
            _errors ??= new List<string>();
        }

        public IReadOnlyCollection<string> Errors => _errors?.AsReadOnly();

        public bool InValid => _errors.Any();

        public bool Valid => !InValid;

        public void AddError(string error)
        {
            _errors.Add(error);
        }

        public void AddError(IEnumerable<string> errors)
        {
            foreach (var error in errors) AddError(error);
        }
    }
}