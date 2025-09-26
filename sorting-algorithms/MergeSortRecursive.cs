//MergeSortRecursive.cs : Program of sorting using merge sort through recursion.

using System;

namespace MergeSortRecursiveDemo
{
    class MergeSortRecursiveDemo
    {
	    //arr[low1]...arr[up1] and arr[low2]...arr[up2] merged to temp[low1]...temp[up2]
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
	
	    static void Copy(int[] arr, int[] temp, int low, int up)
	    {
		    for(int i=low; i<=up; i++)
			    arr[i] = temp[i];
	    }//End of Copy()
	
	    static void MergeSort(int[] arr, int low, int up)
	    {
		    int[] temp = new int[arr.Length];
		    int mid;

		    if(low == up)	//if only one element
			    return;
		
		    mid = (low+up)/2;
		    MergeSort(arr,low,mid);		//Sort arr[low]....arr[mid]
		    MergeSort(arr,mid+1,up);	//Sort arr[mid+1]....arr[up]

		    //Merge arr[low]...arr[mid] and arr[mid+1]....arr[up] to temp[low]...temp[up]
		    Merge(arr,temp,low,mid,mid+1,up); 

		    //Copy temp[low]...temp[up] to arr[low]...arr[up]
		    Copy(arr,temp,low,up);
	    }//End of MergeSort()	
	
	    static void MergeSort(int[] arr, int n)
	    {
		    MergeSort(arr,0,n-1);
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
    }//End of class MergeSortRecursiveDemo
}//End of namespace MergeSortRecursiveDemo
