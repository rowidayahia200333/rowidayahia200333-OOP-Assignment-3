1. IReadOnlyDictionary<TKey, TValue>
- What is it?  
  An interface that provides a read-only view of a collection of key/value pairs. It exposes properties like Count, Keys, Values, and lookup methods like TryGetValue and indexers [key], but lacks any mutation methods like Add, Remove, or Clear.

  How is it different from Dictionary<TKey, TValue>?  Dictionary<TKey, TValue> is a concrete, mutable data structure that allows adding, updating, and removing elements. IReadOnlyDictionary is an interface that explicitly hides/prevents modification methods to enforce immutability at compile time.

  Why return IReadOnlyDictionary from a public method instead of Dictionary?  Prevents callers/consumers from accidentally modifying internal dictionary states (e.g., adding or removing keys)

  2.SortedDictionary<TKey,TValue> 
  - What is it?  A collection of key/value pairs sorted by key

  How is it different from Dictionary<TKey, TValue>? in Ordering & Lookup SpeOrdering:*Ordering:** Dictionary maintains no guaranteed order of its keys. SortedDictionary automatically maintains elements sorted by key in ascending order (or based on a provided IComparer).  
  - **Lookup Speed:**  
    - Dictionary: $O(1)$ average time complexity for lookups, insertions, and deletions using hash tables.  
    - SortedDictionary: $O(\log N)$ time complexity for lookups, insertions, and deletions due to tree traversal.

- **When would you choose SortedDictionary?**  
  1. When keys need to be constantly iterated over in sorted order.  
  2. When frequent insertions and deletions occur on already-sorted data without requiring full re-sorting operations.  
  3. When memory overhead of resizing large backing arrays in SortedList is a concern.


##################### Task 2.2 — Pick the Collection

- S1: Find a student by national ID — thousands of times a day.
  - Collection: Dictionary<string, Student> (or Dictionary<long, Student>)
  - Reason: Provides $O(1)$ fast lookup speed using the national ID as a unique key.

- S2: Keep the tags of a course. The same tag must never be stored twice.
  - Collection: HashSet<string>
  - Reason: Automatically enforces uniqueness by preventing duplicate items and offers fast lookup.

- S3: Keep a student's grades in the order they were entered. The same grade can appear more than once.
  - Collection: List<int> (or List<double>)
  - Reason: Maintains insertion order, allows duplicates, and supports dynamic indexing.

- S4: A public method returns the course price list. Callers can read prices but must not add or change any.
  - Collection: IReadOnlyDictionary<string, decimal>
  - Reason: Exposes lookup functionality while strictly preventing callers from modifying or adding prices.

- S5: A timetable keyed by session start time. Sessions are added at any moment, and it must always print in time order.
  - Collection: SortedDictionary<DateTime, Session>
  - Reason: Automatically keeps entries sorted by their key (start time) upon insertion.

- S6: A method returns results that the caller only loops over once — and may stop early.
  - Collection: IEnumerable<T>
  - Reason: Enables lazy evaluation so items are produced on demand without allocating the whole dataset in memory.

