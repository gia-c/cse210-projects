using System;

/*Exceeding Requirements:
I added a level system to make the program more engaging.
The player starts at Level 1 and gains a new level for every
1,000 points earned. The current level is displayed with the player's score.
*/
class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}