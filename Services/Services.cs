using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Services
    {
        // function for finding the maximum element
        public int Max(int[] numbers)
        {
            int m = numbers[0];

            for (int i = 0; i < numbers.Length; i++)
                if (m > numbers[i])
                    m = numbers[i];

            return m;
        }

        // function for finding the minimum element
        public int Min(int[] numbers)
        {
            int m = numbers[0];

            for (int i = 0; i < numbers.Length; i++)
                if (m > numbers[i])
                    m = numbers[i];

            return m;
        }
       
    }
}
