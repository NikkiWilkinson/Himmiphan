using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
   public Text nameText;
    public Text dialogueText;
    
    public GameObject dialogueGUI;
    public Transform dialogueBoxGUI;

    public float letterDelay = 0.1f;


    public string Names;

    public string[] dialogueLines;

    public bool letterIsMultiplied = false;
    public bool dialogueActive = false;
    public bool dialogueEnded = false;
    public bool outOfRange = true;

    void Start()
    {
    	dialogueText.text = "";
    }

    void Update()
    {

    }

    public void EnterRangeOfNPC()
    {
    	outOfRange = false;
    	dialogueGUI.SetActive(true);
    	if(dialogueActive == true)
    	{
    		dialogueGUI.SetActive(false);
    	}
    }

    public void NPCName()
    {
    	outOfRange = false;
    	dialogueGUI.SetActive(true);
    	nameText.text = Names;
    	if(Input.GetKeyDown(KeyCode.E))
    	{
    		if(!dialogueActive)
    		{
    			dialogueActive = true;
    			StartCoroutine(StartDialogue());
    		}
    	}
    	StartDialogue();
    }

    private IEnumerator StartDialogue()
    {
    	if(outOfRange == false)
    	{
    		int dialogueLength = dialogueLines.Length;
    		int currentDialogueIndex = 0;
    		while(currentDialogueIndex < dialogueLength || !letterIsMultiplied)
    		{
    			if(!letterIsMultiplied)
    			{
    				letterIsMultiplied = true;
    				StartCoroutine(DisplayString(dialogueLines[currentDialogueIndex++]));

    				if(currentDialogueIndex >= dialogueLength)
    				{
    					dialogueEnded = true;
    				}
    			}
    			yield return 0;
    		}

    		while(true)
    		{
    			if(Input.GetKeyDown(KeyCode.E) && dialogueEnded == false)
    			{
    				break;
    			}
    			yield return 0;
    		}
    		dialogueEnded = false;
    		dialogueActive = false;
    		DropDialogue();
    	}
    }

    private IEnumerator DisplayString(string stringToShow)
    {
    	if(outOfRange = false)
    	{
    		int stringLength = stringToShow.Length;
    		int currentDialogueIndex = 0;

    		dialogueText.text = "";

    		while(currentDialogueIndex < stringLength)
    		{
    			dialogueText.text += stringToShow[currentDialogueIndex];
    			currentDialogueIndex++;
    		}
    		while(true)
    		{
    			if(Input.GetKeyDown(KeyCode.E))
    			{
    				break;
    			}
    			yield return 0;
    		}
    		dialogueEnded = false;
    		letterIsMultiplied = false;
    		dialogueText.text = "";
    	}
    }

    public void DropDialogue()
    {
    	dialogueGUI.SetActive(false);
    	dialogueBoxGUI.gameObject.SetActive(false);
    }

    public void OutOfRange()
    {
    	outOfRange = true;
    	if(outOfRange == true)
    	{
    		letterIsMultiplied = false;
    		dialogueActive = false;
    		StopAllCoroutines();
    		dialogueGUI.SetActive(false);
    		dialogueBoxGUI.gameObject.SetActive(false);
    	}
    }
}
