//BTree.cs : Program for B tree.

using System;

namespace BTreeDemo
{
    class Node
    {
        public int[] key;
        public Node[] child;
        public int numKeys;
        public Node(int size)
        {
            key = new int[size + 1];
            child = new Node[size + 1];
            numKeys = 0;
        }
    }//End of class Node

    class NodeHolder
    {
        public Node value;
        public NodeHolder(Node x)
        {
            value = x;
        }
    }//End of class NodeHolder

    class IntHolder
    {
        public int value;
        public IntHolder(int n)
        {
            value = n;
        }
    }//End of class IntHolder

    class BTree
    {
	    private static readonly int M = 5; //Order of B tree
	    private static readonly int Max = M-1; //Maximum number of permissible keys in a node
	    private static readonly int Min = (M%2==0)?((M/2)-1):(((M+1)/2)-1); //Minimum number of permissible keys in a node except root
	
	    private Node root;		
		
	    public BTree()
	    {
		    root = null;
	    }//End of BTree()		

	    public void Insert(int key)
	    {
		    IntHolder iKey = new IntHolder(0);
            NodeHolder iKeyRchild = new NodeHolder(null);

		    bool taller = Insert(key, root, iKey, iKeyRchild);

		    if(taller)	//tree grown in height, new root is created
		    {
			    Node temp = new Node(Max);
			    temp.child[0] = root;
			    temp.key[1] = iKey.value;
			    temp.child[1] = iKeyRchild.value;
			    temp.numKeys = 1;
			    root = temp;
		    }
	    }//End of Insert()	
	
	    private bool Insert(int key, Node p, IntHolder iKey, NodeHolder iKeyRchild)
	    {
		    if(p == null)	//First Base case : key not found
		    {
			    iKey.value = key;
			    iKeyRchild.value = null;
			    return true;
		    }

		    IntHolder n = new IntHolder(0);
		    if(SearchNode(key, p, n) == true)	//Second Base case : key found
		    {
			    Console.WriteLine("Key already present in the tree");
			    return false;	//No need to insert the key
		    }

		    bool flag = Insert(key, p.child[n.value], iKey, iKeyRchild);

		    if (flag == true)
		    {
			    if(p.numKeys < Max)
			    {
				    InsertByShift(p, n.value, iKey.value, iKeyRchild.value);
				    return false;	//Insertion over
			    }
			    else
			    {
				    Split(p, n.value, iKey, iKeyRchild);
				    return true;	//Insertion not over : Median key yet to be inserted
			    }
		    }

		    return false;
	    }//End of Insert()	
	
	    public bool Search(int key)
	    {
		    if(Search(key,root) == null)
			    return false;
		    return true;
	    }//End of Search()	
	
	    private Node Search(int key, Node p)
	    {
		    if(p == null)
			    return null; //Base case 1 : key is not present in the tree

		    IntHolder n = new IntHolder(0);
		    if(SearchNode(key, p, n) == true) //Base case 2 : key is found in node p
			    return p;

		    return Search(key, p.child[n.value]); //Recursive case : Search in node p.child[n]
	    }//End of Search()
	
	    private bool SearchNode(int key, Node p, IntHolder n)
	    {
		    if(key < p.key[1])		//key is less than leftmost key
		    {
			    n.value = 0;
			    return false;
		    }

		    n.value = p.numKeys;
		    while(key<p.key[n.value] && n.value>1)
			    n.value--;

		    if(key == p.key[n.value])
			    return true;
		    else
			    return false;

	    }//End of SearchNode()
	
	    private void InsertByShift(Node p, int n, int iKey, Node iKeyRchild)
	    {
		    for(int i=p.numKeys; i>n; i--)
		    {
			    p.key[i+1] = p.key[i];
			    p.child[i+1] = p.child[i];
		    }
		    p.key[n+1] = iKey;
		    p.child[n+1] = iKeyRchild;
		    p.numKeys++;
	    }//End of InsertByShift()	
	
