using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;

[System.Serializable]

public class Dialogue
{
    
    public string name;
    [TextArea(3, 10)]
    public string[] sentences;
    /*private int index;
    public float typingSpeed;
    public TextMeshProUGUI textDisplay;

    void Start()
    {
    	StartCoroutine(Type());
    }

    IEnumerator Type()
    {
    	foreach(char letter in sentences[index].ToCharArray())
    	{
    		textDisplay.text += letter;
    		yield return new WaitForSeconds(typingSpeed);
    	}
    }

    public void NextSentence()
    {
    	if(index < sentences.Length - 1)
    	{
    		index++;
    		textDisplay.text = "";
    		StartCoroutine(Type());
    	}
    	else
    	{
    		textDisplay = "";
    	}
    }*/
}
