
namespace bookstore.Domain.Utils
{
    public static class TextUtil 
    { 

        public static int? ToInt(this string value)
        {
            int result;
            if (int.TryParse(value, out result))
                return result;
            return null;
        }

        public static string ApenasNumeros(string valor)
        {
            var onlyNumber = "";
            foreach (var s in valor)
            {
                if (char.IsDigit(s))
                {
                    onlyNumber += s;
                }
            }
            return onlyNumber.Trim();
        }

    }
}
