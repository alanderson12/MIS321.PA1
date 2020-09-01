using System.Collections.Generic;
using System;
using System.IO;

namespace PA1
{
    public class PostUtils : Post
    {
        
        List<Post> posts = new List<Post>();
        
        //Print All Posts method
        public static void PrintAllPosts(List<Post> posts)
        {
            foreach(Post post in posts)
            {
                Console.WriteLine(post.ToString());
            }
        }

        //Add Post method
        public static void AddPost(List<Post> bigAlPosts)
        {
            //declare variables 
            int count = bigAlPosts.Count;
            string newPostText = "";
            string newTimestamp = "";
            Post myPost = new Post(){PostID = count + 1, PostText = "", Timestamp = ""};

            //ask for user input
            Console.WriteLine("Post Text: ");
            newPostText = Console.ReadLine();

            //date error handling
            DateTime date;
            while (true)
            {
                Console.Write("Post Date (mm/dd/yyyy): ");
                newTimestamp = Console.ReadLine();
                date = DateTime.Parse(newTimestamp);
                if (date < DateTime.Today)
                {
                    Console.WriteLine("Please enter a valid date. ");
                    continue;
                }
                else
                {
                    break;
                }
            }

            //new post is created
            bigAlPosts.Add(new Post() {PostID = count + 1, PostText = newPostText, Timestamp = newTimestamp});

            //new post is written to file
            StreamWriter outFile = new StreamWriter("posts.txt", true);

            Console.WriteLine("\nYour post was added to the file! ");

            //posts are saved and printed to screen for user
            Post.SavePosts(bigAlPosts);
            PrintAllPosts(bigAlPosts);

            outFile.Close();
        }

        //Delete Post method
        public static void DeletePost(List<Post> posts)
        {
            Post[] myPosts = new Post[100];
            PostFile postFile = new PostFile();

            //variable declared
            int removedPost = 0;

            PostFile.GetPosts();
            Console.WriteLine("Which post would you like removed from the file? (give a number) ");
            PrintAllPosts(posts);

            //get user input
            removedPost = int.Parse(Console.ReadLine());
            
            //remove post
            posts.RemoveAt(removedPost - 1);
            StreamWriter outFile = new StreamWriter("posts.txt");

            //update file
            foreach(Post post in posts)
            {
                outFile.WriteLine(post.ToFile());
            }
            
            

            Console.WriteLine("Your post was removed from the file! ");
            //show updated file to user
            foreach(Post post in posts)
            {
                Console.WriteLine(post.ToString());
            }

            outFile.Close();
        }
    }
}