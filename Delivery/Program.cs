using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; //потому что у меня выводило (?) и силы интернета сказали сделать так. появились рубли
            Delivery standard = new StandardDelivery("Стандартная");
            Delivery express = new ExpressDelivery("Экспресс");
            Delivery international = new InternationalDelivery("Международная");

            decimal basePrice = 20m; //базовая стоимость

            standard.CalculatePrice(basePrice);
            express.CalculatePrice(basePrice);
            international.CalculatePrice(basePrice);

            Console.WriteLine(standard);
            Console.WriteLine(express);
            Console.WriteLine(international);

        }
    }

    public abstract class Delivery
    {
        protected string name;
        protected decimal price;

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название доставки не может быть пустым.");
                if (value.Length > 20)
                    throw new ArgumentException("Название не должно превышать 20 символов.");
                name = value;
            }
        }

        //только для чтения
        public decimal Price => price;

        protected Delivery(string name)
        {
            Name = name; 
        }

        public abstract decimal CalculatePrice(decimal basePrice);

        public override string ToString()
        {
            return $"Доставка: {Name}, стоимость: {Price:C}";
        }
    }

    //наследник: StandardDelivery
    public class StandardDelivery : Delivery
    {
        public StandardDelivery(string name) : base(name) { }

        public override decimal CalculatePrice(decimal basePrice)
        {
            price = basePrice * 1.0m;
            return price;
        }
    }

    //наследник: ExpressDelivery
    public class ExpressDelivery : Delivery
    {
        public ExpressDelivery(string name) : base(name) { }

        public override decimal CalculatePrice(decimal basePrice)
        {
            price = basePrice * 2.5m;
            return price;
        }
    }

    //наследник: InternationalDelivery
    public class InternationalDelivery : Delivery
    {
        public InternationalDelivery(string name) : base(name) { }

        public override decimal CalculatePrice(decimal basePrice)
        {
            price = basePrice * 4.0m;
            return price;
        }
    }
}
