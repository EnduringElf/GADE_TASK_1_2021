using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Linkedlist : MonoBehaviour
{
    public linknode Head;
    public TextAsset jsonfile;

    public void addnodeFront(Linkedlist linkedlist, linknode parsenode)
    {
        
        linknode newNode = parsenode;
        newNode.Next = linkedlist.Head;
        linkedlist.Head = newNode;
        Debug.Log("sucssuffully made node with index :" + newNode.Index);
    }

    public void Addnodelast(Linkedlist linkedlist, linknode linknode)
    {
        if(linkedlist.Head == null)
        {
            linkedlist.Head =  linknode;
            return;
        }
        linknode lastNode = GetLastNode(linkedlist);
        lastNode.Next = linknode;
    }

    private linknode GetLastNode(Linkedlist linkedlist)
    {
        linknode temp = linkedlist.Head;
        while(temp.Next != null)
        {
            temp = temp.Next;
        }
        return temp;
    }

    void deletenodebykey(Linkedlist linkedlist, int index)
    {
        linknode temp = linkedlist.Head;
        linknode prev = null;
        if(temp != null && temp.Index == index)
        {
            linkedlist.Head = temp.Next;
            return;
        }
        while(temp != null && temp.Index != index)
        {
            prev = temp;
            temp = temp.Next;
        }
        if(temp == null)
        {
            return;
        }
        prev.Next = temp.Next;

    }

    linknode SearchByIndex(Linkedlist linkedlist , int index)
    {
        linknode temphead = linkedlist.Head;
        //string temp;
        while(temphead.Index != index)
        {
            temphead = temphead.Next;
        }
        return temphead;
    }
    
}


