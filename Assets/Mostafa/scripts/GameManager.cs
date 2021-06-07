using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Monkey monkey;
    public UILettersMiniGame lettersMiniGame;

    public static GameManager _instance;
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

    public void MonkeyJump()
    {
        monkey.doneJumping = false;
        monkey.Jump();
    }

    public void ShowLetterMiniGame()
    {
        Stage2._instance.TweenFruitsBackToTable();
        lettersMiniGame.gameObject.SetActive(true);
    }
    
}
