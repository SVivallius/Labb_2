using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    internal static class ItemManager
    {
        public static void AddAppliance(ref List<Appliance> list)
        {
            Console.Clear();
            Console.Write("Registrerar ny köksutrustning. För att avbryta, skriv \"avbryt\".\n" +
                "Ange typ av utrustning: ");
            string type = Console.ReadLine();

            if (type.ToLower() == "avbryt")
            {
                Console.WriteLine("Avbryter registrering. Tryck valfri tangent för att återgå.");
                Console.ReadKey();
                return;
            }

            Console.Write("Ange märke. Om okänd, lämna tom: ");
            string make = Console.ReadLine();
            Console.Write("Ange brukbart skick (Y/N): ");
            string condition = Console.ReadLine();

            if (make.Length == 0) list.Add(new Appliance(type, MenuManager.InterpretTrueFalse(condition)));
            else list.Add(new Appliance(type, make, MenuManager.InterpretTrueFalse(condition)));
        }

        public static void ListAppliance(List<Appliance> apps)
        {
            for(int i = 0; i < apps.Count; i++)
            {
                Console.WriteLine(apps[i].ToString());
            }
        }

        public static void LoadList(ref List<Appliance> appliances)
        {
            using (StreamReader sr = new StreamReader("AppList.dat"))
            {
                while (!sr.EndOfStream)
                {
                    if (sr.ReadLine() != null)
                    {
                        string storage = sr.ReadLine();
                        string[] tempData = storage.Split(new string[] { "###" }, StringSplitOptions.None);

                        switch (tempData.Length)
                        {
                            case 2: appliances.Add(new Appliance(tempData[0], MenuManager.InterpretTrueFalse(tempData[1]))); break;
                            case 3: appliances.Add(new Appliance(tempData[0], tempData[1], MenuManager.InterpretTrueFalse(tempData[2]))); break;
                        }
                    }
                    else break;
                }
                sr.Dispose();
            }
        }

        public static void SaveList(ref List<Appliance> appliances)
        {
            using (FileStream stream = new FileStream("AppList.dat", FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(stream))
                {
                    for (int i = 0; i < appliances.Count; i++)
                    {
                        sw.WriteLine(appliances[i].ToDataString());
                    }
                    sw.Dispose();
                }
                stream.Dispose();
            }
        }

        public static void SetCondition(ref List<Appliance> appliances)
        {
            bool resolved = false;
            while (!resolved)
            {
                Console.Clear();
                Console.Write("Ställ in skick för utrustning.\n" +
                    "Vilket index har varan? (endast numeriskt svar): ");
                int selection = MenuManager.Selection(appliances.Count());

                Console.Write(appliances[selection-1].ToString() + "\n" +
                    "Vill du ändra på utrustningens skick? (Y/N): ");


                // DU ÄR HÄR I ARBETET JUST NU.
            }
        }
    }

    class Appliance
    {
        protected string type;
        protected string? make;
        protected bool condition;

        public Appliance(string type, string make, bool condition)
        {
            this.type = type;
            this.make = make;
            this.condition = condition;
        }

        public Appliance(string type, bool condition)
        {
            this.type = type;
            this.condition = condition;
        }

        public override string ToString()
        {
            string collect = this.type;
            if (this.make != null) collect = collect + " av märket: " + this.make;
            collect = collect + "\n" +
                this.condition + "\n---------------------------";

            return collect;
        }

        public string ToDataString()
        {
            string saveData = this.type;
            if (this.make != null) saveData = saveData + "###" + this.make;
            saveData = saveData + "###" + this.condition;

            return saveData;
        }

        public void SetCondition(bool set)
        {
            this.condition = set;
        }
    }


}
