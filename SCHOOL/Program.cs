using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using SCHOOL.Models;
using System.Diagnostics.Metrics;
using System;
using System.Linq;

namespace SCHOOL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SCHOOLContext context = new SCHOOLContext();
            do
            {
                Console.WriteLine("Main Menu\nChoose by entering a number:\n" +
                    "\n1) Display belonging teachers to courses");
                Console.WriteLine("2) Display student info" +
                    "\n3) Display all active courses " +
                "\n4) EXTRA Update student details ");
                Console.WriteLine("---------------------------------------------");
                string val = Console.ReadLine();
                if (val == "1")
                {
                    Teacherinfo(context);
                }
                else if (val == "2")
                {
                    Studentinfo(context);
                }
                else if (val == "3")
                {
                    ActiveCourses(context);
                }
                else if (val == "4")
                {
                    UpdateStudentDetails(context);
                }
                else
                {
                    Console.WriteLine("You can only enter a number in the menu");
                    Console.WriteLine("---------------------------------------------");
                }
            } while (true == true);
        }
        public static void Teacherinfo(SCHOOLContext context)
        {
            Console.WriteLine();
            var teac = context.Teachers;
            var cors = context.Courses.ToList();

            var kurserrec = context.CourseRecords
                .OrderBy(p => p.CourseRecordId).ToList();
            List<string> pep = new List<string>();

            foreach (var kla in cors)
            {
                Console.WriteLine($"\nCourse: {kla.CourseName}\n"); //skriver ämnet, kursen

                foreach (CourseRecord recods in kurserrec)
                {
                    if (recods.CourseNameId == kla.CourseId)
                    {
                        foreach (var ttt in teac)
                        {
                            if (recods.TeacherId == ttt.TeacherId)
                            {
                                if (pep.Contains(ttt.FirstName))
                                {
                                }
                                else
                                {
                                    Console.WriteLine($"{ttt.FirstName}");
                                    pep.Add(ttt.FirstName);
                                }
                            }
                        }
                    }
                }
                pep.Clear();
            }
        }
        public static void Studentinfo(SCHOOLContext context)
        {
            Console.WriteLine();
            var s = context.Students;
            var k = context.Classes
            .OrderBy(p => p.ClassName).ToList();

            foreach (Class ccc in k)
            {
                foreach (var item in s)
                {
                    if (ccc.ClassId == item.ClassId)
                    {
                        Console.WriteLine($"Class: {ccc.ClassName}");
                        Console.WriteLine($"Name:{item.FirstName} {item.LastName}");
                        Console.WriteLine();
                    }
                }
            }
        }
        public static void ActiveCourses(SCHOOLContext context)
        {
            var c = context.Courses
            .Where(p => p.IsActive == true);
            Console.WriteLine("Displaying all active courses:\n");
            foreach (var item in c)
            {
                Console.WriteLine($"Course Id:{item.CourseId}");
                Console.WriteLine($"Course Name:{item.CourseName}");
                Console.WriteLine();
            }
        }
        public static void UpdateStudentDetails(SCHOOLContext context)
        {
            Console.WriteLine("You have chosen to update details of a student");
            var s = context.Students;
            var k = context.Classes
            .OrderBy(p => p.ClassName).ToList();
            foreach (Class ccc in k)
            {
                foreach (var item in s)
                {
                    if (ccc.ClassId == item.ClassId)
                    {
                        Console.WriteLine($"***ClassID: {ccc.ClassId} Class:{ccc.ClassName}***\nStudent ID:{item.StudentId}");
                        Console.WriteLine($"Name:{item.FirstName} {item.LastName}");
                        Console.WriteLine();
                    }
                }
            }
            int ids = 0; bool booo = true;
            do
            {
                try
                {
                    Console.WriteLine("Choose a valid 'Student ID' to update details:");
                    ids = Convert.ToInt32(Console.ReadLine());
                    if (ids <= s.Count())
                    {
                        booo = false;
                    }
                }
                catch
                {
                    Console.WriteLine("You must enter a valid Student ID");
                }
            } while (booo == true);

            Console.WriteLine("Enter a first name:");
            string fna = Console.ReadLine();

            Console.WriteLine("Enter a last name:");
            string lasna = Console.ReadLine();

            Console.WriteLine("DID IT");

            int cl = 0; bool bo = true;
            do
            {
                try
                {
                    Console.WriteLine("Choose a valid 'Class ID' to update details:");
                    cl = Convert.ToInt32(Console.ReadLine());
                    if (cl <= k.Count())
                    {
                        bo = false;
                    }
                }
                catch
                {
                    Console.WriteLine("You must enter a valid 'Class ID'");
                }
            } while (bo == true);

            var sud = context.Students
                .Where(p => p.StudentId == ids);

            foreach (Student item in sud)
            {
                item.StudentId = ids;
                item.FirstName = fna;
                item.LastName = lasna;
                item.ClassId = cl;
            }
            Console.WriteLine("\n***\nYou have edited one student to following:");
            Console.WriteLine($"Student ID: {ids}");
            Console.WriteLine($"Name: {fna} {lasna}");
            Console.WriteLine($"Class ID: {cl}\n");

            context.SaveChanges();
        }
    }
}
