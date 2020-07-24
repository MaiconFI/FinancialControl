using System;

namespace FinancialControl.Queries.Base
{
    public abstract class Model
    {
        protected Model(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}