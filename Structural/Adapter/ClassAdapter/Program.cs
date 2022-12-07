
using ClassAdapter;

ICityAdapter adapter = new CityAdapter(); //Quick action to import using statement
var city = adapter.GetCity();

Console.WriteLine($"{city.FullName}, {city.Inhabitants}");

Console.ReadKey();

