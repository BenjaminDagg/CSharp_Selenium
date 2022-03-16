using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;

/*
 * Reflection objects retreive type information at runtime
 * - give access to metadata of program and allow dynamically add types, values and objects to app
 * - view attribute information. MemberInfo object of System.Reflection lets you discover attributes of a class
 * - System.Reflection.MemberInfo info = typeof(MyClass)
 */
namespace CSharp_tutorial
{
    [AttributeUsage(AttributeTargets.All)]
    class HelpAttribute : System.Attribute
    {
        public readonly string Url; //positional parameter (esentail info)
        private string topic;       //names parameter      (optional info)

        public string Topic
        {
            get { return Topic; }
            set { Topic = value; }
        }

        public HelpAttribute(string u)
        {
            Url = u;
        }
    }

    [HelpAttribute("Info on the class MClass")]
    class MClass
    {

    }

    class ReflectionExample
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reflection: ");

            //memberinfo object is used to get attributes of a class
            System.Reflection.MemberInfo info = typeof(MClass);
            object[] attributes = info.GetCustomAttributes(true);

            for (int i= 0; i < attributes.Length; i++)
            {
                Console.WriteLine(attributes[i]);
            }

            MRectangle r = new MRectangle(5, 10);
            Type type = typeof(MRectangle);
            Object[] att = type.GetCustomAttributes(false);

            //getting class DebugInfo buggs
            foreach(Object o in att)
            {
                DebugInfo db = (DebugInfo)o;

                Console.WriteLine("Bug #: {0}, Dev: {1}, Reviewed: {2}, Message: {3}", db.BugNo, db.Developer, db.LastReview, db.Message);
            }

            //getting class method attributes
            foreach(MethodInfo m in type.GetMethods())
            {
                foreach (Object a in m.GetCustomAttributes(false))
                {
                    
                    DebugInfo d = (DebugInfo)a;
                    if(d != null)
                    {
                        Console.WriteLine("Bug #: {0}, Dev: {1}, Reviewed: {2}, Message: {3}, Method: {4}", d.BugNo, d.Developer, d.LastReview, d.Message, m.Name);
                    }
                    
                }
            }
        }
    }
}
