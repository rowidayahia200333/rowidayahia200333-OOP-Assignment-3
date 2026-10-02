namespace rowidayahia200333_OOP_Assignment_3.Generics
{


    
    
        public interface IHasId
        {
            int Id { get; }
        }
    


    public class Student : IHasId
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

   


    
       

   
    
        public class Course : IHasId
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
    

    
       




    public class Store<T>
        where T : IHasId
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