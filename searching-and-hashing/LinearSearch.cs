//LinearSearch.cs : Program of sequential search (linear search) in an array.

using System;

namespace LinearSearchDemo
{
    class LinearSearchDemo
    {
	    static int LinearSearch(int[] arr, int n, int item)
	    {
		    int i=0;
		    while(i<n && arr[i]!=item)
			    i++;

		    if(i<n)
			    return i;
		    else
			    return -1;
	    }//End of LinearSearch()

        static void Main(string[] args)
        {
		    int[] arr = {96, 19, 85, 9, 16, 29, 2, 36, 41, 67};
		    int item = 29;
		
		    int index = LinearSearch(arr, arr.Length, item);

		    if(index==-1)
			    Console.WriteLine(item + " not found in array");
		    else
                Console.WriteLine(item + " found at position " + index);
        }//End of Main()
    }//End of class LinearSearchDemo
}//End of namespace LinearSearchDemo
