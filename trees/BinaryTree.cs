//BinaryTree.cs : Program for Binary Tree.

using System;
using System.Collections.Generic;

namespace BinaryTreeDemo
{
    class Node
    {
	    public char info;
	    public Node lchild;
	    public Node rchild;

	    public Node(char data)
	    {
		    info = data;
		    lchild = null;
		    rchild = null;
	    }
    }//End of class Node

    class BinaryTree
    {
	    private Node root;

	    public BinaryTree()
	    {
		    root = null;
	    }//End of BinaryTree()

	    public bool IsEmpty()
	    {
		    return root==null;
	    }//End of IsEmpty()

	    public void CreateTree()
	    {
		    root = new Node('P');
		    root.lchild = new Node('Q');
		    root.rchild = new Node('R');

		    root.lchild.lchild = new Node('A');
		    root.lchild.rchild = new Node('B');

		    root.rchild.lchild = new Node('X');
	    }//End of CreateTree()	
	
	    private void Preorder(Node p)
	    {
		    if(p == null)	//Base case
			    return;

		    Console.Write(p.info + " ");
		    Preorder(p.lchild);
		    Preorder(p.rchild);
	    }//End of Preorder()

	    public void Preorder()
	    {
		    Preorder(root);
		    Console.WriteLine();
	    }//End of Preorder()	
	
	    private void Inorder(Node p)
	    {
		    if(p == null)	//Base case
			    return;

		    Inorder(p.lchild);
		    Console.Write(p.info + " ");
		    Inorder(p.rchild);
	    }//End of Inorder()

	    public void Inorder()
	    {
		    Inorder(root);
		    Console.WriteLine();
	    }//End of Inorder()	
	
	    private void Postorder(Node p)
	    {
		    if(p == null)	//Base case
			    return;

		    Postorder(p.lchild);
		    Postorder(p.rchild);
		    Console.Write(p.info + " ");
	    }//End of Postorder()

	    public void Postorder()
	    {
		    Postorder(root);
		    Console.WriteLine();
	    }//End of Postorder()
	
	    public void LevelOrder()
	    {
		    Queue<Node> qu = new Queue<Node>();
		    Node p;

		    qu.Enqueue(root);
		    while(qu.Count != 0)
		    {
			    p = qu.Dequeue();
			    Console.Write(p.info + " ");

			    if(p.lchild != null)
				    qu.Enqueue(p.lchild);

			    if(p.rchild != null)
				    qu.Enqueue(p.rchild);
		    }
		    Console.WriteLine();
	    }//End of LevelOrder()
	
	    private int Height(Node p)
	    {
		    int hLeft, hRight;

		    if(p == null)	//Base case
			    return 0;

		    hLeft = Height(p.lchild);
		    hRight = Height(p.rchild);

		    if(hLeft > hRight)
			    return 1+hLeft;
		    else
			    return 1+hRight;
	    }//End of Height()

	    public int Height()
	    {
		    return Height(root);
	    }//End of Height()
	
	    //Non recursive Preorder traversal
	    public void NrecPreorder()
	    {
		    Stack<Node> st = new Stack<Node>();
		    Node p = root;

		    if(p != null)
		    {
			    st.Push(p);
			    while(st.Count != 0)
			    {
				    p = st.Pop();
				    Console.Write(p.info + " ");
				    if(p.rchild != null)
					    st.Push(p.rchild);
				    if(p.lchild != null)
					    st.Push(p.lchild);
			    }
			    Console.WriteLine();
		    }
		    else
			    Console.WriteLine("Tree is empty");
	    }//End of NrecPreorder()	
	
	    //Non recursive Inorder traversal
	    public void NrecInorder()
	    {
		    Stack<Node> st = new Stack<Node>();
		    Node p = root;

		    if(p != null)
		    {
			    while(true)
			    {
				    while(p.lchild != null)
				    {
					    st.Push(p);
					    p = p.lchild;
				    }

				    while(p.rchild == null)
				    {
					    Console.Write(p.info + " ");
					    if(st.Count == 0)
					    {
						    Console.WriteLine();
						    return;
					    }
					    p = st.Pop();
				    }
				    Console.Write(p.info + " ");
				    p = p.rchild;
			    }
		    }
		    else
			    Console.WriteLine("Tree is empty");
	    }//End of NrecInorder()

