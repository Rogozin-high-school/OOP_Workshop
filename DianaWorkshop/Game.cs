using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace DianaWorkshop
{
    public static class Game
    {
        public static Random random = new Random();
        public static int CurrentLevel = 0;
        public static string Username = null;
        public static string output;
        public static string Usercolor = "#000000";

        public static int inputNum = 0;
        public static string ReadLine()
        {
            if (levels[CurrentLevel].inputs == null || levels[CurrentLevel].inputs.Length <= inputNum)
            {
                WriteLine("Runtime Exception: Console.ReadLine(): There were not enough inputs for this level to continue.");
                return null;
            }
            form.outputWindow.Text += ">>> " + levels[CurrentLevel].inputs[inputNum] + "\r\n";
            return levels[CurrentLevel].inputs[inputNum++];
        }
        public static void WriteLine(object obj, params object[] args)
        {
            //Console.WriteLine(obj.ToString(), args);
            output += string.Format(obj.ToString(), args) + "\r\n";
            form.outputWindow.Text += string.Format(obj.ToString(), args) + "\r\n";
        }
        public static void Write(object obj, params object[] args)
        {
            //Console.WriteLine(obj.ToString(), args);
            output += string.Format(obj.ToString(), args);
            form.outputWindow.Text += string.Format(obj.ToString(), args);
        }


        public static Form1 form;
        public static Level[] levels = new Level[]
        {
            new Level(
                "http://presentit.co.il/OOP/lesson1.html",
                (x) => x.Trim().Equals("NissanQashqai2007"),
                (x) => x + "\n\npublic class Program{public static void Main(string[] args){ Car car = new Car(); car.Model = \"Qashqai\"; car.Company = \"Nissan\"; car.ProductionYear = 2007; Console.WriteLine(car.Company + car.Model + car.ProductionYear); }}",
                "// Write your code here:",
                "Try to go back and see how the Student class is written."
                ),
            new Level(
                "http://presentit.co.il/OOP/lesson2.html",
                x => !x.Contains("Runtime exception") && !x.Contains("Build errors:") && x.Contains("2005"),
                x => x,
                "class Car\n{\n\tpublic string Model;\n\tpublic string Company;\n\tpublic int ProductionYear;\n}\n\npublic class Program\n{\n\tpublic static void Main(string[] args)\n\t{\n\t\t\n\t}\n}",
                "Print the values using Console.WriteLine()"
                ),
            new Level(
                "http://presentit.co.il/OOP/lesson4.html",
                (x) => x.Contains("Vroom Vroom") && !x.Contains("Runtime exception") && !x.Contains("Build errors:") && !x.Trim().Equals("Vroom Vroom"),
                (x) => x + "\n\npublic class Program{public static void Main(string[] args){ Car car = new Car(); car.Model = \"Qashqai\"; car.Company = \"Nissan\"; car.ProductionYear = 2007; car.PrintDetails(); car.Drive(); }}",
                "class Car\n{\n\tpublic string Model;\n\tpublic string Company;\n\tpublic int ProductionYear;\n\t\n\tpublic void PrintDetails()\n\t{\n\t\n\t}\n}",
                "Use the example Bark() method to implement yours."
                ),
            new Level(
                "http://presentit.co.il/OOP/lesson5.html",
                (x) => x.Contains("Porsche") && x.Contains("Carrera GT") && x.Contains("2013") && !x.Contains("Runtime exception") && !x.Contains("Build errors:"),
                (x) => x,
                "class Car\n{\n\tpublic string Model;\n\tpublic string Company;\n\tpublic int ProductionYear;\n\t\n\tpublic void PrintDetails()\n\t{\n\t\tConsole.WriteLine(\"{0} {1}, year {2}\", Company, Model, ProductionYear);\n\t}\n\n\tpublic void Drive()\n\t{\n\t\tConsole.WriteLine(\"Vroom Vroom\");\n\t}\n}\n\npublic class Program\n{\n\tpublic static void Main(string[] args)\n\t{\n\t\t\n\t}\n}",
                "No hints available for this level."
                ),
            new Level(
                "http://presentit.co.il/OOP/lesson3.html",
                (x) => x.Contains("2005") && !x.Contains("1650"),
                (x) => x + "\n\npublic class Program{public static void Main(string[] args){ Car car = new Car(); car.SetProductionYear(2005); Console.WriteLine(car.GetProductionYear());  car.SetProductionYear(1650); Console.WriteLine(car.GetProductionYear()); }}",
                "class Car\n{\n\tpublic string Model;\n\tpublic string Company;\n\tpublic int ProductionYear;\n\n\tpublic void SetProductionYear(int year) \n\t{ \n\t\t// Put your code here:  \n\t}\n\tpublic int GetProductionYear() \n\t{ \n\t\t// Put your code here: \n\t}\n}",
                "No hints available for this level."
                ),
            new Level(
                "http://presentit.co.il/OOP/test1.html",
                (x) => x.ToUpper().Trim().EndsWith("STRENGTH"),
                (x) => x,
                "// Put your code here: \n\nclass Program\n{\n\tpublic static void Main(string[] args)\n\t{\n\t\t// Put your code here:\n\t}\n}",
                "No hints available for this level.",
                new string[] { "c", "8", "d", "8" }
                ),
            new Level(
                "http://presentit.co.il/OOP/lesson6.html",
                (x) => x.Contains("2001") && x.Contains("Renault") && x.Contains("X") && !x.Contains("Runtime exception") && !x.Contains("Build errors:"),
                (x) => x,
                "partial class Car\n{\n\tpublic string Model;\n\tpublic string Company;\n\tpublic int ProductionYear;\n\n\tpublic void PrintDetails()\n\t{\n\t\tConsole.WriteLine(\"{0} {1}, year {2}\", Company, Model, ProductionYear);\n\t}\n\n\tpublic Car(/* Complete this part */)\n\t{\n\t\t// Put your code here:\n\t}\n}\n\nclass Program\n{\n\tpublic static void Main(string[] args)\n\t{\n\t\tCar myCar = new Car();\n\t\tmyCar.Company = \"Renault\";\n\t\tmyCar.Model = \"Model X\";\n\t\tmyCar.ProductionYear = 2001;\n\t}\n}",
                "In the constructor, just assign Model = model (parameter), etc..."
                )
        };

        public static void InitLevel()
        {
            form.outputWindow.Text = "Output Window...";
            if (levels.Length <= CurrentLevel)
            {
                System.Windows.Forms.MessageBox.Show("There are no more levels currently. Stay tuned for more!");
                NotifyServer(Username, "<u>has finished the workshop!</u>", Usercolor);
                return;
            }
            Level cur = levels[CurrentLevel];
            form.webBrowser1.Url = new Uri(cur.instructionURL + "?a=5");
            form.TextArea.Text = cur.defaultCode;
        }

        public static string NotifyServer(string username, string ev, string color)
        {
            string html = string.Empty;
            string url = @"http://presentit.co.il/OOP/notify.php?user=" + System.Web.HttpUtility.UrlEncode(username) + "&event=" + System.Web.HttpUtility.UrlEncode(ev) + "&color=" + System.Web.HttpUtility.UrlEncode(color);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            return html;
        }

        public static void PlayLevel()
        {
            if (levels.Length <= CurrentLevel)
            {
                MessageBox.Show("There are no more levels currently. Stay tuned for more!");
                return;
            }
            Level cur = levels[CurrentLevel];
            string res = RunCode(cur);
        }

        public static void TestLevel()
        {
            if (levels.Length <= CurrentLevel)
            {
                MessageBox.Show("There are no more levels currently. Stay tuned for more!");
                return;
            }
            Level cur = levels[CurrentLevel];
            string res = RunCode(cur);
            if (cur.tester(res))
            {
                MessageBox.Show("Great! You have passed level " + CurrentLevel + "!");
                NotifyServer(Username, "has finished level " + CurrentLevel, Usercolor);
                CurrentLevel++;
                InitLevel();
            }
            else
            {
                MessageBox.Show("Seems like your code doesn't satisfy the level request... Try to see if there were errors in the console window.");
            }
        }

        public static string RunCode(Level current)
        {
            inputNum = 0;
            form.outputWindow.Text = "";
            output = "";
            
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters parameters = new CompilerParameters();
            string code = "using DianaWorkshop;namespace Workshop{" + current.producer(form.TextArea.Text) + "\r\nclass Console{public static void WriteLine(object pat, params object[] fill) { Game.WriteLine(pat, fill); } public static void Write(object pat, params object[] fill) { Game.Write(pat, fill); } public static string ReadLine() { return Game.ReadLine(); } }}";
            // True - memory generation, false - external file generation
            parameters.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            parameters.GenerateInMemory = true;
            // True - exe file generation, false - dll file generation
            parameters.GenerateExecutable = true;
            CompilerResults results = provider.CompileAssemblyFromSource(parameters, code);
            if (results.Errors.HasErrors)
            {
                StringBuilder sb = new StringBuilder();

                foreach (CompilerError error in results.Errors)
                {
                    if (error.ErrorNumber == "CS0017")
                    {
                        sb.AppendLine("You can't write a Main method here. Please write a Main method only when given one.");
                    }
                    else
                    {
                        sb.AppendLine(string.Format("Error ({0}): {1}", error.ErrorNumber, error.ErrorText));
                    }
                }

                Console.WriteLine("Build errors:");
                Console.WriteLine(sb.ToString());
                WriteLine(sb.ToString());
                return output;
            }

            Assembly assembly = results.CompiledAssembly;
            Type program = assembly.GetType("Workshop.Program");
            MethodInfo main = program.GetMethod("Main");

            try
            {
                main.Invoke(Activator.CreateInstance(program), new object[] { null });
            }
            catch (Exception e)
            {
                if (e is TargetInvocationException)
                {
                    Console.WriteLine("Runtime exception:\n" + e.InnerException);
                    WriteLine("Runtime exception:\n" + e.InnerException + "\n");
                }
                else
                {
                    Console.WriteLine("Runtime exception:\n" + e);
                    WriteLine("Runtime exception:\n" + e + "\n");
                }
            }

            return output;
        }
    }

    public class Level
    {
        public string instructionURL;
        public Predicate<string> tester;
        public Func<string, string> producer;
        public string defaultCode;
        public string hint;
        public string[] inputs;
        public Level(string iurl, Predicate<string> t, Func<string, string> pro, string code, string h, string[] inp = null)
        {
            instructionURL = iurl;
            producer = pro;
            tester = t;
            defaultCode = code;
            hint = h;
            inputs = inp;
        }
    }
}
