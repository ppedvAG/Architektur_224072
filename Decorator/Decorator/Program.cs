// See https://aka.ms/new-console-template for more information
using Decorator;
using System.Linq.Expressions;
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("Hello, World!");

var brot1 = new Salami(new Brot());

Console.WriteLine($"Brot1 {brot1.Beschreibung} {brot1.Preis:c}");

var pizza1 = new Käse(new Salami(new Käse(new Pizza())));

Console.WriteLine($"Pizza1 {pizza1.Beschreibung} {pizza1.Preis:c}");
