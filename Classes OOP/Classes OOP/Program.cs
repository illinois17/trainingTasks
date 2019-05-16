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
            Mascott myWorkCar = new Mascott(3.0, 16); myFirstCar.Beep();
            myFirstCar.ShowInfo();
            Console.WriteLine(Renault.Counter);
            myWorkCar.ShowInfo();
            Console.ReadLine();
        }

        class Mascott : Renault
        {
            public Mascott()
            {
                Model = "Mascott";
                engineCapacity = 3.0;
                wheel = 16;
            }

            public Mascott(double myEngineCapacity, int myWheel) : base(myEngineCapacity, myWheel)
            {
                Model = "Mascott";
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
            public Sandero()
            {
                Model = "Sandero";
                engineCapacity = 1.6;
                wheel = 14;
            }

            public Sandero(double myEngineCapacity, int myWheel) : base(myEngineCapacity, myWheel)
            {
                Model = "Sandero";
            }
        }

        abstract class Renault : ICar
        {
            public const string mark = "Renault";
            protected double engineCapacity;
            protected DateTime issue;
            protected int wheel;

            protected Renault()
            {
                Counter++;
                this.issue = DateTime.Now;
            }

            protected Renault(double myEngineCapacity, int myWheel) :this()
            {
                engineCapacity = myEngineCapacity;
                wheel = myWheel;
            }

            public static int Counter { get; private set; } = 0;
            protected string Model { get; set; }

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
                    $"Марка и модель автомобиля: {mark} {Model}\nРадиус колёс:{this.wheel}; Объём двигателя{this.engineCapacity}\nДата выпуска:{this.issue}");
            }

        }

        interface ICar
        {
            void Drive();
            void Beep();
        }
    }
}
