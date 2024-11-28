namespace Example19_11_24.Data
{
    using System;
    using System.Collections.Generic;

    public class College
    {
        public int CollegeId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime EstablishedYear { get; set; }

        // A college has multiple departments
        public virtual List<Department> Departments { get; set; }

        public College()
        {
            Departments = new List<Department>();
        }

    }


public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        // A department offers multiple courses
        public virtual List<Course> Courses { get; set; }

        // A department has multiple faculty members
        public virtual List<Faculty> Faculty { get; set; }

        public Department()
        {
            Courses = new List<Course>();
            Faculty = new List<Faculty>();
        }

    }

public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public Department Department { get; set; }  // The department offering this course

        public virtual int? FacultyId {  get; set; } 

        // A course can have multiple students enrolled
        public virtual List<Student> Students { get; set; }

        public Course()
        {
            Students = new List<Student>();
        }

    }

public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

        public List<Course> Courses { get; set; }

        public Student()
        {
            Courses = new List<Course>();
        }

    }

public class Faculty
    {
        public int FacultyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

        // A faculty can teach multiple courses
        public List<Course> Courses { get; set; }

        public Faculty()
        {
            Courses = new List<Course>();
        }
    }
}
