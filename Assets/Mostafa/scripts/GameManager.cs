using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public Monkey monkey;
    public UILettersMiniGame lettersMiniGame;

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

        DontDestroyOnLoad(this.gameObject);
    }

    public void MonkeyJump()
    {
        monkey.Jump();
    }

    public void ShowLetterMiniGame()
    {
        lettersMiniGame.gameObject.SetActive(true);
    }
}
