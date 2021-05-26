using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Stage1 : MonoBehaviour
{

    public RectTransform[] fruitTransforms;
    public UIPlate plate;

    public float tweenDuration;

    private int currentFruitIndex = 0;


    public static Stage1 _instance;
    void Awake()
    {

        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }


    [ContextMenu("tweenFruit")]
    public void MoveFruitToPlate()
    {
        if(currentFruitIndex < fruitTransforms.Length){
            //move fruit to plates here is temporary jsut for testing
            fruitTransforms[currentFruitIndex].DOMove(plate.fruitPositions[currentFruitIndex].position, tweenDuration).OnComplete(MoveFruitToPlate);
            currentFruitIndex++;
        }
    }    
}
