using System;
using System.Collections.Generic;
using System.IO;

namespace PA1
{
    public class Post : IComparable<Post>
    {
        //getters and setters
        public int PostID {get; set;}
        public string PostText {get; set;}
        public string newPostText{get; set;}
        public string Timestamp {get; set;}

        //GetPostID method
        public int GetPostID()
        {
            return PostID;
        }

        //ToString method
        public override string ToString()
        {
            return PostID + "\t" + PostText + "\t" + Timestamp;
        }

        //CompareTo method
       public int CompareTo(Post temp)
        {
            return this.Timestamp.CompareTo(temp.Timestamp);
        }

        //CompareByDate method
        public int CompareByDate(Post x, Post y)
        {
            return x.Timestamp.CompareTo(y.Timestamp);
        }

        //ToFile method
        public string ToFile()
        {
            return PostID + "#" + PostText + "#" + Timestamp;
        }

        //SavePosts method
        public static void SavePosts(List<Post> bigAlPosts)
        {
            StreamWriter outFile = new StreamWriter("posts.txt");
            
            foreach (Post x in bigAlPosts)
            {
                outFile.WriteLine(x.ToFile());
            }
            outFile.Close();
        }

    }
}