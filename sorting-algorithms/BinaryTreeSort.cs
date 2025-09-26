//BinaryTreeSort.cs : Program of sorting using binary tree sort.

using System;

namespace BinaryTreeSortDemo
{
    class Node
    {
	    public int info;
	    public Node lchild;
	    public Node rchild;

	    public Node(int data) 
	    {
		    info = data;
		    lchild = null;
		    rchild = null;
	    }
    }//End of class Node

    class BinarySearchTree
    { 
	    private Node root;
	    private static int k;

	    public BinarySearchTree()
	    {
		    root = null;
	    }//End of constructor BinarySearchTree()

	    public bool IsEmpty()
	    {
		    return root == null;
	    }//End of IsEmpty()	
	
	    private Node Insert(Node p, int data)
	    {
		    if(p == null)
			    p = new Node(data);
		    else if(data < p.info)	
			    p.lchild = Insert(p.lchild, data);
		    else 
			    p.rchild = Insert(p.rchild, data);  
		    return p;
	    }//End of Insert()
	
	    public void Insert(int data)
	    {
		    root = Insert(root, data);
	    }//End of insert()	
	
	    //Recursive inorder traversal
	    public void Inorder(Node p, int[] arr)
	    {
		    if(p == null)
			    return;
		    Inorder(p.lchild,arr);
		    arr[k++] = p.info;
		    Inorder(p.rchild,arr);
	    }//End of Inorder()	
	
	    public void Inorder(int[] arr)
	    {
		    k = 0;
		    Inorder(root,arr);
	    }//End of Inorder()
	
    }//End of class BinarySearchTree

    class BinaryTreeSortDemo
    {
	    static void BinaryTreeSort(int[] arr, int n)
	    {
		    BinarySearchTree bst = new BinarySearchTree();

	        for(int i = 0; i < n; i++)
			    bst.Insert(arr[i]);
	        bst.Inorder(arr);
	    }//End of BinaryTreeSort()

        static void Main(string[] args)
        {
		    int[] arr = {19, 35, 10, 12, 46, 6, 40, 3, 90, 8};

		    Console.WriteLine("Unsorted list is :"); 
		    for(int i=0; i<arr.Length; i++)
			    Console.Write(arr[i] + " ");
		    Console.WriteLine();

		    BinaryTreeSort(arr,arr.Length);
		
		    Console.WriteLine("Sorted list is :"); 
		    for(int i=0; i<arr.Length; i++)
                Console.Write(arr[i] + " ");
		    Console.WriteLine();
        }//End of Main()
    }//End of class BinaryTreeSortDemo
}//End of namespace BinaryTreeSortDemo
