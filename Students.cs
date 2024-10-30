using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace streamFile
{
    internal class Students
    {
        public string _StudentName;
        public int _StudentNumber;
        public float _Grade;
        public Students(string studentName, int studentNumber, float Grade)
        {
            this._StudentName = studentName;
            this._StudentNumber = studentNumber;
            this._Grade = Grade;
        }
        public Students DeepCopy()
        {
            return new Students(_StudentName, _StudentNumber, _Grade);
        }
        public override string ToString()
        {
            return $"{_StudentName} , {_StudentNumber} , {_Grade}";
        }
        public static List<Students> ReadStudentsFromFile(string path)
        {
            List<Students> studentsList = new List<Students>();

            if (!File.Exists(path))
            {
                Console.WriteLine("File is not found.");
                return studentsList; 
            }

            char separator = ' ';
            string[] part = File.ReadAllLines(path, System.Text.Encoding.UTF8);
            try
            {
                foreach (string line in part)
                {
                    string[] words = line.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length >= 3)
                    {
                        string name = string.Join(" ", words, 0, words.Length - 2);
                        int id = Convert.ToInt32(words[words.Length - 2]);
                        float grade = float.Parse(words[words.Length - 1]);

                        Students std = new Students(name.Trim(), id, grade);
                        studentsList.Add(std.DeepCopy());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception while reading the file: " + ex.Message);
            }

            return studentsList; 
        }


    }
           
}


