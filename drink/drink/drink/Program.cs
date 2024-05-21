using System.Reflection;

namespace drink
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();

            using StreamReader sr = new StreamReader(@"..\..\..\src\drink.txt");
            _ = sr.ReadLine();

            int citizenId = 1;
            while (!sr.EndOfStream)
            {
                citizens.Add(new Citizen(sr.ReadLine(), citizenId));
                citizenId++;
            }

            //5. feladat
            Console.WriteLine("5. feladat");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(citizens[i]);
            }
            //5. feladat vége

            //6. feladat
            Console.WriteLine("6. feladat");
            var f6 = citizens.Where(c => c.Drinking == true && c.NationalityName == "Birthright citizen" && c.State == "Florida" && c.Gender == true && c.NetIncome != "Refused" && c.NetIncome != "Unknown" && c.NetIncome != "Under 1800" && c.NetIncome != "Above 32400").ToList();

            if (f6.Count > 0)
            {
                foreach (var item in f6)
                {
                    Console.WriteLine(item);
                }

                var min = f6.Min(f => int.Parse(f.NetIncome.Split("to")[0].Trim()));

                Console.WriteLine($"A kiválogatott állampolgárok lehető legkisebb jövedelme USA dollárban: {min}");
            }
            //6. feladat vége

            //7. feladat
            var f7 = citizens.Where(c => (c.Age >= 18 && c.Age <= 65) && c.PopulationGroupName == "Asian" && c.Drinking == true).OrderBy(c => c.State).ToList();
            using StreamWriter sw = new StreamWriter(@"..\..\..\src\asian.txt");
            Console.WriteLine("7. feladat: fájlba írás");
            foreach (var item in f7)
            {
                sw.WriteLine($"{item.Age},{item.State},{item.SchoolDropout}");
            }
            //7. feladat vége

            Console.ReadLine();
        }
    }
}