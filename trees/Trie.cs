//Trie.cs : Program to implement trie.

using System;

namespace TrieDemo
{
    class Node
    {
	    public readonly int MaxSize = 26;
	    public Node[] links; //links to the child node
	    public bool eok; //end of key

	    public Node() 
	    {
		    links = new Node[MaxSize];
		    eok = false;
		    for(int i=0; i<MaxSize; i++)
			    links[i] = null;
	    }
    }//End of class Node

    class Trie 
    {
        public readonly int MaxSize = 26;
	    private Node root;

	    public Trie()
	    {
		    root = new Node();
	    }//End of Trie()

	    public void Insert(String key)
	    {
		    Node p = root;

		    for(int i=0; i<key.Length; i++)
		    {
			    //If letter of key is not there
			    if(p.links[key[i]-'a'] == null)
			    {
				    p.links[key[i]-'a'] = new Node();
			    }

			    p = p.links[key[i]-'a']; //Move to the next child node
		    }
		    p.eok = true; //end of key
	    }//End of Insert()	
	
	    public bool Search(String key)
	    {
		    Node p = root;

		    for(int i=0; i<key.Length; i++)
		    {
			    if(p.links[key[i]-'a'] == null)
			    {
				    //key is not in the Trie
				    return false;
			    }

			    p = p.links[key[i]-'a']; //Move to the next child node
		    }

		    return p.eok;
	    }//End of Search()
	
	    public bool StartsWith(String prefix)
	    {
		    Node p = root;

		    for(int i=0; i<prefix.Length; i++)
		    {
			    if(p.links[prefix[i]-'a'] == null)
			    {
				    //No prefix
				    return false;
			    }

			    p = p.links[prefix[i]-'a']; //Move to the next child node
		    }

		    //prefix found
		    return true;
	    }//End of StartsWith()
	
	    private void Display(Node p, String prefix)
	    {
		    if(p.eok)
			    Console.WriteLine(prefix);

		    for (int i=0; i<MaxSize; i++) 
		    {
			    if(p.links[i] != null)
			    {
				    Display(p.links[i], prefix+(char)('a'+i));
			    }
		    }
	    }//End of Display()

	    public void Display()
	    {
		    String str = "";
		    Display(root,str);
	    }//End of Display()
	
	    public void Del(String key)
	    {
		    Node p = root;

		    for(int i=0; i<key.Length; i++)
		    {
			    if(p.links[key[i]-'a'] == null)
			    {
				    Console.WriteLine("key is not in the Trie");
				    return;
			    }
			    p = p.links[key[i]-'a']; //Move to the next child node
		    }

		    if(p.eok == false)
			    Console.WriteLine("key is not in the Trie");
		    else
			    p.eok = false;
	    }//End of Del()	
	
    }//End of class Trie

    class TrieDemo
    {
        static void Main(string[] args)
        {
		    Trie trie = new Trie();

		    trie.Insert("lucknow");
		    trie.Insert("lucknowcity");
		    trie.Insert("luxembourg");
		    trie.Insert("lux");
	    
		    //Search in trie
		    Console.WriteLine("search(\"lucknowp\") : " + (trie.Search("lucknowp") ? "True" : "False"));

		    Console.WriteLine("search(\"luxembourg\") : " + (trie.Search("luxembourg") ? "True" : "False"));

		    //Prefix in trie
		    Console.WriteLine("startsWith(\"luxe\") : " + (trie.StartsWith("luxe") ? "True" : "False"));

		    Console.WriteLine("Trie keys are :");
		    trie.Display();

		    //Deletion of key in trie
		    trie.Del("luxembourg");

		    Console.WriteLine("After deleting luxembourg, trie keys are :");
		    trie.Display();
        }//End of Main()
    }//End of class TrieDemo
}//End of namespace TrieDemo