	    private void Split(Node p, int n, IntHolder iKey, NodeHolder iKeyRchild)
	    {
		    int i, j;
		    int lastKey;
		    Node lastChild;

		    if(n == Max)
		    {
			    lastKey = iKey.value;
			    lastChild = iKeyRchild.value;
		    }
		    else
		    {
			    lastKey = p.key[Max];
			    lastChild = p.child[Max];

			    for(i=p.numKeys-1; i>n; i--)
			    {
				    p.key[i+1] = p.key[i];
				    p.child[i+1] = p.child[i];
			    }
			    p.key[i+1] = iKey.value;
			    p.child[i+1] = iKeyRchild.value;
		    }

		    int d = (M+1)/2;
		    int medianKey = p.key[d];
		    Node newNode = new Node(Max);

		    for(i=1,j=d+1; j<=Max; i++,j++)
		    {
			    newNode.key[i] = p.key[j];
			    newNode.child[i] = p.child[j];
		    }
		    newNode.key[i] = lastKey;
		    newNode.child[i] = lastChild;
		    newNode.numKeys = M-d;	//Number of keys in the right splitted node

		    newNode.child[0] = p.child[d];
		    p.numKeys = d-1;	//Number of keys in the left splitted node

		    iKey.value = medianKey;
		    iKeyRchild.value = newNode;
	    }//End of Split()
	
	    public void Del(int key)
	    {
		    if(root != null)
		    {
			    Del(key, root);

			    //If tree becomes shorter, root is changed
			    if(root!=null && root.numKeys==0)
			    {
				    root = root.child[0];
			    }
		    }
		    else
			    Console.WriteLine("Tree is empty");
	    }//End of Del()	
	
	    private void Del(int key, Node p)
	    {
		    IntHolder n = new IntHolder(0);

		    if(p == null)	//reached leaf node, key does not exist
		    {
			    Console.WriteLine("Key " + key + "not found");
		    }
		    else
		    {
			    if(SearchNode(key, p, n))	//If found in current node p
			    {
				    if(p.child[n.value] == null)	//Node p is a leaf node
				    {
					    DelByShift(p, n.value);
				    }
				    else	//Node p is a non leaf node
				    {
					    Node succ = p.child[n.value]; //refers to the right subtree
					    while(succ.child[0] != null) //move down till leaf node arrives
						    succ = succ.child[0];
					    p.key[n.value] = succ.key[1];
					    Del(succ.key[1], p.child[n.value]);
				    }
			    }
			    else	//Not found in current node p
			    {
				    Del(key, p.child[n.value]);
			    }

			    if(p.child[n.value] != null)	//If p is not a leaf node
			    {
				    if(p.child[n.value].numKeys < Min)	//Check underflow in p->child[n]
					    Restore(p, n.value);
			    }
		    }
	    }//End of Del()	
	
	    private void DelByShift(Node p, int n)
	    {
		    for(int i=n+1; i<=p.numKeys; i++)
		    {
			    p.key[i-1] = p.key[i];
			    p.child[i-1] = p.child[i];
		    }
		    p.numKeys--;
	    }//End of DelByShift()	
	
	    private void Restore(Node p, int n)
	    {
		    if(n!=0 && p.child[n-1].numKeys > Min)
			    BorrowLeft(p, n);
		    else if(n!=p.numKeys && p.child[n+1].numKeys > Min)
			    BorrowRight(p, n);
		    else
		    {
			    if(n==0)	//If underflow node is leftmost node
				    Combine(p, n+1);	//combine nth child of p with its right sibling
			    else
				    Combine(p, n);		//combine nth child of p with its left sibling
		    }
	    }//End of Restore()	
	
	    private void BorrowLeft(Node p, int n)
	    {
		    Node u = p.child[n];		//underflow node
		    Node ls = p.child[n-1];	//left sibling of node u

		    //Shift all the keys and children in underflow node u one position right
		    for(int i=u.numKeys; i>0; i--)
		    {
			    u.key[i+1] = u.key[i];
			    u.child[i+1] = u.child[i];
		    }
		    u.child[1] = u.child[0];

		    //Move the separator key from parent node p to underflow node u
		    u.key[1] = p.key[n];
		
		    u.numKeys++;

		    //Move the rightmost key of node ls to the parent node p
		    p.key[n] = ls.key[ls.numKeys];
		
		    //Rightmost child of ls becomes leftmost child of node u
		    u.child[0] = ls.child[ls.numKeys];
		
		    ls.numKeys--;
	    }//End of BorrowLeft()
	
