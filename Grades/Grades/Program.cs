using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student("Петров", "В.В.", 5, "Алгебра", 5),
                new Student("Петров", "В.В.", 5, "Алгебра", 3),
                new Student("Иванов", "В.С.", 5, "Алгебра", 3),
                new Student("Рогов", "Б.В.", 5, "Информатика", 5),
                new Student("Рогов", "Б.В.", 5, "Информатика", 2),
                new Student("Рогов", "Б.В.", 5, "Геометрия", 4),
                new Student("Рогов", "А.А.", 5, "Геометрия", 4),
                new Student("Рогов", "А.А.", 5, "Геометрия", 4)
            };
            string input = String.Empty;
            var req = students
                .GroupBy(n => new { n.LastName, n.Initials, n.Subject })
                .Select(n => new
                {
                    LastName = n.Key.LastName,
                    Initials = n.Key.Initials,
                    Subject = n.Key.Subject,
                    Grades = n.Average(x => x.Grades)
                })
                //.Join(students,s=>s.Subject,n,v)
                .OrderBy(o => o.LastName)
                .ThenBy(t => t.Initials);
           


            Console.WriteLine("Студенты:");
            foreach (var student in req)
                Console.WriteLine("{0}, {1}, Предмет:{2}, Средняя оценка:{3}", student.LastName, student.Initials, student.Subject, student.Grades);
            Console.WriteLine("___________________________________");
            var req2 = students.Select(n => new 
                {
                    Initials = n.Initials,
                    Subject = n.Subject,
                    Grades = 0.00f

                }).Distinct();
            //.Except(students.Select(n => n.Subject));
            foreach (var dif in req2)
            {
                Console.WriteLine(dif);
            }


            Console.ReadLine();



        }
        class Student
        {
            public string LastName;
            public string Initials;
            public int @Class;
            public string Subject;
            public int Grades;
            public Student(string lastName, string initials, int @class, string subject, int grades)
            {
                LastName = lastName;
                Initials = initials;
                @Class = @class;
                Subject = subject;
                Grades = grades;

            }
        }
    }

}