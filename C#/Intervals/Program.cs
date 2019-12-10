using System;
using System.Collections.Generic;

namespace Intervals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SumIntervals(new (int, int)[] {}));
        }

        public static int SumIntervals((int, int)[] intervals)
        {
            int sum = 0;
            foreach ((int, int) interval in GenerateIntervalList(intervals))
            {
                sum += (interval.Item2 - interval.Item1);
            }
            return sum;
        }

        private static LinkedList<(int, int)> GenerateIntervalList((int, int)[] intervals)
        {
            LinkedList<(int, int)> intervalList = new LinkedList<(int, int)>();
            if (intervals.Length > 0)
            {
                intervalList.AddFirst(intervals[0]);
                for (int index = 1; index < intervals.Length; index++)
                {
                    InsertInterval(intervals[index], ref intervalList);
                }
            }
            return intervalList;
        }

        private static void InsertInterval((int, int) interval, ref LinkedList<(int, int)> intervalList)
        {
            // Skip empty intervals
            if (interval.Item1 == interval.Item2) return;
            LinkedListNode<(int, int)> current = intervalList.First;
            while (current != null)
            {
                if (interval.Item1 < current.Value.Item1)
                {
                    //Brand new node
                    if (interval.Item2 <= current.Value.Item1)
                    {
                        intervalList.AddBefore(current, interval);
                    }
                    // Change overlapped node, and find other overlapped nodes
                    else
                    {
                        current.Value = (interval.Item1, Math.Max(current.Value.Item2, interval.Item2));
                        PurgeOverlappedNodes(ref current, ref intervalList);
                    }
                    return;
                }
                // Change overlapped node, and find other overlapped nodes
                else if (interval.Item1 <= current.Value.Item2)
                {
                    current.Value = (current.Value.Item1, Math.Max(current.Value.Item2, interval.Item2));
                    PurgeOverlappedNodes(ref current, ref intervalList);
                    return;
                }
                current = current.Next;
            }
            // If current == null
            intervalList.AddLast(interval);
        }

        private static void PurgeOverlappedNodes(ref LinkedListNode<(int, int)> current, ref LinkedList<(int, int)> intervalList)
        {
            LinkedListNode<(int, int)> furtherNode = current.Next;
            while (furtherNode != null)
            {
                //Complete Overlap, Purge Node
                if (furtherNode.Value.Item2 <= current.Value.Item2)
                {
                    intervalList.Remove(furtherNode);
                    furtherNode = current.Next;
                }
                // Change partially Overlapped node
                else if (furtherNode.Value.Item1 < current.Value.Item2)
                {
                    furtherNode.Value = (current.Value.Item2, furtherNode.Value.Item2);
                }
                else break;
            }

        }
    }
}
