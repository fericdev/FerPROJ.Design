using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Class {
    public static class CNumberExtensions {
        public static string ToPesosString(this decimal amount) {
            long pesos = (long)Math.Floor(amount);
            int centavos = (int)Math.Round((amount - pesos) * 100);

            string result = NumberToWords(pesos);

            if (centavos > 0) {
                result += $" Pesos and {NumberToWords(centavos)} Centavos Only";
            }
            else {
                result += " Pesos Only";
            }

            return result;
        }

        private static string NumberToWords(long number) {
            if (number == 0)
                return "Zero";

            if (number < 0)
                return "Minus " + NumberToWords(Math.Abs(number));

            var words = new StringBuilder();

            if ((number / 1_000_000_000) > 0) {
                words.Append(NumberToWords(number / 1_000_000_000) + " Billion ");
                number %= 1_000_000_000;
            }

            if ((number / 1_000_000) > 0) {
                words.Append(NumberToWords(number / 1_000_000) + " Million ");
                number %= 1_000_000;
            }

            if ((number / 1000) > 0) {
                words.Append(NumberToWords(number / 1000) + " Thousand ");
                number %= 1000;
            }

            if ((number / 100) > 0) {
                words.Append(NumberToWords(number / 100) + " Hundred ");
                number %= 100;
            }

            if (number > 0) {
                if (words.Length != 0)
                    words.Append("");

                string[] unitsMap =
                {
                "Zero","One","Two","Three","Four","Five","Six","Seven","Eight","Nine",
                "Ten","Eleven","Twelve","Thirteen","Fourteen","Fifteen","Sixteen",
                "Seventeen","Eighteen","Nineteen"
            };

                string[] tensMap =
                {
                "Zero","Ten","Twenty","Thirty","Forty","Fifty","Sixty",
                "Seventy","Eighty","Ninety"
            };

                if (number < 20) {
                    words.Append(unitsMap[number]);
                }
                else {
                    words.Append(tensMap[number / 10]);

                    if ((number % 10) > 0)
                        words.Append("-" + unitsMap[number % 10]);
                }
            }

            return words.ToString().Trim();
        }
    }
}
