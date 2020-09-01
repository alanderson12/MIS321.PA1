using System;
using System.Collections.Generic;

namespace PA1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Post> bigAlPosts = PostFile.GetPosts();
            bigAlPosts.Sort();

            //Displays main menu after getting the user menu choice
            DisplayMainMenu();
            string menuChoice = GetMenuChoice();

            //while loop for menu choice
            while (menuChoice != "4")
            {

                if (menuChoice == "1")
                {
                    Console.WriteLine("\nYou chose to show all posts! ");
                    bigAlPosts.Sort();
                    PostUtils.PrintAllPosts(bigAlPosts);
                }
                else if (menuChoice == "2")
                {
                    Console.WriteLine("\nYou chose to add a post! ");
                    PostUtils.AddPost(bigAlPosts);
                }
                else
                {
                    Console.WriteLine("\nYou chose to delete a post by ID! ");
                    PostUtils.DeletePost(bigAlPosts);
                }

                DisplayMainMenu();
                menuChoice = GetMenuChoice();
            }

            Console.WriteLine("Goodbye! ");

            Console.ReadKey();

            static string GetMenuChoice()
            {
            Console.Write("Enter a choice: ");
            return Console.ReadLine();
            }

            //method called to display main menu
            static void DisplayMainMenu()
            {
                Console.WriteLine("\n");
                Console.WriteLine("Press 1 to show all posts ");
                Console.WriteLine("Press 2 to add a post ");
                Console.WriteLine("Press 3 to delete a post by ID ");
                Console.WriteLine("Press 4 to Exit ");
            }
        }
        
    }
}
