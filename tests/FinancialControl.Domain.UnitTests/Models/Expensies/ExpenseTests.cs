using FinancialControl.Domain.Models.Expensies;
using Xunit;

namespace FinancialControl.Domain.UnitTests.Models.Expensies
{
    public class ExpenseTests
    {
        [Fact]
        public void Expense_MustContainErrorsWhenTheCategoryExceedCharacterLimit()
        {
            var expenseBuilder = new ExpenseBuilder()
                .WithCategory("testecommaisde128caracterestestecommaisde128caracterestestecommaisde128caracterestestecommaisde128caracterestestecommaisde128cara")
                .WithDescription("teste")
                .WithValue(0.01M);

            var expense = expenseBuilder.Build();

            Assert.True(expense.InValid);
        }

        [Fact]
        public void Expense_MustContainErrorsWhenTheCategoryIsEmpty()
        {
            var expenseBuilder = new ExpenseBuilder()
                .WithCategory("")
                .WithDescription("teste")
                .WithValue(0.01M);

            var expense = expenseBuilder.Build();

            Assert.True(expense.InValid);
        }

        [Fact]
        public void Expense_MustContainErrorsWhenTheCategoryIsNull()
        {
            var expenseBuilder = new ExpenseBuilder()
                .WithCategory(null)
                .WithDescription("teste")
                .WithValue(0.01M);

            var expense = expenseBuilder.Build();

            Assert.True(expense.InValid);
        }

        [Fact]
        public void Expense_MustContainErrorsWhenTheDescriptionExceedCharacterLimit()
        {
            var expenseBuilder = new ExpenseBuilder()
                .WithCategory("teste")
                .WithDescription("testecommaisde256caracterestestecommaisde256caracterestestecommaisde256caracterestestecommaisde256caracterestestecommaisde256caracterestestecommaisde256caracterestestecommaisde256caracterestestecommaisde256caracterestestecommaisde256caracterestestecommaisde")
                .WithValue(0.01M);

            var expense = expenseBuilder.Build();

            Assert.True(expense.InValid);
        }

        [Fact]
        public void Expense_MustContainErrorsWhenTheDescriptionIsEmpty()
        {
            var expenseBuilder = new ExpenseBuilder()
                .WithCategory("teste")
                .WithDescription("")
                .WithValue(0.01M);

            var expense = expenseBuilder.Build();

            Assert.True(expense.InValid);
        }

        [Fact]
        public void Expense_MustContainErrorsWhenTheDescriptionIsNull()
        {
            var expenseBuilder = new ExpenseBuilder()
                .WithCategory("teste")
                .WithDescription(null)
                .WithValue(0.01M);

            var expense = expenseBuilder.Build();

            Assert.True(expense.InValid);
        }

        [Fact]
        public void Expense_MustContainErrorsWhenTheValueIsEqualToZero()
        {
            var expenseBuilder = new ExpenseBuilder()
                .WithCategory("teste")
                .WithDescription("teste")
                .WithValue(0.00M);

            var expense = expenseBuilder.Build();

            Assert.True(expense.InValid);
        }

        [Fact]
        public void Expense_MustCreateExpense()
        {
            var expenseBuilder = new ExpenseBuilder()
                .WithCategory("teste")
                .WithDescription("teste")
                .WithValue(0.01M);

            var expense = expenseBuilder.Build();

            Assert.True(expense.Valid);
        }
    }
}