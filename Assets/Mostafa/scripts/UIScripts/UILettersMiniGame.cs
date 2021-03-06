using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILettersMiniGame : MonoBehaviour
{
    public string word;
    private int num_of_collected_letters = 0;
    public GameObject letterPrefab;
    public GameObject letterContainerPrefab;

    public RectTransform lettersStartPosition;

    public float horiziontalSpacing;
    public float verticalSpacing;

    private RectTransform rectTransform;
    [ContextMenu("prepare")]
    public void Prepare()
    {
        num_of_collected_letters = 0;
        rectTransform = GetComponent<RectTransform>();
        //generate containers
        for (int i = 0; i < word.Length; i++)
        {
            Vector2 tmpPosition = rectTransform.position;
            GameObject tmpLetterContainerGO = Instantiate(letterContainerPrefab, rectTransform);
            tmpLetterContainerGO.GetComponent<UIletterContainer>().letter = word[i].ToString();
            tmpPosition.x += i * horiziontalSpacing;
            tmpLetterContainerGO.transform.position = tmpPosition;
            tmpLetterContainerGO.GetComponent<UIletterContainer>().uILettersMiniGame = GetComponent<UILettersMiniGame>();
        }

        //generate letters
        char[] randomizedWord = word.ToCharArray();

        //turn every letter into a space
        for (int i = 0; i < randomizedWord.Length; i++)
        {
            randomizedWord[i] = ' ';
        }

        for (int i = 0; i < word.Length; i++)//shuffle string
        {
            int j;
            do
            {
                j = Random.Range(0, word.Length);
            } while (randomizedWord[j] != ' ');
            randomizedWord[j] = word[i];
        }

        for (int i = 0; i < randomizedWord.Length; i++)
        {
            Vector2 tmpPosition = lettersStartPosition.position;
            //tmpPosition.x += horiziontalSpacing * word.Length;
            GameObject tmpLetterGO = Instantiate(letterPrefab, transform);
            tmpLetterGO.GetComponent<UILetter>().AssignLetter(randomizedWord[i].ToString());
            tmpPosition.y -= i * verticalSpacing;
            tmpLetterGO.GetComponent<RectTransform>().position = tmpPosition;
        }

    }

    public void onCatchLetter(string ch)
    {
        num_of_collected_letters++;
        LetterAudioManager._instance.playLetter(ch);
        if(num_of_collected_letters == word.Length)
        {
            Debug.Log("done");
            Stage3._instance.wordCompleted();
        }
    }
}