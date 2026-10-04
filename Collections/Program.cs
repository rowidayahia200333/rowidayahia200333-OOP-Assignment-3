
namespace rowidayahia200333_OOP_Assignment_3.Collections;
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Testing Extension Methods ===\n");

          
            TestPhone("01012345678");
            TestPhone("+201512345678");
            TestPhone("01312345678");
            TestPhone("0101234567");
            TestPhone("0101234567a");

            Console.WriteLine();

           
            TestNationalId("29901011234567");
            TestNationalId("19901011234567");
            TestNationalId("2990101123456");
        }

        static void TestPhone(string input)
        {
            bool result = input.IsValidEgyptianPhone();
            Console.WriteLine($"Input: \"{input}\" -> IsValidEgyptianPhone() = {result.ToString().ToLower()}");
        }

        static void TestNationalId(string input)
        {
            bool result = input.IsValidEgyptianNationalId();
            Console.WriteLine($"Input: \"{input}\" -> IsValidEgyptianNationalId() = {result.ToString().ToLower()}");
        }
    }
}




