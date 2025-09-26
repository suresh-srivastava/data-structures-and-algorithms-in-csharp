//BinarySearchRecursive.cs : Program of recursive binary search in an array

using System;

namespace BinarySearchRecursiveDemo
{
    class BinarySearchRecursiveDemo
    {
	    static int RbinarySearch(int[] arr, int low, int up, int item)
	    {
		    int mid;

		    if(low > up)
			    return -1;

		    mid = (low+up)/2;

		    if(item > arr[mid]) //Search in right half
			    return RbinarySearch(arr, mid+1, up, item);
		    else if (item < arr[mid]) //Search in left half
			    return RbinarySearch(arr, low, mid-1, item);
		    else
			    return mid;
	    }//End of RbinarySearch()
	
	    static int RbinarySearch(int[] arr, int n, int item)
	    {
		    return RbinarySearch(arr, 0, n-1, item);

	    }//End of RbinarySearch()

        static void Main(string[] args)
        {
		    int[] arr = {2, 9, 16, 19, 29, 36, 41, 67, 85, 96};
		    int item = 29;
		
		    int index = RbinarySearch(arr, arr.Length, item);

		    if(index==-1)
			    Console.WriteLine(item + " not found in array");
		    else
                Console.WriteLine(item + " found at position " + index);
        }//End of Main()
    }//End of class BinarySearchRecursiveDemo
}//End of namespace BinarySearchRecursiveDemo
