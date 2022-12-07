

using FactoryMethod;

var factories = new List<DiscountFactory> //Quick action to add using statement
{
    new CodeDiscountFactory(Guid.NewGuid()),
    new CountryDiscountFactory("NO")
};

foreach (var factory in factories)
{
    var discountService = factory.CreateDiscountService();
    Console.WriteLine($"Percentage {discountService.DiscountPercentage} " +
        $"coming from {discountService}");
}

Console.ReadKey();