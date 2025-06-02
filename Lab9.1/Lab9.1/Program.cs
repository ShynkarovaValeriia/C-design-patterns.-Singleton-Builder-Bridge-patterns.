using System;

namespace Lab9
{
    public class Singlton
    {
        private static Singlton _instance;
        public List<string> list = new List<string>();

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

        public void Add(string txt)
        {
            list.Add(DateTime.Now.ToString() + " - " + txt);
        }

        public void Show()
        {
            foreach (string l in list)
            {
                Console.WriteLine(l);
            }
        }
    }

    public class Settings
    {
        private static Settings s;
        public int width = 0;
        public int height = 0;
        public string lang = "";

        private Settings()
        {
            width = 800;
            height = 600;
            lang = "uk";
        }

        public static Settings GetInstance()
        {
            if (s == null)
            {
                s = new Settings();
            }
            return s;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Singlton.GetInstance().Add("Старт програми");
            Singlton.GetInstance().Add("Ініціалізація налаштувань");

            Settings.GetInstance().width = 1024;
            Settings.GetInstance().height = 768;
            Settings.GetInstance().lang = "en";

            Singlton.GetInstance().Add("Мова: " + Settings.GetInstance().lang);

            Console.WriteLine("Журнал:");
            Singlton.GetInstance().Show();

            Console.WriteLine("\nНалаштування:");
            Console.WriteLine("Ширина: " + Settings.GetInstance().width);
            Console.WriteLine("Висота: " + Settings.GetInstance().height);
            Console.WriteLine("Мова: " + Settings.GetInstance().lang);

            Console.ReadLine();
        }
    }
}