namespace rowidayahia200333_OOP_Assignment_3.Generics
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

   


    
        public class StudentStore
        {
            private readonly List<Student> _students = new List<Student>();

            public void Add(Student student)
            {
                if (student != null)
                {
                    _students.Add(student);
                }
            }

            public Student? GetById(int id)
            {
                foreach (var student in _students)
                {
                    if (student.Id == id)
                        return student;
                }
                return null;
            }

            public IEnumerable<Student> GetAll()
            {
                return _students;
            }

            public bool Remove(int id)
            {
                var student = GetById(id);
                if (student != null)
                {
                    return _students.Remove(student);
                }
                return false;
            }
        }


   
    
        public class Course
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public decimal Price { get; set; }

            public Course(int id, string title, decimal price)
            {
                Id = id;
                Title = title;
                Price = price;
            }
    }
    using System.Collections.Generic;

    
        public class CourseStore
        {
            private readonly List<Course> _courses = new List<Course>();

            public void Add(Course course)
            {
                if (course != null)
                {
                    _courses.Add(course);
                }
            }

            public Course? GetById(int id)
            {
                foreach (var course in _courses)
                {
                    if (course.Id == id)
                        return course;
                }
                return null;
            }

            public IEnumerable<Course> GetAll()
            {
                return _courses;
            }

            public bool Remove(int id)
            {
                var course = GetById(id);
                if (course != null)
                {
                    return _courses.Remove(course);
                }
                return false;
            }
    }

    using System.Collections.Generic;


    
        public class Store<T>
        {
            private readonly List<T> _items = new List<T>();

            public void Add(T item)
            {
                if (item != null)
                {
                    _items.Add(item);
                }
            }

            public T GetById(int id)
            {
                foreach (var item in _items)
                {
                   
                    if (item.Id == id)
                        return item;
                }
                return default;
            }

            public IEnumerable<T> GetAll()
            {
                return _items;
            }

            public bool Remove(int id)
            {
                var item = GetById(id);
                if (item != null)
                {
                    return _items.Remove(item);
                }
                return false;
            }
        }
    

}