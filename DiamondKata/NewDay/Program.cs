using NewDay;

var helper = new DiamondHelper();
var diamondbuilder = new DiamondBuilder(helper);
for (char c = 'A'; c <= 'Z'; c++)
{
    Console.WriteLine("");
    Console.WriteLine($"---------------DIAMOND '{c}'---------------");
    Console.WriteLine("");

    foreach (var row in diamondbuilder.GetAllRows(c))
        Console.WriteLine(row);
}