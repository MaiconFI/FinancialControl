namespace FinancialControl.Application.Tests.Commands.CreateResponse
{
    public class CreateExpenseCommandHandlerTests
    {
        //[Fact]
        //public async void Handler_ShouldCreateExpense()
        //{
        //    var context = GetContext();
        //    var repository = new ExpenseRepository(context);
        //    var mapper = GetMapper();

        //    var command = new CreateExpenseCommand()
        //    {
        //        Category = "Abastecimento",
        //        Description = "Posto perto de casa",
        //        Value = 150.0m
        //    };
        //    var commandHandler = new CreateExpenseCommandHandler(repository, mapper);

        //    var result = await commandHandler.Handle(command, CancellationToken.None);

        //    Assert.NotNull(result);
        //}

        //private FinancialControlContext GetContext()
        //{
        //    var options = new DbContextOptionsBuilder<FinancialControlContext>()
        //        .UseInMemoryDatabase("FinancialControl.Application.Tests").Options;
        //    return new FinancialControlContext(options, MockMediator());
        //}

        //private IMapper GetMapper()
        //{
        //    var mappingConfig = new MapperConfiguration(mc =>
        //    {
        //        mc.AddProfile(new FinancialControlApplicationProfile());
        //    });
        //    return mappingConfig.CreateMapper();
        //}
    }
}