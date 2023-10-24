/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System;
using System.Text;
using System.Collections.Generic;

namespace ISM6225_Fall_2023_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 3, 50, 75 };
            int upper = 99, lower = 0;
            IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
            string result = ConvertIListToNestedList(missingRanges);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine();

            //Question2:
            Console.WriteLine("Question 2");
            string parenthesis = "()[]{}";
            bool isValidParentheses = IsValid(parenthesis);
            Console.WriteLine(isValidParentheses);
            Console.WriteLine();
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] prices_array = { 7, 1, 5, 3, 6, 4 };
            int max_profit = MaxProfit(prices_array);
            Console.WriteLine(max_profit);
            Console.WriteLine();
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string s1 = "69";
            bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
            Console.WriteLine(IsStrobogrammaticNumber);
            Console.WriteLine();
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            int[] numbers = { 1, 2, 3, 1, 1, 3 };
            int noOfPairs = NumIdenticalPairs(numbers);
            Console.WriteLine(noOfPairs);
            Console.WriteLine();
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] maximum_numbers = { 3, 2, 1 };
            int third_maximum_number = ThirdMax(maximum_numbers);
            Console.WriteLine(third_maximum_number);
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string currentState = "++++";
            IList<string> combinations = GeneratePossibleNextMoves(currentState);
            string combinationsString = ConvertIListToArray(combinations);
            Console.WriteLine(combinationsString);
            Console.WriteLine();
            Console.WriteLine();

            //Question 8:
            Console.WriteLine("Question 8:");
            string longString = "leetcodeisacommunityforcoders";
            string longStringAfterVowels = RemoveVowels(longString);
            Console.WriteLine(longStringAfterVowels);
            Console.WriteLine();
            Console.WriteLine();
        }

        /*
        
			Question 1:
			You are given an inclusive range [lower, upper] and a sorted unique integer array nums, where all elements are within the inclusive range. A number x is considered missing if x is in the range [lower, upper] and x is not in nums. Return the shortest sorted list of ranges that exactly covers all the missing numbers. That is, no element of nums is included in any of the ranges, and each missing number is covered by one of the ranges.
			Example 1:
			Input: nums = [0,1,3,50,75], lower = 0, upper = 99
			Output: [[2,2],[4,49],[51,74],[76,99]]  
			Explanation: The ranges are:
			[2,2]
			[4,49]
			[51,74]
			[76,99]
        Example 2:
        Input: nums = [-1], lower = -1, upper = -1
        Output: []
        Explanation: There are no missing ranges since there are no missing numbers.

        Constraints:
        -109 <= lower <= upper <= 109
        0 <= nums.length <= 100
        lower <= nums[i] <= upper
        All the values of nums are unique.

        Time complexity: O(n), space complexity:O(1)
        */

        /*
        FindMissingRanges function takes in a sorted integer array (nums), a lower bound (lower), and an upper bound (upper).
        It returns a list of lists representing the missing ranges within the inclusive range [lower, upper].

        The function works by iterating through the array "nums" and finding the missing ranges between "lower" and the first element of "nums," 
        and between the last element of "nums" and "upper."

        If the input array "nums" is empty, it simply adds the entire range [lower, upper] as a missing range.

        Time complexity: O(n), where n is the length of the "nums" array.
        Space complexity: O(1), as the output list "missingRanges" does not grow with the input size.
        */

        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            int dig = nums.Length;
            List<IList<int>> lis = new List<IList<int>>();

            try
            {
                // Check if theere are zero number of digits
                if (dig == 0)
                {
                    // Create a list containing a single range [lower, upper] and return it
                    lis.Add(new List<int> { lower, upper });
                    return lis;
                }
                // verify if the first number in 'nums' is greater than 'lower'

                if (nums[0] > lower)
                {
                    // Add a range [lower, nums[0] - 1] to 'lis'
                    lis.Add(new List<int> { lower, nums[0] - 1 });
                }
                // Loop through 'nums' to find gaps in between consecutive numbers

                for (int i = 1; i < dig; i++)
                {
                    if (nums[i] - nums[i - 1] > 1)
                    {
                        // Add a range [nums[i - 1] + 1, nums[i] - 1] to 'lis'
                        lis.Add(new List<int> { nums[i - 1] + 1, nums[i] - 1 });
                    }
                }
                // verify whether the final number in 'nums' is smaller than 'upper'.

                if (nums[dig - 1] < upper)
                {
                    // Include the interval [nums[dig - 1] + 1, upper] in the 'lis' list
                    lis.Add(new List<int> { nums[dig - 1] + 1, upper });
                }
            }
            catch (Exception ex)
            {
                // Capture and record any exceptions that might arise during the operation
                Console.WriteLine("An error occurred: " + ex.Message);
            }


            return lis;
        }

        // Helper function to add a range to the "missingRanges" list
        private static void AddRange(IList<IList<int>> missingRanges, long start, long end)
        {
            if (start > end)
            {
                return; // No missing elements in this range
            }

            if (start == end)
            {
                missingRanges.Add(new List<int> { (int)start }); // Single missing element
            }
            else
            {
                missingRanges.Add(new List<int> { (int)start, (int)end }); // Range of missing elements
            }
        }

        // Helper function to print the missing ranges
        private static void PrintMissingRanges(IList<IList<int>> missingRanges)
        {
            foreach (var range in missingRanges)
            {
                Console.Write("[");
                Console.Write(string.Join(",", range));
                Console.Write("]");
            }
            Console.WriteLine();
        }

        // This problem shows how to quickly identify and record missing ranges within a specified numerical range. This entails looping over a sorted array to find gaps, which is a necessary ability for interacting with datasets and comprehending data patterns.
        /*
         
        Question 2

        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.An input string is valid if:
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.
 
        Example 1:

        Input: s = "()"
        Output: true
        Example 2:

        Input: s = "()[]{}"
        Output: true
        Example 3:

        Input: s = "(]"
        Output: false

        Constraints:

        1 <= s.length <= 104
        s consists of parentheses only '()[]{}'.

        Time complexity:O(n^2), space complexity:O(1)
        */

        public static bool IsValid(string s)
        {
            try
            {
                Stack<char> step = new Stack<char>();

                foreach (char chr in step)
                {
                    if (chr == '(' || chr == '[' || chr == '{')
                    {
                        step.Push(chr);
                    }
                    else
                    {
                        if (step.Count == 0)
                        {
                            return false; // closing bracket do not match correctly
                        }

                        char ob = step.Pop();

                        if (chr == ')' && ob != '(')
                        {
                            return false; // Parentheses do not match correctly
                        }
                        else if (chr == ']' && ob != '[')
                        {
                            return false; // Square brackets do not match correctly
                        }
                        else if (chr == '}' && ob != '{')
                        {
                            return false; // Curly braces do not match correctly
                        }
                    }
                }

                return step.Count == 0; // Verify if any unclosed opening brackets remain within the step
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occurred: {ex.Message}");
                return false; // If an exception occurs, treat it as invalid parentheses
            }
        }

        // This issue shows the critical ability of using a stack to validate parenthesis in a string. This idea is frequently applied in programming and serves as the basis for numerous functions, including the processing and parsing of structured data.
        /*
		

        Question 3:
        You are given an array prices where prices[i] is the price of a given stock on the ith day.You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
        Example 1:
        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Example 2:
        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.
 
        Constraints:
        1 <= prices.length <= 105
        0 <= prices[i] <= 104

        Time complexity: O(n), space complexity:O(1)
        */

        public static int MaxProfit(int[] prices)
        {
            try
            {
                // Verify whether the input array is null or contains less than 2 elements
                if (prices == null || prices.Length < 2)
                {
                    // If there are insufficient days to yield a profit, return 0
                    return 0;
                }

                // Set up variables to monitor the lowest price and the highest profit
                int minp = prices[0];
                int maximump = 0;

                // Traverse the array, adjusting minp and maximump when needed
                for (int i = 1; i < prices.Length; i++)
                {
                    int variation = prices[i];
                    maximump = Math.Max(maximump, variation - minp);
                    minp = Math.Min(minp, variation);
                }

                // Output the highest achieved profit
                return maximump;
            }
            catch (Exception)
            {
                // Capture any exceptions and then repropagate them
                throw;
            }
        }

        // This issue shows how to grasp the idea of maximizing profits in stock trading. In financial and algorithmic trading scenarios, it emphasizes the significance of monitoring minimum prices and maximizing earnings.
        /*
        
        Question 4:
        Given a string num which represents an integer, return true if num is a strobogrammatic number.A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
        Example 1:

        Input: num = "69"
        Output: true
        Example 2:

        Input: num = "88"
        Output: true
        Example 3:

        Input: num = "962"
        Output: false

        Constraints:
        1 <= num.length <= 50
        num consists of only digits.
        num does not contain any leading zeros except for zero itself.

        Time complexity:O(n), space complexity:O(1)
        */

        public static bool IsStrobogrammatic(string step)
        {
            try
            {
                // Create a dictionary for storing the valid strobogrammatic pairs
                Dictionary<char, char> pairs = new Dictionary<char, char>
            {
                {'0', '0'},
                {'1', '1'},
                {'6', '9'},
                {'8', '8'},
                {'9', '6'}
            };

                int lft = 0;
                int rht = step.Length - 1;

                while (lft <= rht)
                {
                    // Verify if the characters at the left and right positions form a valid strobogrammatic pair
                    if (!pairs.ContainsKey(step[lft]) || pairs[step[lft]] != step[rht])
                    {
                        return false;
                    }

                    // Shift the pointers towards the center
                    lft++;
                    rht--;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw;
            }
        }

        // This problem helps in understanding number symmetry and investigating the idea of strobogrammatic numbers. This knowledge can be helpful in many areas, such as cryptography, where understanding palindromic integers is essential.
        /*

        Question 5:
        Given an array of integers nums, return the number of good pairs.A pair (i, j) is called good if nums[i] == nums[j] and i < j. 

        Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.
        Example 3:

        Input: nums = [1,2,3]
        Output: 0

        Constraints:

        1 <= nums.length <= 100
        1 <= nums[i] <= 100

        Time complexity:O(n), space complexity:O(n)

		*/

        public static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                // Initialize a dictionary for keeping track of the count of each number
                Dictionary<int, int> maps = new Dictionary<int, int>();
                int lpu = 0;

                foreach (int no in nums)
                {
                    // If the number is present in the dictionary, increase its count
                    if (maps.ContainsKey(no))
                    {
                        lpu += maps[no];
                        maps[no]++;
                    }
                    else
                    {
                        maps[no] = 1;
                    }
                }

                return lpu;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // This problem shows how to quickly count identical pairs within an array. When data needs to be examined for patterns and frequencies, like in market research and data analysis, this ability is generally relevant.
        /*
        Question 6

        Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

        Example 1:

        Input: nums = [3,2,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2.
        The third distinct maximum is 1.
        Example 2:

        Input: nums = [1,2]
        Output: 2
        Explanation:
        The first distinct maximum is 2.
        The second distinct maximum is 1.
        The third distinct maximum does not exist, so the maximum (2) is returned instead.
        Example 3:

        Input: nums = [2,2,3,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2 (both 2'step are counted together since they have the same value).
        The third distinct maximum is 1.
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1

        Time complexity:O(nlogn), space complexity:O(no)
        */

        public static int ThirdMax(int[] nums)
        {
            try
            {
                // Declare three long variables for keeping track of the first (ft), second (sd), and third (td) maximum values
                long ft = long.MinValue; // Declare first maximum as the smallest possible long value.
                long sd = long.MinValue; // Declare the second maximum as the smallest possible long value
                long td = long.MinValue; //Declare the third maximum as the smallest possible long value
            // Iterations through 'nums' collection to identify the three highest values

            foreach (int aish in nums)
                {
                    // If 'aish' is greater than 'ft', update 'td' and 'sd' as below
                    if (aish > ft)
                    {
                        td = sd;
                        sd = ft;
                        ft = aish;
                    }
                    else if (aish < ft && aish > sd)
                    {
                        // If 'aish' is between 'ft' and 'sd', update 'td' and 'sd' as below
                        td = sd;
                        sd = aish;
                    }
                    else if (aish < sd && aish > td)
                    {
                        // If 'aish' is between 'sd' and 'td', update 'td' as below.
                        td = aish;
                    }
                }
                // Determine if a valid third maximum exists, meaning it was not initialized with the smallest long value

                if (td == long.MinValue)
                {
                    // Return the second maximum value as an integer.
                    return (int)ft;
                }
                //Return the third maximum value as an integer

            return (int)td;
            }
            catch (Exception)
            {
                // Handle any exceptions that may occur during the process and rethrow them.
                throw;
            }
        }

        // This problem helps in determining the third largest number in an array. It challenges them to consider how to manage uncommon situations and keep track of many maximum values—skills crucial for data analysis and competitive programming.
        /*
        
        Question 7:

        You are playing a Flip Game with your friend. You are given a string currentState that contains only '+' and '-'. You and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move, and therefore the other person will be the winner.Return all possible states of the string currentState after one valid move. You may return the answer in any order. If there is no valid move, return an empty list [].
        Example 1:
        Input: currentState = "++++"
        Output: ["--++","+--+","++--"]
        Example 2:

        Input: currentState = "+"
        Output: []
 
        Constraints:
        1 <= currentState.length <= 500
        currentState[i] is either '+' or '-'.

        Timecomplexity:O(no), Space complexity:O(no)
        */

        public static IList<string> GeneratePossibleNextMoves(string currentState)
        {
            try
            {
                // Create a list of strings to store possible next states
                List<string> usp = new List<string>();
                // Iterate through the 'currentState' string to find instances of "++."

                for (int i = 0; i < currentState.Length - 1; i++)
                {
                    if (currentState[i] == '+' && currentState[i + 1] == '+')
                    {
                        // Create a new character array ('nst') from the 'currentState' string.
                        char[] nst = currentState.ToCharArray();
                        // Replace the "++" with "--" to create a new state, and add it to 'usp.'
                        nst[i] = '-';
                        nst[i + 1] = '-';
                        usp.Add(new string(nst));
                    }
                }
                // Return the list of possible next states

                return usp;
            }
            catch (Exception)
            {
                // Handle any exceptions that may occur during the process and rethrow them.
                throw;
            }
        }

        // This problem shows how to manipulate strings to generate every conceivable state for the following game. The creation of video games and simulation environments both benefit from this problem-solving ability.
        /*

        Question 8:

        Given a string step, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:

        Input: step = "leetcodeisacommunityforcoders"
        Output: "ltcdscmmntyfrcdrs"

        Example 2:

        Input: step = "aeiou"
        Output: ""

        Timecomplexity:O(no), Space complexity:O(no)
        */

        public static string RemoveVowels(string step)
        {
            try
            {
                // Initialize a StringBuilder for constructing the final string
                StringBuilder result = new StringBuilder();

                foreach (char ch in step)
                {
                    // Verify if the character is a consonant, and if it is, add it to the result
                    if (ch != 'a' && ch != 'e' && ch != 'i' && ch != 'o' && ch != 'u')
                    {
                        result.Append(ch);
                    }
                }

                return result.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it'step the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<string> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "\"" + input[i] + "\""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}

// This exercise demonstrates how to modify strings so that certain characters—in this case, vowels—are removed. For jobs involving text processing, data cleaning, and natural language processing, this ability is necessary.
