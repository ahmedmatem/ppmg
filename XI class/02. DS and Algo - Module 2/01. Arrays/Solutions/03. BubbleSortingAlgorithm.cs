using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public class BubbleSortingAlgorithm
    {
        public static void Sort(int[] arr, bool inASCOrder = true)
        {
            // start repeating (arr.Length - 2) steps
            for (int step = 0; step < arr.Length - 1; step++)
            {
                // each time start from beginning and go
                // to element with index(arr.Length - 2 - step)
                for (int i = 0; i < arr.Length - 1 - step; i++)
                {
                    // in Ascending order - by default
                    if(inASCOrder)
                    {
                        // swap both elements if current one is bigger than previous -
                        // bigger bubbles rise to the surface faster
                        if (arr[i] > arr[i + 1])
                        {
                            // swapping two adjacent elements
                            int temp = arr[i];
                            arr[i] = arr[i + 1];
                            arr[i + 1] = temp;
                        }
                    }
                    else // in Descending order
                    {
                        // swap both elements if current one is less than previous -
                        // lаrge bubbles sink faster than small ones
                        if (arr[i] < arr[i + 1])
                        {
                            // swapping two adjacent elements
                            int temp = arr[i];
                            arr[i] = arr[i + 1];
                            arr[i + 1] = temp;
                        }
                    }
                }
            }
        }
    }
}
