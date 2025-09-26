//HeapSort.cs : Program of sorting using heap sort.

using System;

namespace HeapSortDemo
{
    class HeapSortDemo
    {
	    static void RestoreDown(int i, int[] arr, int n)
	    {
		    int k = arr[i];
		    int lchild = 2*i;
		    int rchild = lchild+1;

		    while(rchild <= n)
		    {
			    if(k>=arr[lchild] && k>=arr[rchild])
			    {
				    arr[i] = k;
				    return;
			    }
			    else if(arr[lchild] > arr[rchild])
			    {
				    arr[i] = arr[lchild];
				    i = lchild;
			    }
			    else
			    {
				    arr[i] = arr[rchild];
				    i = rchild;
			    }
			    lchild = i*2;
			    rchild = lchild+1;
		    }//End of while

		    //If number of nodes is even
		    if(lchild==n && k<arr[lchild])
		    {
			    arr[i] = arr[lchild];
			    i = lchild;
		    }

		    arr[i] = k;
	    }//End of RestoreDown()
	
	    static void BuildHeapBottomUp(int[] arr, int n)
	    {
		    for( int i=n/2; i>=1; i-- )
			    RestoreDown(i,arr,n);
	    }//End of BuildHeapBottomUp()	
	
	    static void HeapSort(int[] arr, int n)
	    {
		    BuildHeapBottomUp(arr,n);

		    Console.WriteLine("Heap is :");
		    for(int i=1; i<=n; i++)
			    Console.Write(arr[i] + " ");
		    Console.WriteLine();

		    //deleting the root and moving it(maxValue) to arr[n]
		    int maxValue;
		    while(n > 1)
		    {
			    maxValue = arr[1];
			    arr[1] = arr[n];
			    arr[n] = maxValue;
			    n--;
			    RestoreDown(1,arr,n);

			    Console.WriteLine("Heap is :");
			    for(int i=1; i<=n; i++)
                    Console.Write(arr[i] + " ");
			    Console.WriteLine();
		    }
	    }//End of HeapSort()

        static void Main(string[] args)
        {
		    int[] arr = {9999, 25, 35, 18, 9, 46, 70, 48, 23, 78, 12, 95}; //data is from arr[1]
		    int n = 11; //data is from arr[1]...arr[11]

		    Console.WriteLine("Unsorted list is :");
		    for(int i=1; i<=n; i++)
			    Console.Write(arr[i] + " ");
		    Console.WriteLine();

		    HeapSort(arr,n);
		
		    Console.WriteLine("Sorted list is :"); 
		    for(int i=1; i<=n; i++ )
                Console.Write(arr[i] + " ");
		    Console.WriteLine();
        }//End of Main()
    }//End of class HeapSortDemo
}//End of namespace HeapSortDemo
