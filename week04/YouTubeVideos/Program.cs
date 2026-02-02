using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video v1 = new Video("Learn C# in 10 Minutes", "CodeMaster", 620);
        v1.AddComment(new Comment("Kevin", "I understood about classes and objects."));
        v1.AddComment(new Comment("Ana", "Great summary, straight to the point."));
        v1.AddComment(new Comment("Luis", "Will you make another video about lists?"));
        videos.Add(v1);

        Video v2 = new Video("Encapsulation Explained Easy", "DevPro", 540);
        v2.AddComment(new Comment("Sofía", "Now I understand why use properties."));
        v2.AddComment(new Comment("Marco", "Excellent example with private and methods."));
        v2.AddComment(new Comment("Elena", "It helped me with my university assignment."));
        videos.Add(v2);

        Video v3 = new Video("Abstraction in OOP with Examples", "TechTutor", 780);
        v3.AddComment(new Comment("Diego", "Awesome, it helped me understand abstraction."));
        v3.AddComment(new Comment("Paola", "I liked how you hide internal details."));
        v3.AddComment(new Comment("Raúl", "Could you explain inheritance too?"));
        videos.Add(v3);

        Video v4 = new Video("Lists and Objects in C#", "CSharpLab", 690);
        v4.AddComment(new Comment("Dani", "Very useful for handling collections."));
        v4.AddComment(new Comment("Claudia", "I loved the comments example."));
        v4.AddComment(new Comment("Jorge", "How would you do it with files?"));
        videos.Add(v4);

        foreach (Video video in videos)
        {
            Console.WriteLine("====================================");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Duration: {video.LengthSeconds} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}
