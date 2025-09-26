//ThreadedBinaryTree.cs : Program for Threaded Binary Tree.

using System;

namespace ThreadedBinaryTreeDemo
{
    class Node
    {
        public int info;
        public Node lchild;
        public Node rchild;
        public bool lthread;
        public bool rthread;

        public Node(int key)
        {
            info = key;
            lchild = null;
            rchild = null;
            lthread = true;
            rthread = true;
        }
    }//End of class Node

    class ThreadedBinaryTree
    {
        private Node root;

        public ThreadedBinaryTree()
        {
            root = null;
        }//End of ThreadedBinaryTree()

        public bool IsEmpty()
        {
            return root == null;
        }//End of IsEmpty()	

        public void Insert(int key)
	    {
		    Node parent = null;
		    Node p = root;

		    while(p != null)
		    {
			    parent = p;

			    if(key < p.info)
			    {
				    if(p.lthread == false)
					    p = p.lchild;
				    else
					    break;
			    }
			    else if(key > p.info)
			    {
				    if(p.rthread == false)
					    p = p.rchild;
				    else
					    break;
			    }
			    else
			    {
				    Console.WriteLine(key + " is already there");
				    return;
			    }
		    }//End of while

		    Node temp = new Node(key);

		    if(parent == null)
			    root = temp;
		    else if(key < parent.info)	//Inserted as left child
		    {
			    temp.lchild = parent.lchild;
			    temp.rchild = parent;
			    parent.lthread = false;
			    parent.lchild = temp;
		    }
		    else	//Inserted as right child
		    {
			    temp.lchild = parent;
			    temp.rchild = parent.rchild;
			    parent.rthread = false;
			    parent.rchild = temp;
		    }

	    }//End of Insert()

        public void Inorder()
	    {
		    if(root == null)
		    {
			    Console.WriteLine("Tree is empty");
			    return;
		    }

		    //Find the leftmost node of the tree
		    Node p = root;

		    while(p.lthread == false)
			    p = p.lchild;

		    while(p != null)
		    {
			    Console.Write(p.info + " ");
			
			    if(p.rthread == true)
				    p = p.rchild;
			    else
			    {
				    p = p.rchild;
				    while(p.lthread == false)
					    p = p.lchild;
			    }
		    }
	    }//End of Inorder()	

        public void Preorder()
	    {
		    if(root == null)
		    {
			    Console.WriteLine("Tree is empty");
			    return;
		    }

		    Node p = root;
		    while(p != null)
		    {
			    Console.Write(p.info + " ");
			    if(p.lthread == false)
				    p = p.lchild;
			    else if(p.rthread == false)
				    p = p.rchild;
			    else
			    {
				    while(p!=null && p.rthread==true)
					    p = p.rchild;

				    if(p != null)
					    p = p.rchild;
			    }
		    }
	    }//End of Preorder()	

        private Node InorderPredecessor(Node p)
        {
            if (p.lthread == true)
            {
                return p.lchild;
            }
            else
            {
                p = p.lchild;
                while (p.rthread == false)
                    p = p.rchild;
                return p;
            }
        }//End of InorderPredecessor()	

        private Node InorderSuccessor(Node p)
        {
            if (p.rthread == true)
            {
                return p.rchild;
            }
            else
            {
                p = p.rchild;
                while (p.lthread == false)
                    p = p.lchild;
                return p;
            }
        }//End of InorderSuccessor()	

        public void Del(int key)
	    {
		    Node parent = null;
		    Node p = root;

		    while(p != null)
		    {
			    if(p.info == key)
				    break;

			    parent = p;
			    if(key < p.info)
			    {
				    if(p.lthread == false)
					    p = p.lchild;
				    else
					    break;
			    }
			    else
			    {
				    if(p.rthread == false)
					    p = p.rchild;
				    else
					    break;
			    }

		    }//End of while

		    if(p!=null && p.info!=key)
		    {
			    Console.WriteLine(key + " not found");
			    return;
		    }

		    //Case C : 2 children
		    if(p.lthread==false && p.rthread==false)
		    {
			    //Find inorder successor and its parent
			    Node ps = p;
			    Node s = p.rchild;

			    while(s.lthread == false)
			    {
				    ps = s;
				    s = s.lchild;
			    }
			    p.info = s.info;
			    p = s;
			    parent = ps;
		    }

		    //Case A : no child
		    if(p.lthread==true && p.rthread==true)
		    {
			    if(parent == null)	//key to be deleted is in root node
				    root = null;
			    else if(p == parent.lchild)
			    {
				    parent.lthread = true;
				    parent.lchild = p.lchild;
			    }
			    else
			    {
				    parent.rthread = true;
				    parent.rchild = p.rchild;
			    }

			    return;
		    }

		    //Case B : 1 child
		    Node child;
		    //Initialize child
		    if(p.lthread == false)	//Node to be deleted has left child
			    child = p.lchild;
		    else	//Node to be deleted has right child
			    child = p.rchild;

		    if(parent == null)	//Node to be deleted is root node
			    root = child;
		    else if(p == parent.lchild)	//Node is left child of its parent
			    parent.lchild = child;
		    else	//Node is right child of its parent
			    parent.rchild = child;

		    Node pred = InorderPredecessor(p);
		    Node succ = InorderSuccessor(p);

		    if(p.lthread == false)	//If p has left child, right is a thread
			    pred.rchild = succ;
		    else	//p has right child, left is a thread
			    succ.lchild = pred;

	    }//End of Del()

    }//End of class ThreadedBinaryTree

    class ThreadedBinaryTreeDemo
    {
        static void Main(string[] args)
        {
		    ThreadedBinaryTree threadedTree = new ThreadedBinaryTree();

		    threadedTree.Insert(67);
		    threadedTree.Insert(34);
		    threadedTree.Insert(81);
		    threadedTree.Insert(12);
		    threadedTree.Insert(45);
		    threadedTree.Insert(78);
		    threadedTree.Insert(95);
		    threadedTree.Insert(20);
		    threadedTree.Insert(40);
		    threadedTree.Insert(89);
		    threadedTree.Insert(98);

		    Console.WriteLine("Inorder traversal :");
		    threadedTree.Inorder();
		    Console.WriteLine();
		    Console.WriteLine("Preorder traversal :");
		    threadedTree.Preorder();
		    Console.WriteLine();

		    threadedTree.Del(81);		//Case C
		    Console.WriteLine("Inorder traversal after deleting 81 :");
		    threadedTree.Inorder();
		    Console.WriteLine();

		    threadedTree.Del(45);		//Case B (has only left child)
		    Console.WriteLine("Inorder traversal after deleting 45 :");
		    threadedTree.Inorder();
		    Console.WriteLine();

		    threadedTree.Del(12);		//Case B (has only right child)
		    Console.WriteLine("Inorder traversal after deleting 12 :");
		    threadedTree.Inorder();
		    Console.WriteLine();

		    threadedTree.Del(40);		//Case A (leaf node)
		    Console.WriteLine("Inorder traversal after deleting 40 :");
		    threadedTree.Inorder();
		    Console.WriteLine();

		    threadedTree.Del(67);		//Case C (root node)
		    Console.WriteLine("Inorder traversal after deleting 67 :");
		    threadedTree.Inorder();
            Console.WriteLine();
        }//End of Main()
    }//End of class ThreadedBinaryTreeDemo
}//End of namespace ThreadedBinaryTreeDemo
