using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
  	
  	[SerializeField]
	private Text npcText;  

	private GameObject triggerNpc;
	private bool triggeringPerson;
	
	void Start()
	{
		npcText.gameObject.SetActive(false);
	}	

	void Update()
	{
		if(triggeringPerson && Input.GetKeyDown(KeyCode.E))
		{
			triggeringPerson = false;
			//print("Aw, a little girl! Are you lost?");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "NPC")
		{
			npcText.gameObject.SetActive(true);
			triggeringPerson = true;
			triggerNpc = other.gameObject;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.tag == "NPC")
		{
			npcText.gameObject.SetActive(false);
			triggeringPerson = false;
			triggerNpc = null;
		}
	}
}
