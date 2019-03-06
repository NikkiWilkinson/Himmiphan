using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
	private GameObject triggerNpc;
	private bool triggering;
	
	public GameObject npcText;

	void Update()
	{
		if(triggering)
		{
			//print("Player is talking to " + triggerNpc);
			npcText.SetActive(true);

			if(Input.GetKeyDown(KeyCode.E))
			{
				triggering = false;
				print("Aw, a little girl! Are you lost?");
			}
		}
		else
		{
			npcText.SetActive(false);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "NPC")
		{
			triggering = true;
			triggerNpc = other.gameObject;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.tag == "NPC")
		{
			triggering = false;
			triggerNpc = null;
		}
	}

}
