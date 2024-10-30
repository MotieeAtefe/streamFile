using System.Collections;
using System.IO;
using System.Linq.Expressions;

namespace streamFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Students> listStudents = new List<Students>();
            Hashtable hashStd = new Hashtable();
            string path = @"D:\c# practices\streamFile\StudentInfo.txt";
            string[] words;
            Students std;
            try
            {
                if (File.Exists(path))
                {
                    char separator = ' ';
                    string[] part = File.ReadAllLines(path, System.Text.Encoding.UTF8);
                    foreach (string line in part)
                    {
                        // stringsplitoptions options
                        words = line.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length >= 3)
                        {
                            string name = string.Join("", words, 0, words.Length - 2);
                            int id = Convert.ToInt32(words[words.Length - 2]);
                            float grade = float.Parse(words[words.Length - 1]);
                            std = new Students(name.Trim(), id, grade);
                            //Students.spratorOprator(path, listStudents);

                            // اگر شماره دانشجویی تکراری باشد، می‌توانیم رفتار مناسبی داشته باشیم
                            if (!hashStd.ContainsKey(id))
                            {
                                hashStd.Add(id, std.DeepCopy());
                            }
                            else
                            {
                                Console.WriteLine($"Duplicate student ID {name}{id} ignored.");
                            }

                        }
                       

                    }


                }
                else
                {
                    Console.WriteLine("File is not found");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("exceptions file is: " + ex.Message);
            }
         

        }
    }
}
