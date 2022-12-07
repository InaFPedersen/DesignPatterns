using Bridge;

var noCoupon = new NoCoupon(); //Quick Action to insert using statement
var oneEuroCoupon = new OneEuroCoupon();

var meatBasedMenu = new MeatBasedMenu(noCoupon);
Console.WriteLine($"Meat based menu, no coupon: {meatBasedMenu.CalculatePrice()} euro.");

meatBasedMenu = new MeatBasedMenu(oneEuroCoupon);
Console.WriteLine($"Meat based menu, coupon: {meatBasedMenu.CalculatePrice()} euro.");

var vegetarianMenu = new VegetarianMenu(noCoupon);
Console.WriteLine($"Vegetarian menu, no coupon: {meatBasedMenu.CalculatePrice()} euro.");

vegetarianMenu = new VegetarianMenu(oneEuroCoupon);
Console.WriteLine($"Vegetarian menu, coupon: {meatBasedMenu.CalculatePrice()} euro.");

Console.ReadKey();
