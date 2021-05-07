using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * this module is responsible for generating letters and letter containers based on input string
 */

public class LetterMinigameGenerator : MonoBehaviour
{
    public string word;
    public GameObject letterPrefab;
    public GameObject letterContainerPrefab;

    public float horiziontalSpacing;
    public float verticalSpacing;

    // Start is called before the first frame update
    void Start()
    {
        //generate containers
        for(int i = 0; i < word.Length; i++)
        {
            Vector2 tmpPosition = transform.position;
            GameObject tmpLetterContainerGO = Instantiate(letterContainerPrefab, transform);
            tmpLetterContainerGO.GetComponent<LetterContainer>().letter = word[i].ToString();
            tmpPosition.x += i * horiziontalSpacing;
            tmpLetterContainerGO.transform.position = tmpPosition;
            
        }

        //generate letters
        char []randomizedWord = word.ToCharArray();
        
        //turn every letter into a space
        for(int i = 0; i < randomizedWord.Length; i++)
        {
            randomizedWord[i] = ' ';
        }

        for(int i = 0; i < word.Length; i++)//shuffle string
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
            Vector2 tmpPosition = transform.position;
            tmpPosition.x += horiziontalSpacing * word.Length;
            GameObject tmpLetterGO = Instantiate(letterPrefab, transform);
            tmpLetterGO.GetComponent<DraggableObject>().objectName = randomizedWord[i].ToString();
            tmpPosition.y += i * verticalSpacing;
            tmpLetterGO.transform.position = tmpPosition;

        }
    }

}
