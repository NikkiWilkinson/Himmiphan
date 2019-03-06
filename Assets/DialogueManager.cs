using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
 	private Queue<string> sentences;

 	public Text nameText;
 	public Text dialogueText;

 	public Animator animator;

 	void Start()
 	{
 		sentences = new Queue<string>();
 	}

 	public void StartDialogue(Dialogue dialogue)
 	{
 		//Debug.Log("Starting conversation with " + dialogue.name);

 		animator.SetBool("IsOpen", true);

 		nameText.text = dialogue.name;

 		sentences.Clear();

 		foreach(string sentence in dialogue.sentences)
 		{
 			sentences.Enqueue(sentence);
 		}

 		DisplayNextSentence();
 	}

 	public void DisplayNextSentence()
 	{
 		if(sentences.Count == 0)
 		{
 			EndDialogue();
 			return;
 		}
 		
 		string nextSentence = sentences.Dequeue();
 		//Debug.Log(nextSentence);
 		dialogueText.text = nextSentence;
 	}

 	void EndDialogue()
 	{
 		Debug.Log("End of convo");
 		animator.SetBool("IsOpen", false);
 	}

}

