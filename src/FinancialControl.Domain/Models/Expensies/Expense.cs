using FinancialControl.Domain.Base;
using System;

namespace FinancialControl.Domain.Models.Expensies
{
    public class Expense : Entity
    {
        public const int CategoryMaxLength = 128;
        public const int DescriptionMaxLength = 256;

        public Expense(string category, string description, decimal value)
        {
            Category = category;
            CreationDate = DateTime.Now;
            Description = description;
            Value = value;

            ValidateCategory();
            ValidateDescription();
            ValidateValue();
        }

        protected Expense()
        {
        }

        public string Category { get; private set; }

        public DateTime CreationDate { get; private set; }

        public string Description { get; private set; }

        public decimal Value { get; private set; }

        public void SetCategory(string category)
        {
            Category = category;
            ValidateCategory();
        }

        public void SetDescription(string description)
        {
            Description = description;
            ValidateDescription();
        }

        public void SetValue(decimal value)
        {
            Value = value;
            ValidateValue();
        }

        private void ValidateCategory()
        {
            if (string.IsNullOrWhiteSpace(Category))
            {
                AddError("Inform the category.");
                return;
            }

            if (Category.Length > CategoryMaxLength)
                AddError($"The maximum number of characters in the category is {CategoryMaxLength}.");
        }

        private void ValidateDescription()
        {
            if (string.IsNullOrWhiteSpace(Description))
            {
                AddError("Inform the description.");
                return;
            }

            if (Description.Length > DescriptionMaxLength)
                AddError($"The maximum number of characters in the description is {DescriptionMaxLength}.");
        }

        private void ValidateValue()
        {
            if (Value == default)
                AddError("Value must be greater than zero.");
        }
    }
}