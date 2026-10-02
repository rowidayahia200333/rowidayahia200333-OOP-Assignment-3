## Step 2 - A store for courses

### What is the same between StudentStore and CourseStore?
- Structure & Logic: Both classes share identical structural logic for managing an internal list (List<T>).
- Method Signatures & Behavior: Both provide the exact same set of CRUD operations (Add, GetById, GetAll, Remove) with the same execution patterns (e.g., iterating through a list by Id, returning null if not found).

### What is different?
- Data Types: The only difference is the type of entity being handled (Student vs Course).
- Code Duplication: Because each store is tied to a specific class type, we are forced to duplicate the entire store implementation logic for every new entity type.


       ## Step 3 - One class for both

### Compiler Error:

if (item.Id == id)
       return item;

 'T' does not contain a definition for 'Id' and no accessible extension method 'Id' accepting a first argument of type 'T' could be found
          it is want for examble an interface that have an Id property and the class that implement this interface will have this property and the generic class will be constraint to this interface