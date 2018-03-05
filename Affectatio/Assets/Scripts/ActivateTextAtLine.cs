using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour {

    public TextAsset theText;
    public int startLine;
    public int endLine;
    public TextBoxManager theTextBox;
    public bool DestroyWhenFinished;
	
	void Start ()
    {
        theTextBox = FindObjectOfType<TextBoxManager>();
	}
	
	
	void Update ()
    {
		
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "heros")
        {
            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableTextBox();
            Debug.Log("je suis dans la collision");

            if (DestroyWhenFinished)
            {
                Destroy(gameObject);
            }
        }
    }
}