	    private void BorrowRight(Node p, int n)
	    {
		    Node u = p.child[n];		//underflow node
		    Node rs = p.child[n+1];	//right sibling of node u

		    //Move the separator key from the parent node p to the underflow node u
		    u.numKeys++;
		    u.key[u.numKeys] = p.key[n+1];

		    //Leftmost child of node rs becomes the rightmost child of node u
		    u.child[u.numKeys] = rs.child[0];

		    //Move the leftmost key from node rs to parent node p
		    p.key[n+1] = rs.key[1];
		    rs.numKeys--;

		    //Shift all the keys and children of node rs one position left
		    rs.child[0] = rs.child[1];
		    for(int i=1; i<=rs.numKeys; i++)
		    {
			    rs.key[i] = rs.key[i+1];
			    rs.child[i] = rs.child[i+1];
		    }
	    }//End of BorrowRight()
	
	    private void Combine(Node p, int m)
	    {
		    Node x = p.child[m];
		    Node y = p.child[m-1];

		    //Move the separator key from parent node p to node y
		    y.numKeys++;
		    y.key[y.numKeys] = p.key[m];

		    //Shift all the keys and children in node p one position left to fill the gap
		    for(int i=m; i<p.numKeys; i++)
		    {
			    p.key[i] = p.key[i+1];
			    p.child[i] = p.child[i+1];
		    }
		    p.numKeys--;

		    //Leftmost child of x becomes rightmost child of y
		    y.child[y.numKeys] = x.child[0];

		    //Insert all the keys and children of node x at the end of node y
		    for(int i=1; i<=x.numKeys; i++)
		    {
			    y.numKeys++;
			    y.key[y.numKeys] = x.key[i];
			    y.child[y.numKeys] = x.child[i];
		    }

	    }//End of Combine()
	
	    public void Inorder()
	    {
		    Inorder(root);
	    }//End of Inorder()	
	
	    private void Inorder(Node p)
	    {
		    if(p != null)
		    {
			    int i;
			    for(i=0; i<p.numKeys; i++)
			    {
				    Inorder(p.child[i]);
				    Console.Write(p.key[i+1] + " ");
			    }
			    Inorder(p.child[i]);
		    }
	    }//End of Inorder()	
	
	    public void Display()
	    {
		    Display(root, 0);
	    }//End of Display()	
	
	    private void Display(Node p, int spaces)
	    {
		    if(p != null)
		    {
			    int i;
			    for(i=1; i<=spaces; i++)
                    Console.Write(" ");

			    for(i=1; i<=p.numKeys; i++)
				    Console.Write(p.key[i] + " ");
			    Console.WriteLine();

			    for(i=0; i<=p.numKeys; i++)
				    Display(p.child[i], spaces+10);
		    }
	    }//End of Display()
		
    }//End of class BTree

    class BTreeDemo
    {
        static void Main(string[] args)
        {
		    BTree btree = new BTree();

		    Console.WriteLine("Tree after inserting 10");
		    btree.Insert(10);
		    btree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after inserting 40");
		    btree.Insert(40);
		    btree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after inserting 30");
		    btree.Insert(30);
		    btree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after inserting 35");
		    btree.Insert(35);
		    btree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after inserting 20");
		    btree.Insert(20);
		    btree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after inserting 15");
		    btree.Insert(15);
		    btree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after inserting 50");
		    btree.Insert(50);
		    btree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after inserting 28");
		    btree.Insert(28);
		    btree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after inserting 25");
		    btree.Insert(25);
		    btree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after inserting 5");
		    btree.Insert(5);
		    btree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after inserting 60");
		    btree.Insert(60);
		    btree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after inserting 19");
		    btree.Insert(19);
		    btree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after inserting 12");
		    btree.Insert(12);
		    btree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after inserting 38");
		    btree.Insert(38);
		    btree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after inserting 27");
		    btree.Insert(27);
		    btree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after inserting 90");
		    btree.Insert(90);
		    btree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after inserting 45");
		    btree.Insert(45);
		    btree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after inserting 48");
		    btree.Insert(48);
		    btree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after deleting 28");
		    btree.Del(28);
		    btree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after deleting 40");
		    btree.Del(40);
		    btree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after deleting 15");
		    btree.Del(15);
		    btree.Display();
		    Console.WriteLine();

		    //Search in B-tree
		    Console.Write("search(48) : " + (btree.Search(48) ? "True" : "False"));
		    Console.WriteLine();

            Console.Write("search(15) : " + (btree.Search(15) ? "True" : "False"));
		    Console.WriteLine();
        }//End of Main()
    }//End of class BTreeDemo
}//End of namespace BTreeDemo
