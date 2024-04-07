namespace Stack_Demo
{
    public class MyStack
    {
        private int capacity;
        private int[] data;
        private int counter = 0;
        private int topIndex = -1;

        public int Capacity { get; private set; }

        public MyStack(int _capacity = 20)
        {
            Capacity = _capacity; ;
            capacity = _capacity;
            data = new int[capacity];
        }

        // Добавя елемент в стека
        public void Push(int element)
        {
            topIndex++;
            if (topIndex == data.Length)
            {
                // index out of range
                EnsureCapacity();
            }

            data[topIndex] = element;
            counter++;
        }

        // извлича елемент от върха на стека
        public int Pop()
        {
            if (topIndex == -1)
            {
                throw new ArgumentException("Stack is Empty");
            }
            else
            {
                int element = data[topIndex];
                topIndex--;
                counter--;

                return element;
            }
        }

        // Връща стойноста на топ елемента в стека
        public int Peek()
        {
            return data[topIndex];
        }

        //Връща броя на елементите в стека
        public int Count()
        {
            return counter;
        }

        private bool IsEmpty()
        {
            return counter == 0;
        }

        private void EnsureCapacity()
        {
            int[] tempData = new int[capacity * 2];
            Array.Copy(data, tempData, data.Length);
            data = new int[capacity * 2];
            Array.Copy(tempData, data, capacity);
            capacity *= 2;
            Capacity = capacity;
        }
    }
}
