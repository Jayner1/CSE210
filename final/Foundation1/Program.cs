using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        Video video1 = new Video("C# Tutorial", "John Doe", 600);
        Video video2 = new Video("Learn JavaScript", "Jane Smith", 450);
        Video video3 = new Video("Introduction to HTML", "Mike Johnson", 300);

        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "I learned a lot."));

        video2.AddComment(new Comment("Dave", "Awesome video!"));
        video2.AddComment(new Comment("Eve", "This was exactly what I needed."));
        video2.AddComment(new Comment("Frank", "Clear and concise."));

        video3.AddComment(new Comment("Grace", "Excellent introduction."));
        video3.AddComment(new Comment("Heidi", "Simple and easy to understand."));
        video3.AddComment(new Comment("Ivan", "Well explained!"));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (Video video in videos)
        {
            Console.WriteLine(video);
            Console.WriteLine();
        }
    }
}