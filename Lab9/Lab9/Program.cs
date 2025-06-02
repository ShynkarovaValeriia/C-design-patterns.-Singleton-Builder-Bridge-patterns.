/* using System;

namespace Lab9
{
    public class Singlton
    {
        private static Singlton _instance;

        private Singlton()
        {

        }

        public static Singlton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singlton();
            }
            return _instance;
        }

        public void First()
        {
            Console.WriteLine("Hello I'm singleton");
        }

        public void Second()
        {
            Console.WriteLine("Hello you second");
        }

        static void Main(string[] args)
        {
            Singlton.GetInstance().First();
            Singlton.GetInstance().Second();

            Singlton s = Singlton.GetInstance();
            Singlton b = Singlton.GetInstance();

            if (s == b)
            {
                Console.WriteLine("Вони рівні, отже, екземпляр один");
            }

            Console.ReadLine();
        }
    }
}
*/
/*
using Lab9;
using System;

namespace Lab9
{
    public enum chassis
    {
        caterpillar,
        wheeled
    }

    public class Tank
    {
        public int gunCaliber;
        public double bodyLength;
        public double bodyWidth;
        public chassis chassis;

        public void WriteConsole()
        {
            Console.WriteLine("Калібр гармати: " + gunCaliber);
            Console.WriteLine("Довжина корпусу: " + bodyLength);
            Console.WriteLine("Ширина корпусу: " + bodyWidth);
            Console.WriteLine("Тип шасі: " + chassis);
            Console.WriteLine();
        }
    }

    public interface ITanckConstrukt
    {
        void CreateGun();
        void CreateBody();
        void CreateChassis();
        Tank GetTank();
    }

    public class Leopard2Developer : ITanckConstrukt
    {
        private Tank tank;

        public Leopard2Developer()
        {
            tank = new Tank();
        }

        public void CreateGun()
        {
            tank.gunCaliber = 120;
        }

        public void CreateBody()
        {
            tank.bodyLength = 7.70;
            tank.bodyWidth = 3.70;
        }

        public void CreateChassis()
        {
            tank.chassis = chassis.caterpillar;
        }

        public Tank GetTank()
        {
            return tank;
        }
    }

    public class Director
    {
        ITanckConstrukt developer;

        public Director(ITanckConstrukt developer)
        {
            this.developer = developer;
        }

        public void SetDeveloper(ITanckConstrukt tanckConstruktDeveloper)
        {
            this.developer = tanckConstruktDeveloper;
        }

        public Tank CreateFullTank()
        {
            developer.CreateGun();
            developer.CreateBody();
            developer.CreateChassis();
            return developer.GetTank();
        }

        public Tank CreateOnlyBody()
        {
            developer.CreateBody();
            return developer.GetTank();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ITanckConstrukt developerLeopard = new Leopard2Developer();

            Director director = new Director(developerLeopard);

            Tank leopard2 = director.CreateFullTank();

            Console.WriteLine("Танк 1:");
            leopard2.WriteConsole();

            ITanckConstrukt developerLeopard_2 = new Leopard2Developer();

            director.SetDeveloper(developerLeopard_2);
            Tank leopard2OnlyBody = director.CreateOnlyBody();

            Console.WriteLine("Танк 2 (тільки корпус):");
            leopard2OnlyBody.WriteConsole();

            Console.ReadLine();
        }
    }
}
*/
/*
using System;

namespace Lab9
{
    interface Icolor
    {
        void FigureColor();
    }

    class ColorBlue : Icolor
    {
        public void FigureColor()
        {
            Console.WriteLine("Зафарбувати в синій колір.");
        }
    }

    class ColorGreen : Icolor
    {
        public void FigureColor()
        {
            Console.WriteLine("Зафарбувати в зелений колір.");
        }
    }

    abstract class CreateFigure
    {
        protected Icolor color;

        public CreateFigure(Icolor _color)
        {
            this.color = _color;
        }

        public void SetColor(Icolor _color)
        {
            this.color = _color;
        }

        public abstract void CFigure();
    }

    class Circle : CreateFigure
    {
        public Circle(Icolor icolor) : base(icolor)
        {
        }

        public override void CFigure()
        {
            color.FigureColor();
            Console.WriteLine("i'm circle");
        }
    }

    class Cube : CreateFigure
    {
        public Cube(Icolor icolor) : base(icolor)
        {
        }

        public override void CFigure()
        {
            color.FigureColor();
            Console.WriteLine("i'm cube");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            CreateFigure CircleFigure = new Circle(new ColorBlue());
            CircleFigure.CFigure();

            Console.WriteLine();

            CreateFigure CubeFigure = new Cube(new ColorGreen());
            CubeFigure.CFigure();

            Console.ReadLine();
        }
    }
}
*/