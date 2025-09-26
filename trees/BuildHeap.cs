//BuildHeap.cs : Program to build the heap.

using System;

namespace BuildHeapDemo
{
    class BuildHeapDemo
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
		    for(int i=n/2; i>=1; i--)
			    RestoreDown(i, arr, n);
	    }//End of BuildHeapBottomUp()

	    static void RestoreUp(int i, int[] arr)
	    {
		    int k = arr[i];
		    int iParent = i/2;

		    while(arr[iParent] < k)
		    {
			    arr[i] = arr[iParent];
			    i = iParent;
			    iParent = i/2;
		    }
		    arr[i] = k;
	    }//End of RestoreUp()

	    static void BuildHeapTopDown(int[] arr, int n)
	    {
		    for(int i=2; i<=n; i++)
			    RestoreUp(i, arr);
	    }//End of BuildHeapTopDown()

        static void Main(string[] args)
        {
		    int[] arr1 = {9999, 25, 35, 18, 9, 46, 70, 48, 23, 78, 12, 95};
		    int n1 = 11;

            Console.WriteLine("Building Heap Botton Up :");
		    BuildHeapBottomUp(arr1, n1);

		    for(int i=1; i<=n1; i++)
			    Console.Write(arr1[i] + " ");
		    Console.WriteLine();

		    int[] arr2 = {9999, 25, 35, 18, 9, 46, 70, 48, 23, 78, 12, 95};
		    int n2 = 11;

		    Console.WriteLine("Building Heap Top Down :");
		    BuildHeapTopDown(arr2, n2);

		    for(int i=1; i<=n2; i++)
			    Console.Write(arr2[i] + " ");
		    Console.WriteLine();
        }//End of Main()
    }//End of class BuildHeapDemo
}//End of namespace BuildHeapDemo
