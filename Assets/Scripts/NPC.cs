using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{

	public Transform ChatBackground;
	public Transform NPCCharacter;

	public DialogueSystem dialogue;
	public string Name;

	[TextArea(5, 10)]
	public string[] sentences;

	void Start()
	{
		dialogue = FindObjectOfType<DialogueSystem>();
	}

	void Update()
	{
		Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
		Pos.y += 175;
		ChatBackground.position = Pos;
	}

	public void OnTriggerStay(Collider other)
	{
		this.gameObject.GetComponent<NPC>().enabled = true;
		FindObjectOfType<DialogueSystem>().EnterRangeOfNPC();
		if((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.E))
		{
			this.gameObject.GetComponent<NPC>().enabled = true;
			dialogue.Names = Name;
			dialogue.dialogueLines = sentences;
			FindObjectOfType<DialogueSystem>().NPCName();
		}
	}

    public void OnTriggerExit()
    {
    	FindObjectOfType<DialogueSystem>().OutOfRange();
    	this.gameObject.GetComponent<NPC>().enabled = false;
    }
}
