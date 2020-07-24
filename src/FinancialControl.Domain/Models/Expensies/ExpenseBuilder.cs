namespace FinancialControl.Domain.Models.Expensies
{
    public class ExpenseBuilder
    {
        private string Category;
        private string Descirption;
        private decimal Value;

        public Expense Build() => new Expense(Category, Descirption, Value);

        public ExpenseBuilder WithCategory(string category)
        {
            Category = category;
            return this;
        }

        public ExpenseBuilder WithDescription(string description)
        {
            Descirption = description;
            return this;
        }

        public ExpenseBuilder WithValue(decimal value)
        {
            Value = value;
            return this;
        }
    }
}