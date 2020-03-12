using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxFileNumberValidationApp
{
    public class ValidationService : IValidationService
    {

        public bool ValidateTFN(string tfn)
        {
            //validate only digits
            if (!IsNumeric(tfn)) return false;

            //validate length
            if (tfn.Length != 9 && tfn.Length != 8) return false;

            int[] digits = Array.ConvertAll(tfn.ToArray(), c => (int)Char.GetNumericValue(c));

            //do the calcs
            var sum = (digits[0] * 10)
                    + (digits[1] * 7)
                    + (digits[2] * 8)
                    + (digits[3] * 4)
                    + (digits[4] * 6)
                    + (digits[5] * 3)
                    + (digits[6] * 5)
                    + (digits[(tfn.Length - 1)] * 1);

            sum += tfn.Length == 9 ? (digits[7] * 2) : sum;
            var remainder = sum % 11;
            return (remainder == 0);
        }

        private bool IsNumeric(string s)
        {
            float output;
            return float.TryParse(s, out output);
        }
    }
}
