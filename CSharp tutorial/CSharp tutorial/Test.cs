using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_tutorial
{
    struct MBook
    {
        public string title;
        public string author;
        public string subject;
        public int id;

        public MBook(string t, string a, string s, int i)
        {
            title = t;
            author = a;
            subject = s;
            id = i;
        }

        public void display()
        {
            Console.WriteLine("Title: {0}, Author: {1}, Subject: {2}, ID: {3}", title, author, subject, id);
        }
    }

    public delegate void CoordChanged(int n);
    struct Coordinate
    {
        private int x;
        private int y;

        
        public event CoordChanged CoordinateDidChange;
        
        public Coordinate(int a, int b)
        {
            x = a;
            y = b;
            CoordinateDidChange = null;
        }

        public int X
        {
            get { return x; }
            set 
            { 
                x = value;
                CoordinateDidChange(this.x);
            }
        }
        public int Y
        {
            get { return y; }
            set { y = value; CoordinateDidChange(this.y); }
        }

        public void setOrigin()
        {
            x = 0;
            y = 0;
        }

        public void display()
        {
            Console.WriteLine("{0},{1}", x, y);
        }

        public static Coordinate getOrding()
        {
            Coordinate temp = new Coordinate();
            temp.X = 0;
            temp.Y = 0;
            return temp;
        }
    }

    class BaseEx
    {
        public int x = 100;
    }

    class DerivedEx : BaseEx
    {
        public int y = 200;
    }

    class ADog
    {
        string name;
        string breed;
        int age;
        string color;

        public ADog(string n, string b, int a, string c)
        {
            name = n;
            breed = b;
            age = a;
            color = c;
        }

        public string getName()
        {
            return name;
        }

        public string getBreed()
        {
            return breed;
        }

        public int getAge()
        {
            return age;
        }

        public string getColor()
        {
            return color;
        }

        public override string ToString()
        {
            string output = String.Concat("Name: {0}, Breed: {1}, Age: {2}, Color: {3}", name, breed, age, color);
            return output;
        }
    }

    public class Geek
    {
        public int age;
        public string name;

        static Geek()
        {
            Console.WriteLine("static constructor");
        }

        public Geek()
        {
            Console.WriteLine("Constructor called");
        }

        public Geek(string n, int a)
        {
            name = n;
            age = a;
        }

        //copy constructor
        public Geek(Geek a)
        {
            this.name = a.name;
            this.age = a.age;
        }

        public void display()
        {
            Console.WriteLine("Name: {0}, Age: {1}",name, age);
        }
    }

    class Singleton
    {
        public static int count;
        private Singleton()
        {

        }

        public static int increment()
        {
            count++;
            return count;
        }
    }

    public class GFG
    {
        public string name;
        public string subject;
        private string fullName;

        public GFG()
        {
            Console.WriteLine("Base constructor");
        }

        public GFG(string n, string s)
        {
            Console.WriteLine("Base constructor");
            name =n;
            s=s;
            fullName = name + s;
        }

        public void readers(string n, string s)
        {
            name=n;
            subject=s;
            Console.WriteLine("name: {0}, subject: {1}", name, subject);
        }

        public string getFullName()
        {
            return fullName;
        }
    }

    public class GeeksForGeeks : GFG
    {
        int id;

        public GeeksForGeeks() 
        {
            Console.WriteLine("Derived class constructor");
        }

        public GeeksForGeeks(int id) : base("","")
        {
            Console.WriteLine("Derived class constructor");
            this.id = id;
            
        }

        public GeeksForGeeks(int id, string n, string s) : base(n, s)
        {
            Console.WriteLine("Derived class constructor");
            this.id = id;

        }

        public string getName()
        {
            return name;
        }
    }

    public abstract class An
    {
        public abstract void speak();
    }

    public class Do : An
    {
        public override void speak()
        {
            Console.WriteLine("bark");
        }
    }
    public class Cow : An
    {
        public override void speak()
        {
            Console.WriteLine("moo");
        }
    }
    public class MilkCow : Cow
    {
        public override void speak()
        {
            Console.WriteLine("milk");
        }
    }

    class BaseNotNew
    {
        public virtual void doWork() { Console.WriteLine("base do work"); }

    }

    class DerivedNotNew : BaseNotNew
    {
        public  new  void doWork() { Console.WriteLine("derived do work"); }
    }

    class CA
    {
        public virtual void print()
        {
            Console.WriteLine("A");
        }

        public void aOnly()
        {

        }
    }

    class CB : CA
    {
        public sealed override void print()
        {
            Console.WriteLine("B");
        }

        public void bOnly()
        {

        }
    }

    class CC : CB
    {
        public new void print()
        {
            Console.WriteLine("C");
        }
    }

    interface IMyFile
    {
        public string ReadFile();
        public void WriteFile(string text);

        public void OpenFile(string filename);
    }

    public class FileData : IMyFile
    {
        private string filedata;
        public string ReadFile()
        {
            return filedata;
        }

        //implicit implementation
        public void WriteFile(string text)
        {
            filedata = text;
        }

        //explicit implimentation
        void IMyFile.OpenFile(string filename)
        {
            Console.WriteLine("Opening " + filename);
        }

        public int getFileLength()
        {
            return filedata.Length;
        }
    }

    class Test
    {
        public static int? m;

        public static  void readFiles(IMyFile[] files)
        {
            Console.WriteLine("Reading files...........");
            Console.WriteLine("=======================");
            foreach(var file in files)
            {
                file.OpenFile("file.txt");
                file.WriteFile("writing to file");
                Console.WriteLine(file.ReadFile());

                FileData fileCast = (FileData)file;
                Console.WriteLine("file length: " + fileCast.getFileLength());

                Console.WriteLine("=======================");
            }
        }

        static void interfaceTest()
        {
            IMyFile file1 = new FileData();
            FileData file2 = new FileData();

            file1.WriteFile("test");
            file1.ReadFile();
            file1.OpenFile("text.txt");
            //file1.getFileLength(); error not defined in interface
            FileData fileDataCast = (FileData)file1;
            Console.WriteLine("lenth = " + fileDataCast.getFileLength());


           file2.WriteFile("test");
           file2.ReadFile();
           //file2.OpenFile("text2.txt"); //error because openfile explicity belongs to IMYFile
           IMyFile IFileCast = (IMyFile)file2;
           IFileCast.OpenFile("file3");

            IMyFile[] files = { file1, file2 };
            readFiles(files);
        }

        static void printer(CA a)
        {
            a.print();
            
        }

        static void polyExample()
        {
            CA a = new CA();
            CB b = new CB();
            CC c = new CC();

            CA ab = b;
            
            
        }

        static void inheritenceExample()
        {
            GeeksForGeeks g = new GeeksForGeeks();
            g.readers("ben", "c#");

            GeeksForGeeks g2 = new GeeksForGeeks(2,"ben","dagg");
            Console.WriteLine("name = " + g2.getName());
            Console.WriteLine("fullname = " + g2.getFullName());
        }

        static void classExample()
        {
            ADog dog = new ADog("Amy", "breed", 15, "brown");
            Console.WriteLine(dog.ToString());

            Geek geek1 = new Geek();
            Console.WriteLine("age: " + geek1.age);

            Geek geek2 = new Geek("ben",26);
            geek2.display();

            Geek geek3 = new Geek(geek2);
            geek3.display();

            Singleton.count = 1;
            Singleton.increment();
            Singleton.increment();
            Singleton.increment();
            Console.WriteLine("Count = " + Singleton.count);

        }

        static void onCoordChange(int newCoord)
        {
            Console.WriteLine("Coord changed to " + newCoord);
        }

        static void structExample()
        {
            //if you dont use new operator with a constructor all members are unassigned
            MBook book1;
            book1.title = "title1";
            book1.author = "Ben Dagg";
            book1.subject = "math";
            book1.id = 1000;

            //if you delcare struct w/ new operaotr it call constructor to initialze all members to default values
            MBook book2 = new MBook("title2", "Dagg Ben", "science", 1001);

            book1.display();
            book2.display();

            Coordinate point = new Coordinate(5,10);
            point.CoordinateDidChange += new CoordChanged(onCoordChange);
            point.X = 5; 
            point.Y = 5;
            Console.WriteLine("{0},{1}",point.X,point.Y);
            point.setOrigin();
            Console.WriteLine("{0},{1}", point.X, point.Y);
            point.X = 100;
            point.display();

            Coordinate originPoint = Coordinate.getOrding();
            originPoint.display();

            
            point.X = 200;
        }

        static void nullablesExample()
        {
            int? n = null;
            int? n2 = 5;
            int? n3;
            Console.WriteLine("n = " + n.GetValueOrDefault());
            n3 = n ?? n2;
            Console.WriteLine("n3 = " + n3);
            int z = n.GetValueOrDefault();
            Console.WriteLine("z = " + z);

            if (n.HasValue)
            {
                Console.WriteLine("n is not null: " + n);
            }
            else
            {
                Console.WriteLine("n is null");
            }

            int k = n ?? 5;
            Console.WriteLine("m = " + m);

            int? a = null;
            int b = 5;
            int? c = null;

            if(a < b)
            {
                Console.WriteLine("in");
            }
            else
            {
                Console.WriteLine("not");
            }

            if(Nullable.Compare(a,b) < 0)
            {
                Console.WriteLine("a is less than b");
            }
            if(Nullable.Compare(a,c) == 0)
            {
                Console.WriteLine("a = c");
            }

            int? d = 5;
            if (d is int val)
            {
                Console.WriteLine("d is not null: " + val);
                d = null;
            }
            else
            {
                Console.WriteLine("d is null");
            }
        }

        static dynamic add(dynamic a, dynamic b)
        {
            return a + b;
        }

        static void test(BaseEx b)
        {
            DerivedEx d = (DerivedEx)b;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Test");

            DerivedEx d = new DerivedEx();
            BaseEx b = d;
            Console.WriteLine("b is " + b.GetType());
            DerivedEx d2 = new DerivedEx();
            d2 = (DerivedEx)b;
            Console.WriteLine("d2 is " + d2.GetType());

            int i = 123;
            object o = i;
            o = 321;
            i = (int)o;
            Console.WriteLine("i = " + i);

            List<object> list = new List<object>();
            list.Add("string");
            list.Add(3.14);
            list.Add(false);
            list.Add(3);

            foreach(var item in list)
            {
                Console.WriteLine(item);
            }

            //nullablesExample();
            //structExample();
            //classExample();
            //inheritenceExample();
            //polyExample();
            interfaceTest();
        }
    }
}
