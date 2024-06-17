using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment_5._3
{
    internal class Program
    {
        #region Formatting

        static void Introduction()
        {
            // HEADER
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Assignment 5.3");
            Console.WriteLine("Name: Isaac Jang\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n---------------PART 1---------------\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Transition()
        {
            // TRANSITION
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nPress any key to continue!\n");
            Console.ReadKey();
        }

        static void Part(int i)
        {
            // PART 2
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n---------------PART {i}---------------\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void ClosingMessage()
        {
            // CLOSING MESSAGE
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\nHave a great day!");
        }
        #endregion

        static void Main(string[] args)
        {
            Introduction(); StartPoint1:

            /*1.You have a long flowerbed in which some of the plots are planted, and some are not. However, flowers cannot be planted in adjacent plots.
            Given an integer array flowerbed containing 0's and 1's, where 0 means empty and 1 means not empty, and an integer n, return true if n new flowers can be planted in the flowerbed without violating the no-adjacent - flowers rule and false otherwise.
            Example 1:
            Input: flowerbed = [1, 0, 0, 0, 1], n = 1
            Output: true

            Example 2:
            Input: flowerbed = [1, 0, 0, 0, 1], n = 2
            Output: false
            */

            // Ask the user for input
            Console.WriteLine("Enter the flowerbed array, separated by commas (Example: 1,0,0,0,1)");
            string input = Console.ReadLine();

            // Parse the input into an integer array
            int[] flowerbed = Array.ConvertAll(input.Split(','), int.Parse);

            // Ask the user for the number of flowers
            Console.WriteLine("Enter the number of flowers to place:");
            int n = int.Parse(Console.ReadLine());

            bool canPlace = CanPlaceFlowers(flowerbed, n);

            if (canPlace)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{canPlace}: {n} flowers can be placed in flowerbed [{input}]");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{CanPlaceFlowers(flowerbed, n)}: {n} flowers can NOT be placed in flowerbed [{input}]");
                Console.ForegroundColor = ConsoleColor.White;
            }
    
            TryAgain1:

            try
            {
                while (true)
                {
                    // ask user if they want to try again
                    Console.WriteLine("\nWant to try again? (Y / N)");
                    char answer = char.Parse(Console.ReadLine().ToUpper());

                    // wants to continue
                    if (answer == 'Y')
                    {
                        goto StartPoint1;
                    }

                    // does not want to continue
                    else if (answer == 'N')
                    {
                        break;
                    }

                    // invaid entry
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nEnter valid character");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvaild Answer Choice\n");
                Console.ForegroundColor = ConsoleColor.White;
                goto TryAgain1;
            }


            Transition(); Part(2); StartPoint2:

            /*
            2.You are climbing a staircase. It takes n steps to reach the top.
            Each time you can either climb 1 or 2 steps.In how many distinct ways can you climb to the top?
            Example 1:
            Input: n = 2
            Output: 2
            Explanation: There are two ways to climb to the top.
            1. 1 step + 1 step
            2. 2 steps

            Example 2:
            Input: n = 3
            Output: 3
            Explanation: There are three ways to climb to the top.
            1. 1 step + 1 step + 1 step
            2. 1 step + 2 steps
            3. 2 steps + 1 step*/

            // Ask the user for the number of steps
            Console.Write("Enter the number of steps to climb:");
            int steps = int.Parse(Console.ReadLine());

            int ways = ClimbStairs(steps);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"There are {ways} distinct ways to climb to the top of {steps} steps.");
            Console.ForegroundColor = ConsoleColor.White;

            TryAgain2:
        
            try
            {
                while (true)
                {
                    // ask user if they want to try again
                    Console.WriteLine("\nWant to try again? (Y / N)");
                    char answer = char.Parse(Console.ReadLine().ToUpper());

                    // wants to continue
                    if (answer == 'Y')
                    {
                        goto StartPoint2;
                    }

                    // does not want to continue
                    else if (answer == 'N')
                    {
                        break;
                    }

                    // invaid entry
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nEnter valid character");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvaild Answer Choice\n");
                Console.ForegroundColor = ConsoleColor.White;
                goto TryAgain2;
            }
            ClosingMessage(); Console.ReadKey();

        }

        static bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            int count = 0;  // To keep track of the number of flowers placed

            for (int i = 0; i < flowerbed.Length; i++)
            {
                // Check if the current plot is empty and both the previous and next plots are empty or out of bounds
                if (flowerbed[i] == 0 && (i == 0 || flowerbed[i - 1] == 0) && (i == flowerbed.Length - 1 || flowerbed[i + 1] == 0))
                {
                    flowerbed[i] = 1;  // Place a flower here
                    count++;  // Increment the flower count
                    if (count == n)  // If we have placed enough flowers, return true
                    {
                        return true;
                    }
                    i++;  // Skip the next plot
                }
            }

            return count >= n;  // Return true if we were able to place all required flowers, otherwise false
        }

        static int ClimbStairs(int n)
        {
            // Initialize variables to represent the number of ways to reach the previous two steps
            int one = 1, two = 1;

            // Loop through the steps from 0 to n-2 (since we start counting from the base case)
            for (int i = 0; i < n - 1; i++)
            {
                // Store the current value of 'one' in a temporary variable
                int temp = one;

                // Update 'one' to be the sum of 'one' and 'two', representing the new number of ways
                // to reach the current step
                one = one + two;

                // Update 'two' to be the previous value of 'one'
                two = temp;
            }

            // Return the total number of distinct ways to reach the nth step
            return one;
        }


    }
    
    
}
