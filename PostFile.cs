using System.IO;
using System.Collections.Generic;
using System;

namespace PA1
{
    public class PostFile
    {
        //Get Posts method
        public static List<Post> GetPosts()
        {
            List<Post> bigAlPosts = new List<Post>();
            StreamReader inFile = null;
            try
            {
                inFile = new StreamReader("posts.txt");
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("Something went wrong... returning blank list {0}", e);
                return bigAlPosts;
            }

            string line = inFile.ReadLine(); //priming read
            while(line!=null)
            {
                string[] temp = line.Split('#');
                int postID = int.Parse(temp[0]);
                bigAlPosts.Add(new Post(){PostID = postID, PostText = temp[1], Timestamp = temp[2]});
                line = inFile.ReadLine(); //update read
            }

            inFile.Close();

            return bigAlPosts;
        }
    }
}