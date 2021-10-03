using System.Collections;
using System.Collections.Generic;


public class linknode 
{
    
    internal linknode Next;
    //internal linknode prev;

    internal string author;
    internal int index;
    internal int nextIndex;
    internal string[] diaglogue = new string[3];
    internal string item;
    internal string itemDiag;

    public linknode(string Author, int Index,int nIdex,string Item, string ItemDiag)
    {
        author = Author;
        index = Index;
        nextIndex = nIdex;
        item = Item;
        itemDiag = ItemDiag;

        Next = null;
        //prev = null;
    }

    public void AddDiag(string diag, int index)
    {
        diaglogue[index] = diag;
    }


}
