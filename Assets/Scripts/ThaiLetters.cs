using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThaiLetters : MonoBehaviour
{
	[SerializeField]
	private Text itemText;

	private bool pickupItem;

	void Start()
	{
		itemText.gameObject.SetActive(false);
	}

	void Update()
	{
		if(pickupItem && Input.GetKeyDown(KeyCode.E))
		{
			PickUp();
		}
	}

    void OnTriggerEnter(Collider other){

    	if(other.tag == "Player")
		{
			itemText.gameObject.SetActive(true);
			pickupItem = true;
		}
    }

    void OnTriggerExit(Collider other)
    {
    	if(other.tag == "Player")
		{
    		itemText.gameObject.SetActive(false);
    		pickupItem = false;
    	}
    }

    private void PickUp()
    {
    	Destroy(gameObject);
    	itemText.gameObject.SetActive(false);
    	print("collected letter");
    }
}
