using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

        public static void RandomAct()
        {         
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);               
                }

                Console.WriteLine();

                Console.Write("Choosing your random activity");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);              
                }

            return;
        }
        static void Main(string[] args)
        {
            Random rng = new Random();

            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");

            var genAnswer = Console.ReadLine().ToLower();
            do
            {
                if (genAnswer == "yes")
                {
                    cont = true;
                    break;
                }
                else if (genAnswer == "no")
                {
                    Console.WriteLine("Have a good day!");
                    Process.GetCurrentProcess().Kill();
                }
                else
                {
                    Console.WriteLine("Please enter yes/no");
                    genAnswer = Console.ReadLine().ToLower();
                }
            }while(genAnswer != "yes" || genAnswer != "no");

            Console.WriteLine();

            Console.Write("We are going to need your information first! What is your name? ");

            string userName = Console.ReadLine();

            Console.WriteLine();

            Console.Write("What is your age? ");

            var userAge = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            Console.WriteLine();

            bool seeList = true;
            var ansList = Console.ReadLine().ToLower();
            do
            {
                if (ansList == "sure")
                {
                    break;
                }
                else if (ansList == "no thanks")
                {
                    seeList = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter sure/no thanks");
                    ansList = Console.ReadLine().ToLower();
                }
            } while (ansList != "sure" || ansList != "no thanks");

            do
            {
                if (seeList == true)
                {
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }
                    break;
                }
                else if (seeList == false)
                {
                    Console.WriteLine("Are you sure you don't want to see the list?");
                    Console.WriteLine("Please enter yes/no");

                    var checkAns = Console.ReadLine().ToLower();

                    Console.WriteLine();

                    do
                    {
                        if (checkAns == "yes")
                        {
                            Console.WriteLine("Have it your way");
                            seeList = false;
                            break;
                        }
                        else if (checkAns == "no")
                        {
                            seeList = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter yes/no");
                            checkAns = Console.ReadLine().ToLower();
                        }
                    }while(checkAns != "no" || checkAns != "yes");               

                }
                if (seeList == false)
                {
                    break;
                }

            }while(seeList != true || seeList != false);

            Console.WriteLine();

            Console.Write("Would you like to add any activities before we generate one? yes/no: ");

            bool addToList = true;

            var actAns = Console.ReadLine().ToLower();

            if (actAns == "no")
            {
                addToList = false;
            }
            else if (actAns == "yes")
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
            }
         
            Console.WriteLine();

            while(addToList == true)
            {
                Console.Write("What would you like to add? ");

                string userAddition = Console.ReadLine();
                    
                activities.Add(userAddition);

                Console.WriteLine("Would you like to add more? yes/no: ");

                var actCont = Console.ReadLine().ToLower();
                if (actCont == "no")
                {
                    break;
                }
                
            }
           
            Console.WriteLine();

            RandomAct();

            Console.WriteLine();

            int randomNumber = rng.Next(activities.Count);

            string randomActivity = activities[randomNumber];

            if (userAge < 21 && randomActivity == "Wine Tasting")
            {
                Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                Console.WriteLine("Pick something else!");
                activities.Remove(randomActivity);                
            }

            Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");

            Console.WriteLine();

            string redoKeep;

            do
            {
                redoKeep = Console.ReadLine().ToLower();

                if (redoKeep == "keep")
                {
                    Console.WriteLine("Have Fun!");
                    break;
                }
                else
                {
                    RandomAct();

                    Console.WriteLine();
                   
                    randomNumber = rng.Next(activities.Count);

                    randomActivity = activities[randomNumber];

                    if (userAge < 21 && randomActivity == "Wine Tasting")
                    {
                        Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                        Console.WriteLine("Pick something else!");
                        activities.Remove(randomActivity);
                    }

                    Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                }
            } while (redoKeep != "keep" || redoKeep != "redo");
          
            
        }
    
    }
    
}