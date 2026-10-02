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
       
        private readonly Dictionary<int, T> _items = new Dictionary<int, T>();

        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Item cannot be null.");

            if (_items.ContainsKey(item.Id))
            {
                throw new InvalidOperationException($"An item with Id '{item.Id}' already exists in the store.");
            }

            _items.Add(item.Id, item);
        }

        public T GetById(int id)
        {
           
            if (_items.TryGetValue(id, out var item))
            {
                return item;
            }

            return default;
        }

        
        public IReadOnlyCollection<T> GetAll()
        {
            return _items.Values;
        }

        public bool Remove(int id)
        {
            return _items.Remove(id);
        }
    }


}