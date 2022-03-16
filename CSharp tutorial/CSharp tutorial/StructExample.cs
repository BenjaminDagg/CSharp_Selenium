using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Struct is value data type
 * single variable that holds multiple different data types
 * - defined with struct keyword
 * - used to represent a record (ie a book)
 * - typically used when the object needs little to no behavior (if you nedd behavior use a class)
 * - you cant define a paramaterless constructor becuse struct already has a default constructure by default that initialez members to default values
 */ 
namespace CSharp_tutorial
{
    /*
     * Struct defines a new data type that you can use to define variables
     */
    struct Book
    {
        public string title;
        public string author;
        public int id;

        //structs can have methods
        public void setValues(string t, string a, int i)
        {
            title = t;
            author = a;
            id = i;
        }

        public void print()
        {
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Author: " + author);
            Console.WriteLine("Id: " + id);
        }
    };

    /*
     * Use readonly property to make immutable struct and ensure all members are read only
     */
    public readonly struct ReadonlyBook
    {
        //parameterless constructor
        //default keyword ignores the parameterless constructor and produces default values 
        public ReadonlyBook()
        {
            id = -1;
            title = "Deafault";
        }

        public ReadonlyBook(string title, int i)
        {
            this.title = title;
            this.id = i;
        }

        //uses defautl title in delcaration for title field
        public ReadonlyBook(int id)
        {
            this.id = id;
        }
        

        public void print()
        {
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Id: " + id);

        }

        public string title { get; init; } = "Default title"; //initialize propert at declareation
        public int id { get; init; }
    }

    // if field initializers are used compiler produces parameterless constructor
    public struct BookWithFieldInitializers
    {
        public BookWithFieldInitializers()
        {

        }

        public string title = "Default title";
        public int id = -1;

        public void print()
        {
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Id: " + id);

        }
    }

    /*
     * If all instance fields of struct are accessible youu can instantiate the struct without using new
     */
    public struct CoordStructWithoutNew
    {
        public int x;
        public int y;
    }

    /*
     * Ref struct
     */
    public ref struct RefStruct
    {
        public int x;
    }
    

    class StructExample
    {
        /*
         * When struct is passed as parameter to method or returned from method the whole struct instance
         * is copied (by value)
         */
        public static void structIsPassedByValue(CoordStructWithoutNew coord)
        {
            coord.x = 100;
        }

        public static void structReference(RefStruct r)
        {
            r.x = 200;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("===== Structs =======");

            //declare structure
            //new operator now used, fields are unassigned
            Book book1;
            //struct can be initialized with new operator
            Book book2 = new Book(); //calls default constructor

            book1.title = "Test title";
            Console.WriteLine("Book1 title: " + book1.title);

            //call struc method
            book2.setValues("book2 title", "Ben Dagg", 2);
            book2.print();

            //with expression creates copy of structure type instance with the specified members modified
            ReadonlyBook rb1 = new ReadonlyBook("Read only",3);
            ReadonlyBook rb2 = rb1 with { title = "Ready only 2" };
            rb2.print();

            // uses default title from declaration
            ReadonlyBook rb3 = new ReadonlyBook(4); // uses default title from declaration
            rb3.print();
            //uses default constructor i made
            ReadonlyBook rb4 = new ReadonlyBook();
            rb4.print();
            //default ignores parameterless constructor
            ReadonlyBook rb5 = default(ReadonlyBook);
            rb5.print();

            //If all instance fields of struct are accessible youu can instantiate the struct without using new
            CoordStructWithoutNew coord;
            coord.x = 1;
            coord.y = 2;
            Console.WriteLine("Instantiated coord without new to {0},{1}",coord.x,coord.y);

            //struct is passed to method by value (not modified)
            structIsPassedByValue(coord);
            Console.WriteLine("Coord after passing by value {0},{1}", coord.x, coord.y);

            //ref struct
            RefStruct rs = new RefStruct();
            rs.x = 100;
            structReference(rs);
            Console.WriteLine("Struct after ref = " + rs.x);

        }
    }
}
