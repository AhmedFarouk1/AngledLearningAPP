using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{

    public Transform[] fruitPositions;
    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(currentIndex < fruitPositions.Length)
        {
            DraggableObject draggableObject = collision.gameObject.GetComponent<DraggableObject>();
            draggableObject.originalPosition = fruitPositions[currentIndex].position;
            currentIndex++;
        }
    }
}
