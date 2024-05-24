using UnityEngine;
using UnityEngine.UI;

public class EnigmaManager : MonoBehaviour
{
    public Enigma enigma;
    private EnigmaChoice currentEnigmaChoice;
    public Image cursorImage;
    public Answer answer;
    public float distancePrecision;
    private bool isCorrectlyAnswered = false;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (currentEnigmaChoice != null)
            {
                cursorImage.GetComponent<Image>().sprite = null;
                cursorImage.gameObject.SetActive(false);

                float dist = Vector2.Distance(Input.mousePosition, currentEnigmaChoice.transform.position);
                if (dist < distancePrecision)
                {
                    currentEnigmaChoice.gameObject.SetActive(true);
                    answer.gameObject.SetActive(true);
                    answer.GetComponent<Image>().sprite = currentEnigmaChoice.GetComponent<Image>().sprite;
                    answer.choiceID = currentEnigmaChoice.choiceID;
                    answer.enigmaID = currentEnigmaChoice.enigmaID;
                }

                currentEnigmaChoice = null;
            }
        }
        isCorrectlyAnswered = answer.choiceID == answer.answerID;

        if (isCorrectlyAnswered)
        {
            enigma.victory();
        }
    }

    public void OnMouseDown(EnigmaChoice enigmaChoice)
    {
        if (currentEnigmaChoice == null)
        {
            Debug.Log("EnigmaChoice clicked");
            currentEnigmaChoice = enigmaChoice;
            cursorImage.gameObject.SetActive(true);
            cursorImage.sprite = currentEnigmaChoice.GetComponent<Image>().sprite;
        }
    }

}
