public static class StringValidationExtensions
{
    static public bool IsValidEgyptianPhone(this string phone)
    {
         private static readonly Regex PhoneRegex = new Regex(@"^(?:\+201|01)[0125]\d{8}$", RegexOptions.Compiled);
          private static readonly Regex NationalIdRegex = new Regex(@"^[23]\d{13}$", RegexOptions.Compiled);

           if (string.IsNullOrWhiteSpace(phone))
                return false;

         return PhoneRegex.IsMatch(phone.Trim());

     }

         public static bool IsValidEgyptianNationalId(this string input)
         {
             if (string.IsNullOrWhiteSpace(input))
                 return false;
         
             return NationalIdRegex.IsMatch(input.Trim());
         }
}



