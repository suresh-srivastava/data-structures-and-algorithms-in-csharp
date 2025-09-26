//BinarySearchTree.cs : Program for Binary Search Tree.

using System;

namespace BinarySearchTreeDemo
{
    class Node
    {
	    public int info;
	    public Node lchild;
	    public Node rchild;

	    public Node(int key)
	    {
		    info = key;
		    lchild = null;
		    rchild = null;
	    }
    }//End of class Node

    class BinarySearchTree
    {
	    private Node root;

	    public BinarySearchTree()
	    {
		    root = null;
	    }//End of BinarySearchTree()

	    public BinarySearchTree(BinarySearchTree T)
	    {
		    root = Copy(T.root);
	    }//End of BinarySearchTree()

	    private Node Copy(Node p)
	    {
		    if(p == null)
			    return null;

		    Node cp = new Node(p.info);
		    cp.lchild = Copy(p.lchild);
		    cp.rchild = Copy(p.rchild);
		    return cp;
	    }//End of Copy()	
	
	    public bool IsEmpty()
	    {
		    return root==null;
	    }//End of IsEmpty()	
	
	    //Non Recursive insertion
	    public void Insert1(int key)
	    {
		    Node parent = null;
		    Node p = root;

		    while(p != null)
		    {
			    parent = p;

			    if(key < p.info)
				    p = p.lchild;
			    else if(key > p.info)
				    p = p.rchild;
			    else
			    {
				    Console.WriteLine(key + " is already there");
				    return;
			    }
		    }

		    Node temp = new Node(key);

		    if(parent == null)
			    root = temp;
		    else if(key < parent.info)
			    parent.lchild = temp;
		    else
			    parent.rchild = temp;
	    }//End of Insert1()
	
	    //Recursive insertion
	    private Node Insert(Node p, int key)
	    {
		    if(p == null) //Base Case
			    p = new Node(key);
		    else if(key < p.info) //Insertion in left subtree
			    p.lchild = Insert(p.lchild, key);
		    else if(key > p.info) //Insertion in right subtree
			    p.rchild = Insert(p.rchild, key);
		    else	//Base Case
			    Console.WriteLine(key + " is already there");

		    return p;
	    }//End of Insert()

	    public void Insert(int key)
	    {
		    root = Insert(root, key);
	    }//End of Insert()	
	
	    private void CaseA(Node parent, Node p)
	    {
		    if(parent == null)	//root node to be deleted
			    root = null;
		    else if(p == parent.lchild)
			    parent.lchild = null;
		    else
			    parent.rchild = null;

	    }//End of CaseA()	
	
	    private void CaseB(Node parent, Node p)
	    {
		    Node child;

		    //Initialize child
		    if(p.lchild != null)	//node to be deleted has left child
			    child = p.lchild;
		    else					//node to be deleted has right child
			    child = p.rchild;

		    if(parent == null)		//node to be deleted is root node
			    root = child;
		    else if(p == parent.lchild)	//node is left child of its parent
			    parent.lchild = child;
		    else					//node is right child of its parent
			    parent.rchild = child;

	    }//End of CaseB()
	
	    private void CaseC(Node parent, Node p)
	    {
		    Node s, ps;

		    //Find inorder successor and its parent
		    ps = p;
		    s = p.rchild;
		    while(s.lchild != null)
		    {
			    ps = s;
			    s = s.lchild;
		    }
		    p.info = s.info;
		    if(s.lchild==null && s.rchild==null)
			    CaseA(ps, s);
		    else
			    CaseB(ps, s);
	    }//End of CaseC()	
	
	    //Non Recursive deletion
	    public void Del2(int key)
	    {
		    Node parent = null;
		    Node p = root;

		    while(p != null)
		    {
			    if(p.info == key)
				    break;

			    parent = p;
			    if(key < p.info)
				    p = p.lchild;
			    else
				    p = p.rchild;
		    }

		    if(p == null)
			    Console.WriteLine(key + " is not in the tree");
		    else if(p.lchild != null && p.rchild != null)	//2 children
			    CaseC(parent, p);
		    else if(p.lchild != null)	//only left child
			    CaseB(parent, p);
		    else if(p.rchild != null)	//only right child
			    CaseB(parent, p);
		    else	//no child
			    CaseA(parent, p);

	    }//End of Del2()
	
	    //Non Recursive deletion
	    public void Del1(int key)
	    {
		    Node parent = null;
		    Node p = root;

		    while(p != null)
		    {
			    if(p.info == key)
				    break;

			    parent = p;
			    if(key < p.info)
				    p = p.lchild;
			    else
				    p = p.rchild;
		    }

		    if(p == null)
		    {
			    Console.WriteLine(key + " is not in the tree");
			    return;
		    }

		    //Case C : 2 children
		    //Find inorder successor and parent
		    Node s, ps;
		    if(p.lchild!=null && p.rchild!=null)
		    {
			    ps = p;
			    s = p.rchild;

			    while(s.lchild != null)
			    {
				    ps = s;
				    s = s.lchild;
			    }
			    p.info = s.info;
			    p = s;
			    parent = ps;
		    }

		    //Case B and Case A : 1 or no child
		    Node child;
		    if(p.lchild != null)	//Node to be deleted has left child
			    child = p.lchild;
		    else	//Node to be deleted has right child or no child
			    child = p.rchild;

		    if(parent == null)	//Node to be deleted is root node
			    root = child;
		    else if(p == parent.lchild)	//Node is left child of its parent
			    parent.lchild = child;
		    else	//Node is right child of its parent
			    parent.rchild = child;

	    }//End of Del1()	
	
