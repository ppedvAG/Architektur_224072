// See https://aka.ms/new-console-template for more information
using HalloBuilder;

Console.WriteLine("Hello, World!");

var meinSchrank = new Schrank.Builder()
                             .SetBöden(4)
                             .SetTüren(6)
                             .Create();

var meinSchrank2 = new Schrank.Builder()
                             .SetBöden(2)
                             .SetTüren(4)
                             .Create();
