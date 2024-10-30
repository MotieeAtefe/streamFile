using System.Collections;
using System.IO;
using System.Linq.Expressions;

namespace streamFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\c# practices\streamFile\StudentInfo.txt";
            List<Students> students=Students.ReadStudentsFromFile(path);
       
            //foreach (var student in students)
            //{
            //    Console.WriteLine(student);
            //}
            HashSet<Students> stdHash = new HashSet<Students>(students);
           
            foreach (var student in stdHash)
            {
                Console.WriteLine(student);
            }

        }
    }
}
