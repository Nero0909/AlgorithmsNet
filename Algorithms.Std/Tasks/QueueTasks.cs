using System.Text;
using Algorithms.Std.Collections;

namespace Algorithms.Std.Tasks
{
    public static class QueueTasks
    {
        public static string JosephTask(int N, int M)
        {
            var result = new StringBuilder(N);
            var victims = new ListQueue<int>();
            for (var i = 0; i < N; i++)
            {
                victims.Enqueue(i);
            }

            var currPosition = 1;
            while (victims.Size > 1)
            {
                if (currPosition % M == 0)
                {
                    var luckyMan = victims.Dequeue();
                    result.Append(luckyMan);
                    result.Append(" ");
                }
                else
                {
                    var unluckyMan = victims.Dequeue();
                    victims.Enqueue(unluckyMan);
                }

                currPosition++;
            }

            var looser = victims.Dequeue();
            result.Append(looser);

            return result.ToString();
        }
    }
}