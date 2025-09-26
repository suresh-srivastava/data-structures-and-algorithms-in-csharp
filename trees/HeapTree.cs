//HeapTree.cs : Program for Heap Tree.

using System;

namespace HeapTreeDemo
{
    class HeapTree
    {
	    private static readonly int MaxSize = 30;
	    private int[] heapArr;
	    private int n;	//Number of elements in heap

	    public HeapTree()
	    {
		    heapArr = new int[MaxSize];
		    n = 0;
		    heapArr[0] = 9999;
	    }//End of HeapTree()
	
	    public bool IsEmpty()
	    {
		    return n==0;
	    }//End of IsEmpty()

	    public void Insert(int key)
	    {
		    n++;	//Increase the heap size by 1
		    heapArr[n] = key;
		    RestoreUp(n);
	    }//End of Insert()	
	
	    private void RestoreUp(int i)
	    {
		    int k = heapArr[i];
		    int iParent = i/2;

		    while(heapArr[iParent] < k)
		    {
			    heapArr[i] = heapArr[iParent];
			    i = iParent;
			    iParent = i/2;
		    }
		    heapArr[i] = k;
	    }//End of RestoreUp()	
	
	    public int DeleteHeap()
	    {
		    if(IsEmpty())
			    throw new Exception("Tree is empty\n");

		    int maxValue = heapArr[1];	//Save the element present at the root
		    heapArr[1] = heapArr[n];	//Place the last element in the root
		    n--;						//Decrease the heap size by 1
		    RestoreDown(1);

		    return maxValue;
	    }//End of DeleteHeap()
	
	    private void RestoreDown(int i)
	    {
		    int k = heapArr[i];
		    int lchild = 2*i;
		    int rchild = lchild+1;

		    while(rchild <= n)
		    {
			    if(heapArr[lchild]<=k && heapArr[rchild]<=k)
			    {
				    heapArr[i] = k;
				    return;
			    }
			    else if(heapArr[lchild] > heapArr[rchild])
			    {
				    heapArr[i] = heapArr[lchild];
				    i = lchild;
			    }
			    else
			    {
				    heapArr[i] = heapArr[rchild];
				    i = rchild;
			    }

			    lchild = 2*i;
			    rchild = lchild+1;

		    }//End of while

		    //If number of nodes is even
		    if(lchild==n && k<heapArr[lchild])
		    {
			    heapArr[i] = heapArr[lchild];
			    i = lchild;
		    }

		    heapArr[i] = k;
	    }//End of RestoreDown()	
	
	    public void Display()
	    {
		    for(int i=1; i<=n; i++)
			    Console.Write(heapArr[i] + " ");
		    Console.WriteLine();
		    Console.WriteLine("Number of elements = " + n);
	    }//End of Display()	
	
    }//End of class HeapTree

    class HeapTreeDemo
    {
        static void Main(string[] args)
        {
		    HeapTree heapTree = new HeapTree();

		    try
		    {
			    heapTree.Insert(25);
			    heapTree.Display();
			    heapTree.Insert(35);
			    heapTree.Display();
			    heapTree.Insert(18);
			    heapTree.Display();
			    heapTree.Insert(9);
			    heapTree.Display();
			    heapTree.Insert(46);
			    heapTree.Display();
			    heapTree.Insert(70);
			    heapTree.Display();
			    heapTree.Insert(48);
			    heapTree.Display();
			    heapTree.Insert(23);
			    heapTree.Display();
			    heapTree.Insert(78);
			    heapTree.Display();
			    heapTree.Insert(12);
			    heapTree.Display();
			    heapTree.Insert(95);

			    Console.WriteLine("After Insertion :");
			    heapTree.Display();

			    Console.WriteLine("After Deletion :");
			    Console.WriteLine("Maximum Element : " + heapTree.DeleteHeap());
			    heapTree.Display();
			    Console.WriteLine("Maximum Element : " + heapTree.DeleteHeap());
			    heapTree.Display();
		    }//End of try
		    catch(Exception e)
		    {
			    Console.WriteLine(e.Message);
		    }
        }//End of Main()
    }//End of class HeapTreeDemo
}//End of namespace HeapTreeDemo
