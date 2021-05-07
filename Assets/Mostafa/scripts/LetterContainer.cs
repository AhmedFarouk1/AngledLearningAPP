using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterContainer : MonoBehaviour
{
    public string letter;//the letter that we will compare against

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DraggableObject draggableObject = collision.gameObject.GetComponent<DraggableObject>();

        if (draggableObject.objectName == letter)
        {
            draggableObject.originalPosition = transform.position;
        }
    }
}
