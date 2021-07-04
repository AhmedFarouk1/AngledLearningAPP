using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Back_Inside : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        //GameObject panel = GameObject.Find("MathsUnit1_Panel");
        //panel.SetActive(true);

    }
}
