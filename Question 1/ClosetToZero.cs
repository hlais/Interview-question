using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars6Kata
{
    class ClosetToZero
    {
        public static int ClosestToZero(int[] input)
        {   
            List<int> organisedInput = new List<int>(input);
            organisedInput.Sort();
            
           
            int min = int.MaxValue;

            for (int i = 0; i < organisedInput.Count; i++)
            {
                if (organisedInput[i] == 0)
                {
                    //ignore 0;
                    continue;
                }

                if ( Math.Abs(organisedInput[i]) < Math.Abs(min))
                {
                    min = organisedInput[i];
                }
            }
            //searching the list for a positive value, of the found min
            if (organisedInput.Contains(Math.Abs(min)))
            {
                return Math.Abs(min);
            }

            return min;

        }
    }
    
}
