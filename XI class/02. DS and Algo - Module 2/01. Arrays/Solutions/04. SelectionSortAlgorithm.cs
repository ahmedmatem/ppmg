using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public class SelectionSortAlgorithm
    {
        public static void Sort(int[] arr, bool inASCOrder = true)
        {
            int index = 0;
            for( int step = 0; step < arr.Length - 1; step++ )
            {
                if(inASCOrder)
                {
                    int biggestElementIndex = 0;
                    for (int i = 0; i < arr.Length - step; i++)
                    {
                        if (arr[i] > arr[biggestElementIndex])
                        {
                            biggestElementIndex = i;
                        }
                    }
                    index = biggestElementIndex;
                }
                else
                {
                    int smallestElementIndex = 0;
                    for (int i = 0; i < arr.Length - step; i++)
                    {
                        if (arr[i] < arr[smallestElementIndex])
                        {
                            smallestElementIndex = i;
                        }
                    }
                    index = smallestElementIndex;
                }

                int temp = arr[index];
                arr[index] = arr[arr.Length - 1 - step];
                arr[arr.Length - 1 - step] = temp;
            }
        }
    }
}
