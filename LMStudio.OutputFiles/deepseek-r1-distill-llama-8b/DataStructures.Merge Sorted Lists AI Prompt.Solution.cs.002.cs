var merger = Merger.New;
var result = merger.Add(new[] { 1, 3, 5 })
                 .Add(new[] { 2, 4, 6 })
                 .Add(null)
                 .Merge();

foreach (int num in result)
{
    Console.WriteLine(num);
}