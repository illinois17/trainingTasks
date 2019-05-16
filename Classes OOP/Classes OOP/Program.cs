using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Sandero myFirstCar = new Sandero(1.6, 14);
            Sandero mySecondCar = new Sandero(1.4, 14);
            //Mascott myWorkCar = new Mascott();
            myFirstCar.Beep();
            myFirstCar.ShowInfo();
            Console.WriteLine(Renault.Counter);
            //myWorkCar.ShowInfo();
            Console.ReadLine();
        }

        class Mascott : Renault
        {
            private static string model = "Mascott";
            private double engineCapacity = 1.6;
            private int wheel = 14;

            public Mascott()
            {
                model = "Mascott";
                engineCapacity = 3.0;
                wheel = 16;
            }

            public Mascott(double myEngineCapacity, int myWheel) : base(myEngineCapacity, myWheel)
            {
                model = "Mascott";
            }

            public override void Drive()
            {
                Console.WriteLine("WrOOOOm");
            }

            public override void Beep()
            {
                Console.WriteLine("BOOP");
            }
        }

        class Sandero : Renault
        {
            public static string model;
           

            public Sandero()
            {
                model = "Sandero";
                engineCapacity = 1.6;
                wheel = 14;
            }

            public Sandero(double myEngineCapacity, int myWheel) : base(myEngineCapacity, myWheel)
            {
                model = "Sandero";
            }
        }

        abstract class Renault : ICar
        {
            protected static readonly string Mark = "Renault";
            protected static string model;
            protected double engineCapacity;
            protected DateTime issue;
            protected int wheel;

            protected Renault()
            {
                Counter++;
                this.issue = DateTime.Now;
            }

            public Renault(double myEngineCapacity, int myWheel)
            {
                Counter++;
                engineCapacity = myEngineCapacity;
                wheel = myWheel;
                this.issue = DateTime.Now;
            }

            public static int Counter { get; private set; } = 0;

            public virtual void Drive()
            {
                Console.WriteLine("Wreeeeem");
            }

            public virtual void Beep()
            {
                Console.WriteLine("beep");
            }

            public void ShowInfo()
            {
                Console.WriteLine(
                    $"Марка и модель автомобиля: {Mark}{model}\nРадиус колёс:{this.wheel}; Объём двигателя{this.engineCapacity}\nДата выпуска:{this.issue}");
            }

        }

        interface ICar
        {
            void Drive();
            void Beep();
        }
    }
}
