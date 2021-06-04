using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILettersMiniGame : MonoBehaviour
{
    public string word;
    public GameObject letterPrefab;
    public GameObject letterContainerPrefab;

    public RectTransform lettersStartPosition;

    public float horiziontalSpacing;
    public float verticalSpacing;

    private RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        //generate containers
        for (int i = 0; i < word.Length; i++)
        {
            Vector2 tmpPosition = rectTransform.position;
            GameObject tmpLetterContainerGO = Instantiate(letterContainerPrefab, rectTransform);
            tmpLetterContainerGO.GetComponent<UIletterContainer>().letter = word[i].ToString();
            tmpPosition.x += i * horiziontalSpacing;
            tmpLetterContainerGO.transform.position = tmpPosition;
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
}