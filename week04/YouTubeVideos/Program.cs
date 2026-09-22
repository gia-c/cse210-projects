using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video(
            "Programming with classes",
            "BYU-Idaho",
            600
        );

        video1._comments.Add(new Comment("Gisela", "This was very helpful!"));
        video1._comments.Add(new Comment("Sarita", "I finally understand classes"));
        video1._comments.Add(new Comment("Hector", "Great video."));
        video1._comments.Add(new Comment("Ann", "Thank you for this video."));

        Video video2 = new Video(
            "Learning Abstraction",
            "Programming World",
            360
        );

        video2._comments.Add(new Comment("Liz", "Abstraction is easier than I expected."));
        video2._comments.Add(new Comment("Ana", "Very well explained."));
        video2._comments.Add(new Comment("Luis", "Can you do a part 2?."));
        video2._comments.Add(new Comment("Rosa", "Great tutorial!"));

        Video video3 = new Video(
            "Learning Encapsulation",
            "InfoWorld",
            540
        );

        video3._comments.Add(new Comment("Juan", "The examples were helpful."));
        video3._comments.Add(new Comment("Rodrigo", "Finally I understand it, thank you!."));
        video3._comments.Add(new Comment("Ruth", "Aprecciate it."));
        video3._comments.Add(new Comment("Joshua", "Very clear and easy to understand."));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._length} seconds");
            Console.WriteLine($"Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");

            foreach (Comment comment in video._comments)
            {
                Console.WriteLine($"{comment._name}: {comment._text}");
            }

            Console.WriteLine();
        }
    }
}