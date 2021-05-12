using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILetter : MonoBehaviour
{
    public Text text;
    public DraggableObjectUI draggableObjectUI;
    // Start is called before the first frame update
    public void AssignLetter(string letter)
    {
        text.text = letter;
        draggableObjectUI.objectText = letter;
    }

    
}
