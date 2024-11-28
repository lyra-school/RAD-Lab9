namespace Example19_11_24.Data
{
    public static class DbSeeder
    {
        public static void SeedData(CollegeContext context)
        {
            // Check if the database has already been seeded
            if (context.Colleges.Any()) return; // The database is already seeded

            College college = new College
            {
                Name = "ABC University",
                Location = "City XYZ",
                EstablishedYear = new DateTime(1985, 5, 15)
            };

            // Create departments
            Department computerScience = new Department
            {
                Name = "Computer Science",
            };

            Department mathematics = new Department
            {
                Name = "Mathematics",
            };

            // Add departments to college
            college.Departments.Add(computerScience);
            college.Departments.Add(mathematics);

            // Create courses
            Course cs101 = new Course
            {
                Name = "Intro to Computer Science",
                Credits = 3,
                Department = computerScience
            };

            Course math101 = new Course
            {
                Name = "Calculus I",
                Credits = 4,
                Department = mathematics
            };

            string[] arr =
   {  "Introduction to Computer Science",
    "Data Structures and Algorithms",
    "Object-Oriented Programming",
    "Computer Architecture",
    "Operating Systems",
    "Software Engineering",
    "Database Management Systems",
    "Web Development",
    "Artificial Intelligence",
    "Machine Learning" };

            foreach (string str in arr)
            {
                Course c = new Course { Name = str, Department = computerScience, Credits = 2 };
                context.Courses.Add(c);
            }


            // Assign faculty to courses
            computerScience.Faculty.Add(new Faculty { FirstName = "Prof. Alan", LastName = "Turing", Email = "alanturing@abcuniversity.com" });
            mathematics.Faculty.Add(new Faculty { FirstName = "Prof. Marie", LastName = "Curie", Email = "mariecurie@abcuniversity.com" });

            // Create students
            Student student1 = new Student
            {
                FirstName = "Alice",
                LastName = "Johnson",
                DateOfBirth = new DateTime(2000, 6, 15),
                Email = "alice.johnson@student.abcuniversity.com"
            };

            // Enroll students in courses
            cs101.Students.Add(student1);
            math101.Students.Add(student1);

            // Add the entities to the DbSet
            context.Colleges.Add(college);
            context.Departments.Add(computerScience);
            context.Departments.Add(mathematics);
            Console.WriteLine("\n\n\n\n");
            context.Courses.Add(cs101);
            context.Students.Add(student1);

            // Save the data to the database
            context.SaveChanges();
        }
    }

}
