using Interpreter;

var expressions = new List<RomanExpression>
{
    new RomanHundredExpression(),
    new RomanTenExpression(),
    new RomanOneExpression(),
};

var context = new RomanContext(5);
foreach (var expression in expressions)
{
    expression.Interpret(context);
}
Console.WriteLine($"Translating Arabic numerals to Roman numerals: 5 = {context.Output}");

var context2 = new RomanContext(81);
foreach (var expression in expressions)
{
    expression.Interpret(context2);
}
Console.WriteLine($"Translating Arabic numerals to Roman numerals: 81 = {context2.Output}");

var context3 = new RomanContext(733);
foreach (var expression in expressions)
{
    expression.Interpret(context3);
}
Console.WriteLine($"Translating Arabic numerals to Roman numerals: 733 = {context3.Output}");

Console.ReadKey();

