//LinearSearchSentinel.cs : Program of sequential search (linear search) using sentinel in an array.

using System;

namespace LinearSearchSentinelDemo
{
    class LinearSearchSentinelDemo
    {
        private static readonly int maxSize = 30;

	    static int LinearSearch(int[] arr, int n, int item)
	    {
		    arr[n] = item;

		    int i=0;

		    while(arr[i] != item)
			    i++;

		    if(i < n)
			    return i;
		    else
			    return -1;
	    }//End of LinearSearch()

        static void Main(string[] args)
        {
            int[] arr = new int[maxSize];
		    arr[0]=96; arr[1]=19; arr[2]=85; arr[3]=9; arr[4]=16;
		    arr[5]=29; arr[6]=2; arr[7]=36; arr[8]=41; arr[9]=67;

		    int n = 10;
		    int item = 29;
		
		    int index = LinearSearch(arr, n, item);

		    if(index==-1)
			    Console.WriteLine(item + " not found in array");
		    else
                Console.WriteLine(item + " found at position " + index);
        }//End of Main()
    }//End of class LinearSearchSentinelDemo
}//End of namespace LinearSearchSentinelDemo
