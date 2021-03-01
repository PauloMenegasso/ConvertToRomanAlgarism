using System;

namespace NumerosRomanos
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertArabicToRoman();
            ConvertRomanToArabic();
        }
        private static void ConvertArabicToRoman() {
            Console.WriteLine("Write a number to convert to Roman");
            var number = int.Parse(Console.ReadLine());

            int[] numberSequence = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1};
            string[] syblSequence = { "M", "CM" ,"D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int i = 0;
            string romanNumber = "";

            while (i < numberSequence.Length) {
                var res = Divide(number, numberSequence[i]);
                while (res.Item1 != 0) {
                    romanNumber += syblSequence[i];
                    res.Item1--;
                }
                number= res.Item2;
                i++;
            }
            
            Console.WriteLine(romanNumber);
        }
        
        private static (int, int) Divide(int Numerator, int Denominator) {
        var result = Numerator/Denominator;
        var rest = Numerator - Denominator*result;
        return (result, rest);
        }         

        private static void ConvertRomanToArabic() {
            Console.WriteLine("Write a number to convert to Arabic");
            var romanNumber = Console.ReadLine();
            var number = 0;

            int[] numberSequence = { 900, 1000, 400, 500, 90, 100, 40, 50, 9, 10, 4, 5, 1};
            string[] syblSequence = { "CM" ,"M", "CD", "D", "XC", "C", "XL", "L", "IX", "X", "IV", "V", "I" };
            int j = 0;
            char first;
            char second;

            foreach(var sequence in syblSequence) {
                while (romanNumber.Contains(sequence)) {
                    first = sequence[0];
                    romanNumber = romanNumber.TrimStart(first);
                    if (sequence.Length > 1) {
                        second = sequence[1];
                        romanNumber = romanNumber.TrimStart(second);
                    }
                    number += numberSequence[j];
                }
            j++;
            }
            Console.WriteLine(number);
        }
    }
}
