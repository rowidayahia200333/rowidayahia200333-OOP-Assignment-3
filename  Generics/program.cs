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

    public static class EnumerableExtensions
    {
        
        public static IEnumerable<T> Page<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number must be 1 or greater.");

            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be 1 or greater.");

            int skip = (pageNumber - 1) * pageSize;
            int current = 0;
            int taken = 0;

            foreach (var item in source)
            {
                if (current >= skip)
                {
                    yield return item;
                    taken++;
                    if (taken == pageSize)
                        yield break;
                }
                current++;
            }
        }


        public static T FindById<T>(this IEnumerable<T> source, int id) where T : IHasId
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            foreach (var item in source)
            {
                if (item != null && item.Id == id)
                {
                    return item;
                }
            }

            return default;
        }

        
        public static IReadOnlyDictionary<int, T> ToIdDictionary<T>(this IEnumerable<T> source) where T : IHasId
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var dictionary = new Dictionary<int, T>();

            foreach (var item in source)
            {
                if (item != null)
                {
                    dictionary.Add(item.Id, item);
                }
            }

            return dictionary;
        }
    }

}