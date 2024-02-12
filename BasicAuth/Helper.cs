namespace BasicAuth
{
    public class Helper
    {
        public int ValidasiINT(int from, int to)
        {
            int i;
            bool inputNumber = int.TryParse(Console.ReadLine(), out i);
            bool isValid = false;
            while (!isValid)
            {
                if (inputNumber == false || i < from || i > to)
                {
                    Console.WriteLine($"Harus Input Angka {from} sampai {to}");
                    Console.WriteLine("> ");
                    inputNumber = int.TryParse(Console.ReadLine(), out i);
                }
                else
                {
                    isValid = true;
                }
            }
            return i;
        }

        public string ValidasiString(int from, int to)
        {
            string input;
            input = Console.ReadLine();
            bool isValid = false;
            while (!isValid)
            {
                if (input.Length < from || input.Length > to)
                {
                    Console.WriteLine($"Harus Input {from} sampai {to} Character");
                    Console.Write("> ");
                    input = Console.ReadLine();
                }
                else
                {
                    isValid = true;
                }
            }
            return input;
        }

        public bool HasUppercase(string input)
        {
            foreach (char c in input)
            {
                if (Char.IsUpper(c))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasLowercase(string input)
        {
            foreach (char c in input)
            {
                if (Char.IsLower(c))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasDigit(string input)
        {
            foreach (char c in input)
            {
                if (Char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
