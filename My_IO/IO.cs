using People;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace My_IO
{
    public class IO
    {
        public IO()
        {

        } //+
        public IO(string path)
        {
            Path = path;
            FileStream stream = File.Create(Path);
            stream.Close();
        }//+

        public int Count()
        {
            int count = Patterns.regexPer.Matches(DisplayAllFromFile()).Count;
            return count;
        } //+
        public string Path { get; set; } //+

        public void WriteDownPerson<T>(T person) where T : Person
        {
            StringBuilder res = new StringBuilder();

            res.Append($"{Regex.Replace(person.GetType().ToString(), @"\w+.(?<name>\w+)", @"${name}")}" +
                $" {person.FirstName}{person.LastName}\n");
            res.Append($"{{ \"firstname\": \"{person.FirstName}\",\n" +
                $"\"lastname\": \"{person.LastName}\",\n" +
                $"\"sex\": \"{person.Sex}\",\n" +
                $"\"residence\": \"{person.Residence}");

            if (person is Student)
            {
                Student student = person as Student;
                res.Append($"{student.Residence}\",\n");
                res.Append($"\"course\": \"{student.Course}\",\n");
                res.Append($"\"studentId\": \"{student.StudentId}\"}};");
            }
            else if (person is Seller)
            {
                Seller seller = person as Seller;
                res.Append($"\",\n\"product\": \"{seller.Product}\"}};");
            }
            else if (person is Gardener)
            {
                Gardener gardener = person as Gardener;
                res.Append($"\",\n\"employer\": \"{gardener.Employer}\"}};");
            }
            res.AppendLine(Environment.NewLine);

            File.AppendAllText(Path, res.ToString());
        } //+

        public Person[] ReadAllFromFile()
        {  
            if (Count() > 0)
            {
                Person[] persons = new Person[Count()];
                int index = 0;

                for (Match m = Patterns.regexSt.Match(DisplayAllFromFile()); m.Success; m = m.NextMatch())
                {
                    persons[index] = new Student(m.Groups["firstname"].ToString(),
                        m.Groups["lastname"].ToString(), m.Groups["sex"].ToString(),
                          false, m.Groups["residence"].ToString(),  m.Groups["studentId"].ToString(), m.Groups["course"].ToString());
                    index++;
                }
                for (Match m = Patterns.regexStD.Match(DisplayAllFromFile()); m.Success; m = m.NextMatch())
                {
                    persons[index] = new Student(m.Groups["firstname"].ToString(),
                        m.Groups["lastname"].ToString(), m.Groups["sex"].ToString(),
                        true, m.Groups["residence"].ToString(),  m.Groups["studentId"].ToString(), m.Groups["course"].ToString());
                    index++;
                }
                for (Match m = Patterns.regexG.Match(DisplayAllFromFile()); m.Success; m = m.NextMatch())
                {
                    persons[index] = new Gardener(m.Groups["firstname"].ToString(),
                        m.Groups["lastname"].ToString(), m.Groups["sex"].ToString(),
                         m.Groups["residence"].ToString(), m.Groups["employer"].ToString());
                    index++;
                }
                for (Match m = Patterns.regexSe.Match(DisplayAllFromFile()); m.Success; m = m.NextMatch())
                {
                    persons[index] = new Seller(m.Groups["firstname"].ToString(),
                        m.Groups["lastname"].ToString(), m.Groups["sex"].ToString(),
                         m.Groups["residence"].ToString(), m.Groups["product"].ToString());
                    index++;
                }

                return persons;
            }
            else
                return null;
            
        }  //+
        public Person[] Search()
        {
            if (SearchString().count > 0)
            {
                Person[] persons = new Person[SearchString().count];
                int index = 0;
                for (Match m = Patterns.regex3D.Match(DisplayAllFromFile()); m.Success; m = m.NextMatch())
                {
                    persons[index] = new Student(m.Groups["firstname"].ToString(),
                        m.Groups["lastname"].ToString(), m.Groups["sex"].ToString(),
                        true, m.Groups["residence"].ToString(), m.Groups["studentId"].ToString(), m.Groups["course"].ToString());
                    index++;
                }

                return persons;
            }
            else
                return null;

        } //+

        public void ClearFile()
        {
            File.WriteAllText(Path, "");
        }

        //+
        #region String 
        public string DisplayAllFromFile()
        {
            string res = File.ReadAllText(Path);
            return res;
        }
        public (string list, int count) SearchString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            int count = 0;

            for (Match m = Patterns.regex3D.Match(DisplayAllFromFile()); m.Success; m = m.NextMatch())
            {
                stringBuilder.Append(m.Value + Environment.NewLine + Environment.NewLine);
                count++;
            }

            return (stringBuilder.ToString(), count);
        }
        #endregion 
    }
}