	    //Non recursive Postorder traversal
	    public void NrecPostorder()
	    {
		    Stack<Node> st = new Stack<Node>();
		    Node p = root;
		    Node visited = root;

		    if(p != null)
		    {
			    while(true)
			    {
				    while(p.lchild != null)
				    {
					    st.Push(p);
					    p = p.lchild;
				    }

				    while(p.rchild==null || p.rchild==visited)
				    {
					    Console.Write(p.info + " ");
					    visited = p;
					    if(st.Count == 0)
					    {
						    Console.WriteLine();
						    return;
					    }
					    p = st.Pop();
				    }
				    st.Push(p);
				    p = p.rchild;
			    }
		    }
		    else
			    Console.WriteLine("Tree is empty");
	    }//End of NrecPostorder()
	
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
	    }//End of Display()

	    public void Display()
	    {
		    Display(root, 0);
		    Console.WriteLine();
	    }//End of Display()	
	
	    //Creation of binary tree from inorder and preorder traversal
	    private Node Construct(String inr, String pre, int num)
	    {
		    Node temp;
		
		    if(num == 0)
			    return null;

		    temp = new Node(pre[0]);

		    if(num == 1)	//if only one node in tree
			    return temp;
	
		    int i;
		    for(i=0; inr[i]!=pre[0]; i++)
			    ;

		    //Number of nodes in its left subtree is i
		    //For left subtree
		    temp.lchild = Construct(inr, pre.Substring(1), i);

		    //For right subtree
		    int j;
		    for(j=1; j<=i+1; j++)
			    ;
		    temp.rchild = Construct(inr.Substring(i+1), pre.Substring(j-1), num-i-1);

		    return temp;
	    }//End of Construct()

	    public void Construct(String inr, String pre)
	    {
		    root = Construct(inr, pre, inr.Length);
	    }//End of Construct()	
	
	    //Creation of binary tree from inorder and postorder traversal
	    private Node Construct1(String inr, String post, int num)
	    {
		    Node temp;
		    int i, j, k;

		    if(num == 0)
			    return null;

		    for(i=1; i<num; i++)
			    ;

		    temp = new Node(post[i-1]);

		    if(num == 1)	//if only one node in tree
			    return temp;
		
		    for(k=0; inr[k]!=post[i-1]; k++)
			    ;

		    //Now k denotes the number of nodes in left subtree
		    //For left subtree
		    temp.lchild = Construct1(inr, post, k);

		    //For right subtree
		    for(j=1; j<=k; j++)
			    ;

		    temp.rchild = Construct1(inr.Substring(k+1), post.Substring(j-1), num-k-1);

		    return temp;
	    }//End of Construct1()

	    public void Construct1(String inr, String post)
	    {
		    root = Construct1(inr, post, inr.Length);
	    }//End of construct1()
	
    }//End of class BinaryTree

    class BinaryTreeDemo
    {
        static void Main(string[] args)
        {
		    BinaryTree bnTree = new BinaryTree();

		    bnTree.CreateTree();
		    bnTree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Preorder traversal :");
		    bnTree.Preorder();
		
		    Console.WriteLine("Inorder traversal :");
		    bnTree.Inorder();

		    Console.WriteLine("Postorder traversal :");
		    bnTree.Postorder();

		    Console.WriteLine("Level order traversal :");
		    bnTree.LevelOrder();

		    Console.WriteLine("Height = " + bnTree.Height());		
		
		    Console.WriteLine("Non Recursive Preorder traversal :");
		    bnTree.NrecPreorder();
		
		    Console.WriteLine("Non Recursive Inorder traversal :");
		    bnTree.NrecInorder();

		    Console.WriteLine("Non Recursive Postorder traversal :");
		    bnTree.NrecPostorder();
		
		    String inorder = "GDHBEIACJFK";

		    String preorder = "ABDGHEICFJK";
		    BinaryTree bnTree1 = new BinaryTree();
		    Console.WriteLine("Creation of binary tree from Inorder = " + inorder + ", Preorder = " + preorder);
		    bnTree1.Construct(inorder, preorder);
		    bnTree1.Display();
		    Console.WriteLine();
		
		    String postorder = "GHDIEBJKFCA";
		    BinaryTree bnTree2 = new BinaryTree();
		    Console.WriteLine("Creation of binary tree from Inorder = " + inorder + ", Postorder = " + postorder);
		    bnTree2.Construct1(inorder, postorder);
		    bnTree2.Display();
            Console.WriteLine();
        }//End of Main()
    }//End of class BinaryTreeDemo
}//End of namespace BinaryTreeDemo
