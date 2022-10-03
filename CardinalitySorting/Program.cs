//List<int> nums = new List<int>() { 20, 8 };

//foreach (var num in nums)
//{
//    Console.WriteLine(Convert.ToString(num, 2));
//    Console.WriteLine(Convert.ToString(num, 2).Count(n => n.Equals('1')));
//    Console.WriteLine("---");
//}

List<int> nums = new List<int>() { 1, 2, 5, 4, 3 };

List<StructOne> structOneList = nums.Select(a => new StructOne() { num = a }).ToList();

List<int> numsDone = structOneList.OrderBy(o => o.binaryCardinality).ThenBy(o => o.num).Select(sol => sol.num).ToList();

foreach (var sol in structOneList)
{
    Console.WriteLine(sol.num);
    Console.WriteLine(sol.numBaseTwo);
    Console.WriteLine(sol.binaryCardinality);
    Console.WriteLine("-----");
}

Console.WriteLine("-----");
Console.WriteLine("-----");

foreach (var num in numsDone)
{
    Console.WriteLine(num);
}

public class StructOne
{
    public int num { get; set; }
    public string numBaseTwo => Convert.ToString(num, 2);
    public int binaryCardinality => numBaseTwo.Count(c => c.Equals('1'));
}