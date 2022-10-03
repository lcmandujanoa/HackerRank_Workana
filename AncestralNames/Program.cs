
List<string> names = new List<string>() { "Steven XL", "Steven XVI", "David IX", "Mary XV", "Mary XIII", "Mary XX" };

List<StructTwo> structTwoList = names.Select(n => new StructTwo() { comprisedName = n, name = n.Split(" ")[0], romanNumber = n.Split(" ")[1] }).ToList();

List<string> namesDone = structTwoList.OrderBy(o => o.name).ThenBy(o => o.decimalNumber).Select(s => s.comprisedName).ToList(); 

//foreach (var stl in structTwoList)
//{
//    Console.WriteLine(stl.name);
//    Console.WriteLine(stl.romanNumber);
//    Console.WriteLine(stl.decimalNumber);
//    Console.WriteLine("---");
//}

foreach (var nd in namesDone)
{
    Console.WriteLine(nd);
}


class StructTwo
{
    public string comprisedName { get; set; }
    public string name { get; set; }
    public string romanNumber { get; set; }
    public int decimalNumber => romanToDecimal(romanNumber);

    private int romanToDecimal(string str)
    {
        Dictionary<char, int> dic = new Dictionary<char, int>()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 }
        };

        int res = 0;

        for (int i = 0; i < str.Length; i++)
        {
            int s1 = dic[str[i]];

            if (i + 1 < str.Length)
            {
                int s2 = dic[str[i + 1]];

                if (s1 >= s2)
                {
                    res = res + s1;
                }
                else
                {
                    res = res + s2 - s1;
                    i++;
                }
            }
            else
            {
                res = res + s1;
            }
        }
        return res;
    }

}
