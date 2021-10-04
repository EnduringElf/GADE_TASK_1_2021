using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

    [System.Serializable]
public class game_manager : MonoBehaviour
{
    public TextAsset jsonfile;
    Linkedlist dialogue;
    linknode[] test;

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
            dialogue.addnodeFront(dialogue, test[i]);
        }
        //Debug.Log(test[test.Length - 2].Index);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

 
}
