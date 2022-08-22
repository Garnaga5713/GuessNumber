using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("num of players:");
            int cnt = int.Parse(Console.ReadLine());
            string[,] User = new string[cnt, 2];

            for (int i = 0; i < cnt; i++)//create user and check is it bot
            {
                Console.Write("User {0} name: ", (i + 1));
                User[i, 0] = Console.ReadLine();
                Console.Write("User is bot: (y/n): ");
                User[i, 1] = Console.ReadLine();
            }

            int min_num = 0, max_num = 1000;//input min,max number by user
            Console.Write("Min number: ");
            min_num = int.Parse(Console.ReadLine());
            Console.Write("Max number: ");
            max_num = int.Parse(Console.ReadLine());

            Random random = new Random();
            int gameNumber = random.Next(min_num, max_num);//number to guess

            bool win = false;
            int userTry=0;

            while (!win)
            {
                for (int i = 0; i < User.GetLength(0); i++)
                {
                    Console.WriteLine("diapason: " + min_num + "-" + max_num);

                    if (User[i, 1] == "n")//if user is not bot
                    {
                        Console.Write(User[i, 0] + " your number: ");
                        userTry = int.Parse(Console.ReadLine());
                    }
                    else if (User[i, 1] == "y")// if user is bot
                    {
                        userTry = random.Next(min_num, max_num);
                        Console.WriteLine(User[i, 0] + " number: " + userTry);
                    }

                    if (userTry == gameNumber)//if user guess num
                    {
                        Console.WriteLine(User[i, 0] + " win!");
                        win = true;
                    }
                    else//if user not guess num
                    {
                        if (userTry < gameNumber)// if user num lower than guess num
                        {
                            min_num = userTry;
                        }
                        if (userTry > gameNumber)// if user num higher than guess num
                        {
                            max_num = userTry;
                        }
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
