using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDialogue : MonoBehaviour
{
    public  GameObject Manager;
    public game_manager manager_script;
    Linkedlist NPCdialogue;
    public string Author;
    bool hasplayer;
    string currenttext;

    linknode temp;
    //linknode head;
    private void Awake()
    {
        
        manager_script = Manager.GetComponent<game_manager>();
        
    }

    public void loadallAuthorDialogue(Linkedlist alldialogue)
    {


        
        //get author tag for search
        while (alldialogue.Head.Author != Author)
        {
            alldialogue.Head = alldialogue.Head.Next;
        }
        Debug.Log("found Author : " + alldialogue.Head.Author);
        Author = alldialogue.Head.Author;

        //search linked list for all refrences to author
        while (alldialogue.Head != null)
        {   
            //find all pointersof nextindex and add them to the list
            if(alldialogue.Head.NextIndex != 0)
            {
                while(alldialogue.Head != null)
                {
                    if(alldialogue.Head.NextIndex == alldialogue.Head.Index)
                    {
                        NPCdialogue.addnodeFront(NPCdialogue, alldialogue.Head);
                        Debug.Log("npcdialogueadded to nodelist author: " + alldialogue.Head.Author + " index : " + alldialogue.Head.Index + "dialouge: " + alldialogue.Head.Diag);
                    }
                    alldialogue.Head = alldialogue.Head.Next;
                }
            }
            //add all refrence to author to this linked list
            if (alldialogue.Head.Author == Author)
            {
                NPCdialogue.addnodeFront(NPCdialogue, alldialogue.Head);
                Debug.Log("npcdialogueadded to nodelist author: "+alldialogue.Head.Author + " index : " + alldialogue.Head.Index + "dialouge: " + alldialogue.Head.Diag);
            }

            alldialogue.Head = alldialogue.Head.Next;
        }




    }

    void loadnextdialogue()
    {
        manager_script.currenttext = manager_script.dialogue.searchbyauthorfirstforfirstdiag(manager_script.dialogue, this.Author);
        temp = manager_script.dialogue.Head;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("created npc: " + Author);
        //Manager = GameObject.Find("Game_manager");
        //manager_script = Manager.GetComponent<game_manager>();
        //loadallAuthorDialogue(manager_script.dialogue);
        //Debug.Log(Author + "first line diag: " + NPCdialogue.Head.Diag);
    }

    // Update is called once per frame
    void Update()
    {
        if(hasplayer == true)
        {
            //Debug.Log("hasplayer: true");
            if (Input.GetKeyDown(KeyCode.X))
            {
                //Debug.Log("X");
                //Debug.Log(manager_script.dialogue.searchfornextindex(manager_script.dialogue, manager_script.dialogue.Head.NextIndex));
                manager_script.currenttext = manager_script.dialogue.searchfornextindex(manager_script.dialogue,temp.NextIndex);
                
                temp = manager_script.dialogue.SearchByIndexforlinknode(manager_script.dialogue, temp.NextIndex);
                manager_script.currentauthor = temp.Author;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        hasplayer = true;
        if(other.gameObject.tag == "Player")
        {
            manager_script.currentauthor = this.Author;
            loadnextdialogue();
            Debug.Log("found plyer");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        hasplayer = false;
        manager_script.currentauthor = "";
    }
}
