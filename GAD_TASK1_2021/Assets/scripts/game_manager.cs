using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
    [System.Serializable]
public class game_manager : MonoBehaviour
{

    
    public TextAsset jsonfile;
    public Linkedlist dialogue;
    linknode[] test;
    public GameObject[] npcs;

    public string currentauthor;
    public string currenttext;

    public TMP_Text author;
    public TMP_Text diag;

    private void Update()
    {
        author.text = currentauthor;
        diag.text = currenttext;
    }

    private void Awake()
    {
        
        dialogue = new Linkedlist();
        //used on combination with the json helper to import the file into the program 
        //scince unity can not use it own jsonutility to do itself 
        //only this part uses array but wipes it after memory and is never called!
        //otherwise code would looki like the helper but uing the unity API
        test = JsonHelper.getJsonArray<linknode>(jsonfile.text);
        for(int i = 0; i < test.Length; i++)
        {
            dialogue.Addnodelast(dialogue, test[i]);
        }
        Debug.Log("from array next index "+2+": "+test[2].NextIndex);
        Debug.Log("game object arry size:" + npcs.Length);
        for (int i = 0; i > npcs.Length; i++)
        {
           // npcs[i].GetComponent<LoadDialogue>().loadallAuthorDialogue(npcs[i].GetComponent<LoadDialogue>().NPCdialogue);
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LoadDialoguebyname(string author)
    {
        while(dialogue.Head.Author != author)
        {
            dialogue.Head = dialogue.Head.Next;
        }

    }

    
    


}
