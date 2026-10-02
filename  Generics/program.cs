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
    
}