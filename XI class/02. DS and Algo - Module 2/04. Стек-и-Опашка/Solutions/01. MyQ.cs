using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue_Demo
{
    public class MyQ
    {
        private int[] numbers;
        private int headPos, endPos, counter = 0;

        public MyQ(int capacity)
        {
            numbers = new int[capacity];
            headPos = 0;
            endPos = -1;
        }

        public bool IsEmpty()
        {
            return counter == 0;
        }

        public void Enqueue(int element)
        {
            counter++;
            endPos = ++endPos % numbers.Length;
            numbers[endPos] = element;
        }

        public int Dequeue()
        {
            if(!IsEmpty())
            {
                counter--;
                int headElement = numbers[headPos];
                headPos = ++headPos % numbers.Length;
                return headElement;
            }
            else
            {
                throw new EmptyQueueException("The queue is empty. Access is denied.");
            }
        }

        public int Peek()
        {
            return numbers[headPos];
        }

        public int Count()
        {
            return counter;
        }
    }
}
