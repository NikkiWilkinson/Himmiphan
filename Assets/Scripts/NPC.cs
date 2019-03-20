using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class NPC : MonoBehaviour
{

    public Transform ChatBackGround;
    public Transform NPCCharacter;

    private DialogueManager dialogueManager;

    public string Name;

    [TextArea(5, 10)]
    public string[] sentences;

    void Start () {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }
	
	void Update () {

    }

    public void OnTriggerStay(Collider other)
    {
        this.gameObject.GetComponent<NPC>().enabled = true;
        FindObjectOfType<DialogueManager>().EnterRangeOfNPC();
        if ((other.tag == "Player") && Input.GetKeyDown(KeyCode.E))
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueManager.Names = Name;
            dialogueManager.dialogueLines = sentences;
            FindObjectOfType<DialogueManager>().NPCName();
        }
    }

    public void OnTriggerExit()
    {
        FindObjectOfType<DialogueManager>().OutOfRange();
        this.gameObject.GetComponent<NPC>().enabled = false;
    }
}
