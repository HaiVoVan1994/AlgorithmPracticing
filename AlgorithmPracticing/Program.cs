using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AlgorithmPracticing
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        /************** Medium ***********/
        #region Roman Numeral Converter
        private static string RomanNumeralConverter(int number)
        {
            // var result = RomanNumeralConverter(43);
            var decimalValue = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            var romanNumeral = new string[] {"M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            var result = "";
            for (var index = 0; index < decimalValue.Length; index++)
            {
                while (decimalValue[index] <= number)
                {
                    result += romanNumeral[index];
                    number -= decimalValue[index];
                }
            }

            return result;
        }
        #endregion

        #region Check Palindrome
        private static bool CheckPalindrome(string str)
        {
            //var str = "blmossomla";
            //var result = CheckPalindrome(str);

            str = Regex.Replace(str, "[^a-zA-Z0-9]", string.Empty);
            var length = str.Length;
            for (var i = 0; i < (length / 2); i++)
            {
                if (str[i] != str[length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Rotting Oranges
        private static int OrangesRotting(int[,] grid)
        {
            //int[,] grid = new int[3, 3] { { 2, 1, 1 }, { 1, 1, 0 }, { 0, 1, 1 } };
            //var result = OrangesRotting(grid);

            if (grid.GetLength(0) > 0 && grid.GetLength(0) > 0)
            {
                if (grid[0, 0] != 2) return 0;
                var count = 0;
                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    for (int j = 0; j < grid.GetLength(1); j++)
                    {
                        DFSOranges(grid, i, j, count);
                    }
                }
            }
            return 0;
        }

        private static int DFSOranges(int[,] grid, int i, int j, int count)
        {
            if (i < 0 || j < 0 || i >= grid.GetLength(0) || j >= grid.GetLength(1))
            {
                return 0;
            }

            if (grid[i, j] == 0)
            {
                return 0;
            }

            if (grid[i, j] == 1)
            {
                grid[i, j] = 2;
            }

            var check = (DFSOranges(grid, i, j + 1, count) +
                         DFSOranges(grid, i, j - 1, count) +
                         DFSOranges(grid, i + 1, j, count) +
                         DFSOranges(grid, i - 1, j, count));
            if (check != 0)
            {
                count++;
            }
            else
            {
                count = -1;
            }
            return 0;
        }

        #endregion

        #region Surrounded Regions : https://leetcode.com/problems/surrounded-regions/
        //private static void Solve(char[,] board)
        //{
        //   //char[,] board = new char[4, 4]
        //   //{
        //   //     { 'X', 'X', 'X', 'X' },
        //   //     { 'X', 'O', 'O', 'X' },
        //   //     { 'X', 'X', 'O', 'X' },
        //   //     { 'X', 'O', 'X', 'X' }
        //   //};

        //   // Solve(board);

        //    var visited = new char[board.GetLength(1), board.GetLength(2)];
        //    for (int i = 0; i < board.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < board.GetLength(1); j++)
        //        {
        //            DFS(board, i, j, visited);
        //        }
        //    }
        //}

        //private static bool DFS(char[,] board, int i, int j, char[,] visited)
        //{
        //    if (i < 0 || j < 0 || i >= board.GetLength(0) || j >= board.GetLength(1))
        //    {
        //        return true;
        //    }

        //    if (board[i, j] == 'X')
        //    {
        //        return false;
        //    }


        //    if (board[i, j] == 'O')
        //    {

        //        var found = 
        //            (DFS(board, i, j + 1, visited) ||
        //            (DFS(board, i, j - 1, visited) ||
        //            (DFS(board, i - 1, j, visited) ||
        //            (DFS(board, i + 1, j, visited) ||


        //    }
        //    //{
        //    //    if (
        //    //    {
        //    //        return;
        //    //    }
        //    //    board[i, j] = 'X';
        //    //}
        //}
        #endregion

        #region Word Search: https://leetcode.com/problems/word-search/
        static private bool WordSearch(char[,] board, string word)
        {
            //char[,] board = new char[3, 4] {
            //    {'A', 'B', 'C', 'E' },{'S', 'F', 'C', 'S' },{'A', 'D', 'E', 'E' }
            //};

            //string word = "ABCCED";
            //WordSearch(board, word);

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == word.ElementAt(0) && DFS(board, i, j, 0, word))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static private bool DFS(char[,] board, int i, int j, int indexWord, string word)
        {
            if (indexWord == word.Length - 1)
            {
                return true;
            }

            if (i < 0 || j < 0 || i >= board.GetLength(0) || j >= board.GetLength(1) || board[i, j] != word[indexWord])
            {
                return false;
            }

            var temp = board[i, j];
            board[i, j] = ' ';

            if (DFS(board, i, j + 1, indexWord + 1, word) ||
            DFS(board, i, j - 1, indexWord + 1, word) ||
            DFS(board, i + 1, j, indexWord + 1, word) ||
            DFS(board, i - 1, j, indexWord + 1, word))
            {
                return true;
            }

            board[i, j] = temp;
            return false;
        }
        #endregion

        #region FindSubsequences: https://leetcode.com/problems/increasing-subsequences/
        static private void FindSubsequences(List<int> nums, List<List<int>> output, int startIndex, List<int> curr)
        {
            //List<int> nums = new List<int> { 4, 6, 7, 7 };
            //List<List<int>> output = new List<List<int>>();
            //FindSubsequences(nums, output, 0, new List<int>());

            AddCurrToOutPut(curr, output);
            for (int i = startIndex; i < nums.Count; i++)
            {
                if (curr.Count == 0 || curr[curr.Count - 1] <= nums[i])
                {
                    curr.Add(nums[i]);
                }
                FindSubsequences(nums, output, i + 1, curr);
                curr.RemoveAt(curr.Count - 1);
            }
        }
        static private void AddCurrToOutPut(List<int> curr, List<List<int>> output)
        {
            if (curr.Count >= 2)
            {
                var isExits = false;
                for (int i = 0; i < output.Count; i++)
                {
                    if (!curr.SequenceEqual(output[i]))
                    {
                        continue;
                    }
                    else
                    {
                        isExits = true;
                        break;
                    }
                }
                if (!isExits)
                {
                    List<int> listTemp = new List<int>(curr);
                    output.Add(listTemp);
                }
            }
        }
        #endregion

        #region Lemonade Change: https://leetcode.com/problems/lemonade-change/
        static private bool LemonadeChange(int[] bills)
        {
            //var bills = new int[5] { 5, 5, 10, 10, 20 };
            //LemonadeChange(bills);

            var result = true;
            int five = 0;
            int tens = 0;
            for (int i = 0; i < bills.Length; i++)
            {
                if (bills[i] == 5)
                {
                    five += 5;
                }
                else if (bills[i] == 10)
                {
                    if (five >= 5)
                    {
                        five -= 5;
                        tens += 10;
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
                else if (bills[i] == 20)
                {
                    if (tens > 0 && five > 0)
                    {
                        tens -= 10;
                        five -= 5;
                    }
                    else if (five >= 15)
                    {
                        five -= 15;
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }
        #endregion

        #region Combinations: https://leetcode.com/problems/combinations/
        static private void CombineBackTrack(int n, int k, IList<IList<int>> output, int first, List<int> curr)
        {
            //int n = 3, k = 2;
            //IList<IList<int>> output = new List<IList<int>>();
            //CombineBackTrack(n, k, output, 1, new List<int>());

            if (curr.Count == k)
            {
                output.Add(new List<int>(curr));
            }
            for (int i = first; i < n + 1; i++)
            {
                curr.Add(i);
                CombineBackTrack(n, k, output, i + 1, curr);
                curr.RemoveAt(curr.Count - 1);
            }
        }
        #endregion

        #region PartitionLabels: https://leetcode.com/problems/partition-labels/
        static private IList<int> PartitionLabels(string s)
        {
            int[] positions = new int[26];
            for (int i = 0; i < s.Length; i++)
                positions[s[i] - 'a'] = i;
            var result = new List<int>();
            int maxPosition = 0;
            int previous = 0;
            for (int i = 0; i < s.Length; i++)
            {
                // current character max position.
                maxPosition = Math.Max(maxPosition, positions[s[i] - 'a']);
                if (maxPosition == i)
                {
                    result.Add(i - previous + 1);
                    previous = i + 1;
                }
            }

            return result;
        }
        #endregion

        #region Remove All Occurrences of a Substring : https://leetcode.com/problems/remove-all-occurrences-of-a-substring/
        static private void RemoveOccurrences(ref string s, string part)
        {
            //  string s = "daabcbaabcbc", part = "abc";

            // Second method
            do
            {
                var index = s.IndexOf(part);

                if (index == -1) break;

                s = s.Remove(index, part.Length);
            } while (true);

            /// First method
            //if (s.Length < part.Length)
            //{
            //    return;
            //}

            //int i = 0;
            //int j = 0;
            //var tempString = string.Empty;
            //while (i < s.Length) {
            //    while (j < (i + part.Length) && j < s.Length)
            //    {
            //        tempString += s[j];
            //        j++;
            //    }

            //    if (tempString == part)
            //    {
            //        s = s.Remove(i, part.Length);
            //        i--;
            //    }
            //    else
            //    {
            //        i++;
            //    }
            //    j = i;
            //    tempString = string.Empty;
            //}
        }

        #endregion

        /*************** Easy *************/
        #region Find the Median
        private static int findMedian(List<int> nums)
        {
            //findMedian(new List<int> { 3, 4, 5, 1, 6, 7, 0, 45, 12, 65, 16 });

            nums.Sort();
            return nums[nums.Count / 2 - 1];
        }
        #endregion

        #region Mars Exploration
        private static int MarsExploration(string message)
        {
            // var abc = MarsExploration("SOSSPSSQSSOR");

            string sos = "SOS";
            var diff = 0;
            for (int i = 0; i < message.Length; i++)
            {
                if (message.ElementAt(i) != sos.ElementAt(i % 3))
                {
                    diff++;
                }
            }
            return diff;

            //var diff = 0;
            //for (int i = 0; i < message.Length; i +=3)
            //{
            //    if (message[i] != 'S')
            //    {
            //        diff++;
            //    }
            //    if (message[i + 1] != 'O') 
            //    {
            //        diff++;
            //    }
            //    if (message[i + 2] != 'S')
            //    {
            //        diff++;
            //    }
            //}
            //return diff;
        }
        #endregion

        #region CheckIfPangram: https://leetcode.com/problems/check-if-the-sentence-is-pangram/
        static private bool CheckIfPangram(string s)
        {
            //string s = "leetcode";
            //var result = false;
            if (s.Length < 26) return false;

            Dictionary<int, int> countChar = new Dictionary<int, int>();
            for (int i = 0; i < s.Length; i++)
            {
                int charToInt = (int)s[i];
                if (!countChar.ContainsKey(charToInt))
                {
                    countChar.Add(charToInt, 0);
                }
            }
            if (countChar.Count >= 26)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region SortSentence : https://leetcode.com/problems/sorting-the-sentence/
        static private void SortSentence()
        {
            string s = "is2 sentence4 This1 a3";
            string result = string.Empty;
            var temp = s.Split(' ');
            var ans = new string[temp.Length];

            foreach (var word in temp)
            {
                ans[(int)word.Last() - 48 - 1] = word.Substring(0, word.Length - 1);
            }

            result = String.Join(" ", ans);
        }
        #endregion

        #region BalancedStringSplit: https://leetcode.com/problems/split-a-string-in-balanced-strings/
        static private void BalancedStringSplit()
        {
            string s = "RLLLLRRRLR";
            var res = 0;

            if (s.Length == 1)
            {
                res = 0;
            }

            var count = 0;
            var i = 0;

            while (i < s.Length)
            {
                if (s[i] == 'R')
                    count++;
                if (s[i] == 'L')
                    count--;

                if (count == 0)
                {
                    res++;
                }
                i++;
            }
        }
        #endregion

        #region ShuffleString : https://leetcode.com/problems/shuffle-string/
        private static void ShuffleString()
        {
            string s = "aaiougrt";
            int[] indices = { 4, 0, 2, 6, 7, 3, 1, 5 };
            string outPut = string.Empty;

            if (s.Length == 1)
            {
                outPut = s;
            }

            for (int i = 0; i < indices.Length; i++)
            {
                var indexCharacter = Array.IndexOf(indices, i);
                outPut = outPut + s[indexCharacter];
            }
        }
        #endregion

        #region SuperReducedString
        private static void SuperReducedString()
        {
            var input = "aaabccddd";

            var inputLength = input.Length;
            var result = string.Empty;
            if (input.Length < 2)
            {
                result = input;
            }

            var i = 0;
            while (i < input.Length - 1)
            {
                if (input[i] == input[i + 1])
                {
                    input = input.Remove(i, 2);
                    if (i != 0) i--;
                }
                else
                {
                    i++;
                }
            }
        }
        #endregion

        #region FindDigits
        private static void FindDigits()
        {
            var number = 1024;

            var count = 0;
            while (number > 0)
            {
                var digit = number % 10;
                if (digit != 0 && number % digit == 0)
                {
                    count++;
                }
                number = number / 10;
            }
        }

        #endregion

        #region FindCavities
        private static void FindCavities()
        {
            int[,] map = new int[4, 4];
            map[0, 0] = 1; map[0, 1] = 1; map[0, 2] = 1; map[0, 3] = 2;
            map[1, 0] = 1; map[1, 1] = 9; map[1, 2] = 1; map[1, 3] = 2;
            map[2, 0] = 1; map[2, 1] = 8; map[2, 2] = 9; map[2, 3] = 2;
            map[3, 0] = 1; map[3, 1] = 2; map[3, 2] = 3; map[3, 3] = 4;

            for (int i = 1; i < map.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < map.GetLength(1) - 1; j++)
                {
                    if (map[i, j] > map[i - 1, j] && map[i, j] > map[i + 1, j] ||
                        (map[i, j] > map[i, j - 1]) && map[i, j] > map[i, j + 1])
                        map[i, j] = -1;
                }
            }
        }
        #endregion

        #region FairRations
        private static void FairRations()
        {
            var numbers = new List<int> { 1, 3, 4, 7, 6 };
            var loaves = 0;
            var result = string.Empty;

            if (!numbers.Exists(x => x > 0 && (x % 2) == 0))
            {
                result = "No";
            }

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    numbers[i] += 1;
                    numbers[i + 1] += 1;
                    loaves += 2;
                }
            }

            if (numbers[numbers.Count - 1] % 2 != 0)
            {
                result = "No";
            }

            result = "Yes";
        }
        #endregion

        #region MiniMaxSum
        private static void MiniMaxSum()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            var max = 0;
            var min = 0;
            var total = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                total += numbers[i];
            }

            max = total - numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                var temp = total - numbers[i];
                if (temp > max)
                    max = temp;
            }

            min = total - numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                var temp = total - numbers[i];
                if (temp < min)
                    min = temp;
            }
        }
        #endregion

        #region Equalize the Array
        private static void EqualizeTheArray()
        {
            var numbers = new List<int> { 1, 2, 3 };
            var result = 0;

            if (numbers.Count == 1)
                result = 0;

            var numberAndTimeShowing = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numberAndTimeShowing.ContainsKey(numbers[i]))
                {
                    numberAndTimeShowing[numbers[i]] = numberAndTimeShowing[numbers[i]] + 1;
                }
                else
                {
                    numberAndTimeShowing.Add(numbers[i], 1);
                }
            }

            result = numbers.Count - numberAndTimeShowing.Values.Max();
        }

        #endregion

        #region MinimumLoss
        //private static int MinimumLoss(List<int> prices)
        //{
        //List<int> prices = new List<int> { 15, 3, 6, 20, 8 };
        //var result = MinimumLoss(prices);

        //    prices.Sort();
        //    var minimunLost = int.MaxValue;
        //    for (int i = 0; i < prices.Count; i++)
        //    {
        //        if (i + 1 >= prices.Count)
        //            break;

        //        var differences = prices[i + 1] - prices[i];
        //        if (differences > 0 && differences < minimunLost)
        //            minimunLost = differences;
        //    }
        //    return minimunLost;
        //}
        #endregion

        #region DrawStar
        //private static void DrawStar()
        //{
        //    int n = 3;
        //    for (int i = 1; i <= n; ++i)
        //    {
        //        for (int j = 1; j <= n; ++j)
        //        {
        //            if (j <= n - i)
        //            {
        //                Console.Write(" ");
        //            }
        //            else
        //            {
        //                Console.Write("#");
        //            }
        //        }
        //        Console.WriteLine();
        //    }
        //}
        #endregion

        #region WaysToCompleteStair
        private static int WaysToCompleteStair(int stairCase, List<int> steps, int total)
        {
            //var stairCase = 3;
            //var steps = new List<int> { 1, 2, 3 };
            //var result = WaysToCompleteStair(stairCase, steps, 0);

            if (stairCase == 0)
                return total += 1;

            for (int i = 0; i < steps.Count; i++)
            {
                var step = stairCase - steps[i];
                if (step >= 0)
                {
                    total = WaysToCompleteStair(step, steps, total);
                }
            }
            return total;
        }
        #endregion

        #region AppendandDelete
        private static string AppendandDelete(string initString, string desiredString, int operations)
        {
            //var initString = "ab";
            //var desiredString = "aba";
            //var operations = 4;
            //var result = AppendandDelete(initString, desiredString, operations);

            var initStringLength = initString.Length;
            var desiredStringLength = desiredString.Length;
            var differences = 0;
            var sameString = string.Empty;

            int i = 0;
            while (i < initStringLength && i < desiredStringLength)
            {
                if (initString[i] == desiredString[i])
                {
                    sameString = sameString + initString[i];
                    i++;
                }
                else
                {
                    break;
                }
            }
            differences = sameString.Length;

            if (operations - ((initStringLength - differences) + (desiredStringLength - differences)) >= 0)
            {
                return "Yes";
            }
            return "No";

        }
        #endregion

        #region FindBeautifulDay
        private static List<int> FindBeautifulDay(int start, int end, int divisor)
        {
            //var start = 20;
            //var end = 23;
            //var divisor = 6;

            //var result = FindBeautifulDay(start, end, divisor);
            var day = start;
            var result = new List<int>();
            while (day >= start && day <= end)
            {
                var isBeautifulDay = Math.Abs(day - numberReversed(day)) % divisor;
                if (isBeautifulDay == 0)
                    result.Add(day);
                day++;
            }
            return result;
        }
        #endregion

        #region numberReversed
        private static int numberReversed(int number)
        {
            if (number < 10)
                return number;

            var reveredNumberString = string.Empty;
            while (number > 0)
            {
                reveredNumberString = reveredNumberString + (number % 10);
                number = number / 10;
            }
            return int.Parse(reveredNumberString);
        }
        #endregion

        #region findViralPeople
        private static int findViralPeople(int dayOfEvents)
        {
            //var dayOfEvents = 5;
            //var result = findViralPeople(dayOfEvents);
            var result = 2;
            if (dayOfEvents == 1)
                return result;

            int i = 2;
            var j = dayOfEvents;
            while (j > 1)
            {
                var numberViralPerDays = (i * 3) / 2;
                result = result + numberViralPerDays;
                i = numberViralPerDays;
                j--;
            }
            return result;
        }
        #endregion

        #region WarnPrisoner
        private static int WarnPrisoner(int numberOfPrisoners, int startIndex, int numberOfCandies)
        {
            //var numberOfPrisoners = 5;
            //var startIndex = 2;
            //var numberOfCandies = 1;
            //var result = WarnPrisoner(numberOfPrisoners, startIndex, numberOfCandies);
            if (numberOfPrisoners == 1)
            {
                return numberOfPrisoners;
            }

            if (numberOfCandies == 1 && startIndex == 1)
            {
                return 1;
            }

            var result = 0;
            var i = startIndex;

            while (numberOfCandies > 0)
            {
                if (i > numberOfPrisoners)
                {
                    i = 1;
                }
                result = i;
                i++;
                numberOfCandies--;
            }
            return result;
        }
        #endregion

        #region findMinimumTurnsPage
        private static int findMinimumTurnsPage(int numberOfPages, int findingPage)
        {
            var indexPages = numberOfPages / 2;
            var indexFindingPages = findingPage / 2;

            var turnPageFromBegining = Math.Abs(0 - indexFindingPages);
            var turnPageFromEnding = Math.Abs(indexPages - indexFindingPages);
            if (turnPageFromBegining < turnPageFromEnding)
                return turnPageFromBegining;
            else if (turnPageFromBegining > turnPageFromEnding)
                return turnPageFromEnding;
            else
                return turnPageFromEnding;
        }
        #endregion

        #region ConvertTimeToMilitaryFormat
        private static string ConvertTimeToMilitaryFormat(string input)
        {
            //var input = "12:15:00PM";
            //var result = ConvertTimeToMilitaryFormat(input);
            //Console.WriteLine("result: " + result);
            //Console.ReadLine();

            //var numberOfPages = 10;
            //var findingPage = 3;
            //var result = findMinimumTurnsPage(numberOfPages, findingPage);

            var result = input;
            var subfixTime = result.Substring(2, 6);
            var hoursString = result.Substring(0, 2);
            var hour = int.Parse(hoursString);

            if (result[8] == 'A' && hour == 12)
            {
                hoursString = "00";
            }
            else if (result[8] == 'P' && hour < 12)
            {
                hoursString = (hour + 12).ToString();
            }
            return hoursString + subfixTime;
        }
        #endregion
    }
}
