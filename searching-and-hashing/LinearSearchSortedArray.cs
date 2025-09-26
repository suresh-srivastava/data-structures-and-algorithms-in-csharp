//LinearSearchSortedArray.cs : Program of sequential search (linear search) in sorted array

using System;

namespace LinearSearchSortedArrayDemo
{
    class LinearSearchSortedArrayDemo
    {
	    static int LinearSearch(int[] arr, int n, int item)
	    {
		    int i=0;

		    while(i<n && arr[i]<item)
			    i++;

            if(i==n || arr[i]!=item)
                return -1;
            else
			    return i;
	    }//End of LinearSearch()

        static void Main(string[] args)
        {
		    int[] arr = {2, 9, 16, 19, 29, 36, 41, 67, 85, 96};
		    int item = 29;
		
		    int index = LinearSearch(arr, arr.Length, item);

		    if(index==-1)
			    Console.WriteLine(item + " not found in array");
		    else
                Console.WriteLine(item + " found at position " + index);
        }
    }//End of class LinearSearchSortedArrayDemo
}//End of namespace LinearSearchSortedArrayDemo
