using System;
using System.Text;

namespace Lab9
{
    public class Character
    {
        public int strength;
        public int agility;
        public int intelligence;

        public void Print()
        {
            Console.WriteLine("Сила: " + strength);
            Console.WriteLine("Спритність: " + agility);
            Console.WriteLine("Інтелект: " + intelligence);
            Console.WriteLine();
        }
    }

    public interface ICharBuilder
    {
        void BuildStrength();
        void BuildAgility();
        void BuildIntelligence();
        Character GetCharacter();
    }

    public class Warrior : ICharBuilder
    {
        Character character;

        public Warrior()
        {
            character = new Character();
        }

        public void BuildStrength()
        {
            character.strength = 12;
        }

        public void BuildAgility()
        {
            character.agility = 5;
        }

        public void BuildIntelligence()
        {
            character.intelligence = 1;
        }

        public Character GetCharacter()
        {
            return character;
        }
    }

    public class Mage : ICharBuilder
    {
        Character character = new Character();

        public void BuildStrength()
        {
            character.strength = 2;
        }

        public void BuildAgility()
        {
            character.agility = 4;
        }

        public void BuildIntelligence()
        {
            character.intelligence = 10;
        }

        public Character GetCharacter()
        {
            return character;
        }
    }

    public class CharacterDirector
    {
        ICharBuilder builder;

        public CharacterDirector(ICharBuilder b)
        {
            builder = b;
        }

        public void SetBuilder(ICharBuilder b)
        {
            builder = b;
        }

        public Character Create()
        {
            builder.BuildStrength();
            builder.BuildAgility();
            builder.BuildIntelligence();
            return builder.GetCharacter();
        }
    }

    public class SimpleSqlBuilder
    {
        string sql = "";

        public void Select(string s)
        {
            sql += "select " + s + " ";
        }

        public void From(string t)
        {
            sql += "from " + t + " ";
        }

        public void Where(string w)
        {
            sql += "where " + w + " ";
        }

        public void OrderBy(string o)
        {
            sql += "order by " + o + " ";
        }

        public string GetQuery()
        {
            return sql.Trim();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ICharBuilder warriorBuilder = new Warrior();
            CharacterDirector director = new CharacterDirector(warriorBuilder);
            Character warrior = director.Create();

            Console.WriteLine("Воїн:");
            warrior.Print();

            ICharBuilder mageBuilder = new Mage();
            director.SetBuilder(mageBuilder);
            Character mage = director.Create();

            Console.WriteLine("Маг:");
            mage.Print();

            Console.WriteLine("Запит:");

            SimpleSqlBuilder sql = new SimpleSqlBuilder();
            sql.Select("*");
            sql.From("characters");
            sql.Where("intelligence > 5");
            sql.OrderBy("strength");

            Console.WriteLine(sql.GetQuery());

            Console.ReadLine();
        }
    }
}
