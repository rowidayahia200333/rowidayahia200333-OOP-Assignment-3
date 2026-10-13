namespace rowidayahia200333_OOP_Assignment_3.Refactoring;

using System.Diagnostics;

public static class BlockedUserChecker
{
	public static int CountBlocked(List<int> blockedIds, int[] requestIds)
	{
	
		var blockedSet = new HashSet<int>(blockedIds);
		var blocked = 0;

		foreach (var id in requestIds)
		{
			if (blockedSet.Contains(id))
				blocked++;
		}
		return blocked;
	}

	public static List<int> BuildBlockedIds(int count)
	{
		var list = new List<int>(count);
		for (var i = 0; i < count; i++)
			list.Add(i);
		return list;
	}

	public static int[] BuildRequestIds(int count, int maxId, int seed = 42)
	{
		var rnd = new Random(seed);
		var ids = new int[count];
		for (var i = 0; i < count; i++)
			ids[i] = rnd.Next(maxId);
		return ids;
	}

	public static long MeasureMs(List<int> blockedIds, int[] requestIds, out int found)
	{
		var sw = Stopwatch.StartNew();
		found = CountBlocked(blockedIds, requestIds);
		sw.Stop();
		return sw.ElapsedMilliseconds;
	}
}

//student
public class Student
{
	public int Id { get; set; }
	public string Name { get; set; } = "";
}

public static class StudentCatalog
{
	
	public static IEnumerable<Student> GetAllStudents()
	{
		for (var i = 1; i <= 1_000_000; i++)
		{
			yield return new Student { Id = i, Name = $"Student {i}" };
		}
	}
}