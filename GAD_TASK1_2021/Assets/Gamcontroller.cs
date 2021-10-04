using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamcontroller : MonoBehaviour
{

    public  GameObject Manager;
    public game_manager manager_script;
    // Start is called before the first frame update
    void Start()
    {
        //Manager = GameObject.Find("Game_manager");
        manager_script = Manager.GetComponent<game_manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void onTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            manager_script.currentauthor = other.GetComponent<LoadDialogue>().Author;
            Debug.Log("found npc");
        }
    }
}
