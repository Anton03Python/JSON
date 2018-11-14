using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Serialization
{
    [DataContract]
    public class Clothes
    {
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public string Style { get; set; }
        [DataMember]
        public int Size { get; set; }
        [DataMember]
        public string Sex { get; set; }


        public Clothes(string color, string style, int size, string sex)
        {
            Color = color;
            Style = style;
            Size = size;
            Sex = sex;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Clothes thing1 = new Clothes("Blue", "Pants", 28, "Male");
            Clothes thing2 = new Clothes("Green", "Skirt", 25, "Female");
            Clothes thing3 = new Clothes("Red", "Jacket", 30, "Female");
            Clothes thing4 = new Clothes("Black", "T-shirt", 54, "Male");
            Clothes thing5 = new Clothes("White", "Shorts", 15, "Male");




            Clothes[] thing = new Clothes[] { thing1, thing2, thing3, thing4, thing5 };

            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Clothes[]));
            string json = JsonConvert.SerializeObject(thing, Formatting.Indented);


            File.WriteAllText("clother.json", json);

            //using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
            //{
            //    Clothes[] newthing = (Clothes[])jsonFormatter.ReadObject(fs);

            //    foreach (Clothes p in newthing)
            //    {
            //        Console.WriteLine("Цвет: {0} --- Фасон: {1} --- Размер: {2} --- Пол: {3}", p.Color, p.Style, p.Size, p.Sex);
            //    }
            //}
            Console.ReadLine();
        }
    }
}
