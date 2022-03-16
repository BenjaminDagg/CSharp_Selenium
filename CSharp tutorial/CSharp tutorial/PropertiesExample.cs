using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * ========= Properties ===============
 * -named members of a class, struct, interface
 * - member variables/methods in a class are called fields
 * - properties are extensions of fields- use accessors to access values of private fields to read/write
 * - properties have accessors to read/write/compute storege location values
 * - allow you to access private fields from outside of class scope
 * - accessor can be set or get or both
 * - get { return [variable_name]; }
 * - set { [variable_name] = value; }
 * ======== Abstract properties ===========
 * - abstract class can have abstract properties which must be implemented in derived class
 */
namespace CSharp_tutorial
{
    abstract class APerson
    {
        //abstract property
        public abstract string Gender { get; set; }
    }

    class Student : APerson
    {
        private string code = "N/A";
        private string name = "unknown";
        private int age = 0;
        private string gender;

        //Code property of type string for code field
        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        //code property of type string for name field
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        //age property of type int for field age
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        //implement abstract property gender
        public override string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public override string ToString()
        {
            
            return "Code: " + Code + ", Name: " + Name + ", age: " + Age + ", Gender: " + Gender;
        }

    }

    class PropertiesExample
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Properties: ");
            Student student = new Student();

            //using set property of Code, Name, Age
            student.Code = "0001";
            student.Name = "Ben Dagg";
            student.Age = 26;
            student.Gender = "male";

            student.Age++;

            Console.WriteLine(student.ToString());
        }
    }
}