	    //Recursive deletion
	    private Node Del(Node p, int key)
	    {
		    Node child, s;

		    if(p == null)
		    {
			    Console.WriteLine(key + " not found");
			    return p;
		    }

		    if(key < p.info)	//Delete from left subtree
			    p.lchild = Del(p.lchild, key);
		    else if(key > p.info)	//Delete from right subtree
			    p.rchild = Del(p.rchild, key);
		    else
		    {
			    //Key to be deleted is found
			    if(p.lchild!=null && p.rchild!=null)	//2 children
			    {
				    s = p.rchild;
				    while(s.lchild != null)
					    s = s.lchild;
				    p.info = s.info;
				    p.rchild = Del(p.rchild, s.info);
			    }
			    else	//1 child or no child
			    {
				    if(p.lchild != null)	//Only left child
					    child = p.lchild;
				    else	//Only right child or no child
					    child = p.rchild;
				    p = child;
			    }
		    }//End of else

		    return p;
	    }//End of Del()

	    public void Del(int key)
	    {
		    root = Del(root, key);
	    }//End of Del()
	
	    private void Display(Node p, int level)
	    {
		    if(p == null)
			    return;

		    Display(p.rchild, level+1);
		    Console.WriteLine();

		    for(int i=0; i<level; i++)
			    Console.Write("    ");
		    Console.Write(p.info);

		    Display(p.lchild, level+1);
	    }//End of display()

	    public void Display()
	    {
		    Display(root, 0);
	    }//End of Display()	
	
	    //Non Recursive search
	    public bool Search1(int key)
	    {
		    Node p = root;

		    while(p != null)
		    {
			    if(key < p.info)
				    p = p.lchild;	//Move to left child
			    else if(key > p.info)
				    p = p.rchild;	//Move to right child
			    else	//key found
				    return true;
		    }

		    return false;
	    }//End of Search1()	
	
	    //Recursive search
	    private Node Search(Node p, int key)
	    {
		    if(p == null)
			    return null;	//key not found
		    if(key < p.info)
			    return Search(p.lchild, key);	//search in left subtree
		    if(key > p.info)
			    return Search(p.rchild, key);	//search in right subtree
		    return p;	//key found
	    }//End of Search()

	    public bool Search(int key)
	    {
		    return Search(root, key) != null;
	    }//End of Search()
	
	    //Non Recursive to find minimum key
	    public int Min1()
	    {
		    if(IsEmpty())
			    throw new Exception("Tree is empty");

		    Node p = root;
		    while(p.lchild != null)
			    p = p.lchild;

		    return p.info;
	    }//End of Min1()
	
	    //Non Recursive to find maximum key
	    public int Max1()
	    {
		    if(IsEmpty())
			    throw new Exception("Tree is empty");

		    Node p = root;
		    while(p.rchild != null)
			    p = p.rchild;

		    return p.info;
	    }//End of Max1()
	
	    //Recursive to find minimum key
	    private Node Min(Node p)
	    {
		    if(p.lchild == null)
			    return p;
		    return Min(p.lchild);
	    }//End of Min()

	    public int Min()
	    {
		    if(IsEmpty())
			    throw new Exception("Tree is empty");

		    return Min(root).info;
	    }//End of Min()
	
	    //Recursive to find maximum key
	    private Node Max(Node p)
	    {
		    if(p.rchild == null)
			    return p;
		    return Max(p.rchild);
	    }//End of max()

	    public int Max()
	    {
		    if(IsEmpty())
			    throw new Exception("Tree is empty");

		    return Max(root).info;
	    }//End of Max()

    }//End of class BinarySearchTree

    class BinarySearchTreeDemo
    {
        static void Main(string[] args)
        {
		    BinarySearchTree bst = new BinarySearchTree();

		    try
		    {
			    Console.WriteLine("Insertion to create the BST :");
			    bst.Insert1(80);
			    bst.Insert1(70);
			    bst.Insert1(65);
			    bst.Insert1(75);
			    bst.Insert1(90);
			    bst.Insert1(85);
			    bst.Insert1(95);
			    bst.Display();
			    Console.WriteLine();
			    Console.WriteLine("After deleting 95 :");
			    bst.Del(95);
			    bst.Display();
			    Console.WriteLine();

			    Console.WriteLine("Copy constructor :");
			    BinarySearchTree bst1 = new BinarySearchTree(bst);
			    bst1.Display();
			    Console.WriteLine();

			    //Search (Iterative) in BST
			    Console.WriteLine("Search1(75) : " + (bst.Search1(75) ? "True" : "False"));
			    Console.WriteLine();

			    //Search (Recursive) in BST
			    Console.WriteLine("Search(75) : " + (bst.Search(75) ? "True" : "False"));
			    Console.WriteLine();

			    Console.WriteLine("Min key (Iterative) = " + bst.Min1());
			    Console.WriteLine("Min key (Recursive) = " + bst.Min());

			    Console.WriteLine("Max key (Iterative) = " + bst.Max1());
			    Console.WriteLine("Max key (Recursive) = " + bst.Max());

		    }//End of try
		    catch(Exception e)
		    {
			    Console.WriteLine(e.Message);
		    }
        }//End of Main()
    }//End of class BinarySearchTreeDemo
}//End of namespace BinarySearchTreeDemo
