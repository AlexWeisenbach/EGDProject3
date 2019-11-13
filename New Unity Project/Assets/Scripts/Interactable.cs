using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public DialogueManager diaManager;
    public int line;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractedWith()
    {
        Debug.Log("I've been interacted with");
        diaManager.PlayDialogue(line);
    }
}
