//MergeSortIterative.cs : Program of sorting using merge sort without recursion.

using System;

namespace MergeSortIterativeDemo
{
    class MergeSortIterativeDemo
    {
	    //arr[low1]...arr[up1] and arr[low2]...arr[up2] merged to temp[low1]..temp[up2]
	    static void Merge(int[] arr, int[] temp, int low1, int up1, int low2, int up2)
	    {
		    int i=low1, j=low2, k=low1;  	

		    while(i<=up1 && j<=up2)
		    {
			    if(arr[i] < arr[j])
				    temp[k++] = arr[i++];
			    else
				    temp[k++] = arr[j++];
		    }

		    while(i <= up1)
			    temp[k++] = arr[i++];
		
		    while(j <= up2)
			    temp[k++] = arr[j++];
	    }//End of Merge()

	    //copies temp[low]....temp[up] to arr[low]...arr[up]
	    static void Copy(int[] arr, int[] temp, int n)
	    {
		    for(int i=0; i<n; i++)
			    arr[i] = temp[i];
	    }//End of Copy()	
	
	    static void MergePass(int[] arr, int[] temp, int size, int n)
	    {
		    int i, low1, up1, low2, up2;
		    low1 = 0;
		
		    while(low1+size <= n-1)
		    {
			    up1 = low1 + size - 1;
			    low2 = low1 + size;
			    up2 = low2 + size - 1;
			    if(up2 >= n)	//if length of last sublist is less than size
				    up2 = n-1;
			    Merge(arr,temp,low1,up1,low2,up2);
			    low1 = up2 + 1;	//Take next two sublists for merging
		    }
		
		    for(i=low1; i<=n-1; i++)
			    temp[i] = arr[i];	//If any sublist is left alone

		    Copy(arr,temp,n);
	    }//End of MergePass()	
	
	    static void MergeSort(int[] arr, int n)
	    {
		    int[] temp = new int[arr.Length];
		    int size = 1;

		    while(size<n)
		    {
			    MergePass(arr,temp,size,n);
			    size = size*2;
		    }
	    }//End of MergeSort()

        static void Main(string[] args)
        {
		    int[] arr = {8, 5, 89, 30, 42, 92, 64, 4, 21, 56, 3};

		    Console.WriteLine("Unsorted list is :"); 
		    for(int i=0; i<arr.Length; i++)
                Console.Write(arr[i] + " ");
		    Console.WriteLine();

		    MergeSort(arr,arr.Length);
		
		    Console.WriteLine("Sorted list is :"); 
		    for(int i=0; i<arr.Length; i++)
			    Console.Write(arr[i] + " ");
		    Console.WriteLine();
        }//End of Main()
    }//End of class MergeSortIterativeDemo
}//End of namespace MergeSortIterativeDemo
