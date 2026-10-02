
namespace rowidayahia200333_OOP_Assignment_3.Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
           

            var studentStore = new Store<Student>();
            studentStore.Add(new Student(1, "Ahmed"));
            studentStore.Add(new Student(2, "Mona"));
            studentStore.Add(new Student(3, "Rowida"));
            studentStore.Add(new Student(4, "Omar"));
            studentStore.Add(new Student(5, "Sara"));

            var courseStore = new Store<Course>();
            courseStore.Add(new Course(101, "C# Basics", 1500));
            courseStore.Add(new Course(102, "OOP & Generics", 2500));
            courseStore.Add(new Course(103, "SQL Databases", 2000));

      
            var student = studentStore.GetById(3);
            Console.WriteLine($"GetById(3) Student: {student?.Name}");

            var course = courseStore.GetById(102);
            Console.WriteLine($"GetById(102) Course: {course?.Title}");
            Console.WriteLine();

            try
            {
                studentStore.Add(new Student(1, "Duplicate Student"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Caught Expected Exception: {ex.Message}");
            }
            Console.WriteLine();

            
            var page2 = studentStore.GetAll().Page(2, 2);
            foreach (var st in page2)
            {
                Console.WriteLine($"Id: {st.Id}, Name: {st.Name}");
            }
            Console.WriteLine();

            var courseList = new List<Course>
            {
                new Course(1, "Math", 1000),
                new Course(2, "Physics", 1200)
            };
            var foundCourse = courseList.FindById(2);
            Console.WriteLine($"FindById(2) on plain List<Course>: {foundCourse?.Title}");
            Console.WriteLine();

            
            // var stringStore = new Store<string>(); // must NOT compile: string does not implement IHasId
        }
    }
}