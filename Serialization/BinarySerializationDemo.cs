using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    [Serializable]
    class Student
    {
        public string Name { get; set; }
        public int RollNo { get; set; }
        public string Address { get; set; }
        public override string ToString()
        {
            return string.Format($"Name: {Name}\nRoll No: {RollNo}\nAddress: {Address}");
        }
    }
    class BinarySerializationDemo
    {
        static void Main(string[] args)
        {
            BinarySerialization();
        }
        private static void BinarySerialization()
        {
            Console.Write("Read or Write? (R/W): ");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "w")
                serialize();
            else
                deserialize();
        }

        private static void serialize()
        {
            Student s = new Student { Name = "Santwana", RollNo = 1, Address = "Delhi" };
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("Demo.bin", FileMode.OpenOrCreate, FileAccess.Write);
            bf.Serialize(fs, s);
            fs.Close();
        }

        private static void deserialize()
        {
            FileStream fs = new FileStream("Demo.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            Student s = bf.Deserialize(fs) as Student;
            Console.WriteLine(s.Name);
            Console.WriteLine(s.RollNo);
            Console.WriteLine(s.Address);
            fs.Close();
        }
    }
}
