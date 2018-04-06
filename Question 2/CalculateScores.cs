using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars6Kata
{
    class CalculateScores
    {
        private static Dictionary<char, int> Letters = new Dictionary<char, int>()
        {
            {'A', 1}, {'B', 3}, {'C', 3}, {'D', 2}, {'E', 1}, {'F', 4}, {'G', 2},
            { 'H', 4}, {'I', 1}, {'J', 8}, {'K', 5}, {'L', 1}, {'M', 3 }, {'N', 1},
            { 'O', 1}, {'P', 3}, {'Q', 10 }, {'R', 1}, {'S', 1}, {'T', 1}, {'U',1},
            { 'V', 4}, {'W', 4}, {'X', 8}, {'Y', 4}, {'Z', 10}
        };
        public static int CalculateScore(string input)
        {
            char[] inputArray = input.ToUpper().ToCharArray();
            //main score
            int score = 0;
           

            for (int i = 0; i < inputArray.Length; i++)
            {
                
                int counter = 0;
                int tempScore = 0;

                bool isConsecutive = false; 
                bool foundConsecutiveFirst = false;

                for (int j = 0; j < inputArray.Length; j++)
                {
                    if (i == j )
                    {
                        //initial count
                        counter++;
                    }

                    try
                    {
                        //if consecutive we get double consecutive points
                        if (i ==j && inputArray[i] == inputArray[j + 1] && foundConsecutiveFirst == false && i !='-')
                        {
                            //if first consecutive. it will mean 3rd count is double
                            foundConsecutiveFirst = true;
                            Letters.TryGetValue(inputArray[i], out tempScore);
                            score += (tempScore + tempScore) + (tempScore + tempScore);
                            inputArray[j + 1] = '-';
                            counter++;
                        }

                        if (inputArray[i] == inputArray[j] && inputArray[j] == inputArray[j+1] && foundConsecutiveFirst == false && isConsecutive== false && counter <2 )
                        {
                            Letters.TryGetValue(inputArray[i], out tempScore);
                            score += (tempScore + tempScore) + (tempScore + tempScore);
                            inputArray[j] = '-';
                            inputArray[j + 1] = '-';
                            isConsecutive = true;
                            counter += 2;
                       
                        }
                    }
                    catch (Exception ex)
                    {   //avoid exception/ and contiue;
                        
                        goto goThrough;
                    }
                    goThrough:

                    
                    if (inputArray[i] == inputArray[j] && i != j  && inputArray[i] !='-')
                    {
                      //count duplicate
                       counter++;
                       inputArray[j] = '-';
                    }

                }

                ///counter conditions to check
                if (counter == 1)
                { 

                    Letters.TryGetValue(inputArray[i], out tempScore);
                    score += tempScore;
                    inputArray[i] = '-';
                    
                }

                if (counter == 2)
                {
                    //The second occurrence of a letter only awards half points rounded up.
                    Letters.TryGetValue(inputArray[i], out tempScore);
                    score += tempScore + (int)Math.Ceiling((double)tempScore / 2);
                    inputArray[i] = '-';
                    
                }
                //highest potential points
                if (counter > 2 && foundConsecutiveFirst == true)
                {
                  
                    //double secutive points already accounted for;
                    //3rd occuence gets double points
                    Letters.TryGetValue(inputArray[i], out tempScore);
                    score += (tempScore + tempScore);
                    inputArray[i] = '-';
                }
                if (counter == 3 && isConsecutive == false)
                {


                    Letters.TryGetValue(inputArray[i], out tempScore);
                    score += tempScore + (int)Math.Ceiling((double)tempScore / 2) + (tempScore + tempScore);
                    inputArray[i] = '-';

                }
                if (isConsecutive == true && counter > 2)
                {
                    Letters.TryGetValue(inputArray[i], out tempScore);
                    score += tempScore;
                    inputArray[i] = '-';
                }

                if (counter > 3)
                {
                    //more than 4 occurance-  count 3 and leave the rest
                    Letters.TryGetValue(inputArray[i], out tempScore);
                    score += tempScore + (int)Math.Ceiling((double)tempScore / 2) + (tempScore + tempScore);
                    inputArray[i] = '-';
                   
                }
                        
            }
            return score;

        }
    }
}
//test samples
//anajaataea = 15
//anaajataea = 16 
//thomas = 11
//thomasmam = 20 
//tthomast = 16
//thomasma = 14
//ooaotteteeojoo =26
