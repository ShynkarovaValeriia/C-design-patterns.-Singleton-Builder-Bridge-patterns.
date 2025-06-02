using System;

namespace Lab9
{
    interface IMessageType
    {
        void FormatMessage(string text);
    }

    class TextMessage : IMessageType
    {
        public void FormatMessage(string text)
        {
            Console.WriteLine("Текст: " + text);
        }
    }

    class HtmlMessage : IMessageType
    {
        public void FormatMessage(string text)
        {
            Console.WriteLine("HTML: " + "<html><body>" + text + "</body></html>");
        }
    }

    abstract class MessageSend
    {
        protected IMessageType message;

        public MessageSend(IMessageType m)
        {
            message = m;
        }

        public void SetMessage(IMessageType m)
        {
            message = m;
        }

        public abstract void Send(string text);
    }

    class Email : MessageSend
    {
        public Email(IMessageType m) : base(m) { }

        public override void Send(string text)
        {
            Console.WriteLine("Електронна пошта:");
            message.FormatMessage(text);
        }
    }

    class Sms : MessageSend
    {
        public Sms(IMessageType m) : base(m) { }

        public override void Send(string text)
        {
            Console.WriteLine("SMS:");
            message.FormatMessage(text);
        }
    }

    interface IDevice
    {
        void Action();
    }

    class TV : IDevice
    {
        public void Action()
        {
            Console.WriteLine("Телевізор працює");
        }
    }

    class Radio : IDevice
    {
        public void Action()
        {
            Console.WriteLine("Радіо працює");
        }
    }

    abstract class Remote
    {
        protected IDevice device;

        public Remote(IDevice d)
        {
            device = d;
        }

        public void SetDevice(IDevice d)
        {
            device = d;
        }

        public abstract void Use();
    }

    class SimpleRemote : Remote
    {
        public SimpleRemote(IDevice d) : base(d) { }

        public override void Use()
        {
            Console.WriteLine("Простий пульт:");
            device.Action();
        }
    }

    class SmartRemote : Remote
    {
        public SmartRemote(IDevice d) : base(d) { }

        public override void Use()
        {
            Console.WriteLine("Розумний пульт:");
            device.Action();
            Console.WriteLine("Додаткові функції активовані");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MessageSend msg1 = new Email(new TextMessage());
            msg1.Send("текстовий формат");

            Console.WriteLine();

            MessageSend msg2 = new Sms(new HtmlMessage());
            msg2.Send("html формат");

            Console.WriteLine();

            Remote r1 = new SimpleRemote(new TV());
            r1.Use();

            Console.WriteLine();

            Remote r2 = new SmartRemote(new Radio());
            r2.Use();

            Console.ReadLine();
        }
    }
}
