using UnityEngine;
using UnityEngine.UI;
using FMODUnity;
using FMOD.Studio;

public class TrainingManager : MonoBehaviour
{
    public Training training;
    private TrainingChoice currentTrainingChoice;
    public Image cursorImage;
    public TrainingAnswer answer;
    public float distancePrecision;
    public bool isChords = false;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (currentTrainingChoice != null)
            {
                cursorImage.GetComponent<Image>().sprite = null;
                cursorImage.gameObject.SetActive(false);

                float dist = Vector2.Distance(Input.mousePosition, currentTrainingChoice.transform.position);
                if (dist < distancePrecision)
                {
                    currentTrainingChoice.gameObject.SetActive(true);
                    answer.gameObject.SetActive(true);
                    answer.GetComponent<Image>().sprite = currentTrainingChoice.GetComponent<Image>().sprite;
                    answer.trainingState = currentTrainingChoice.trainingState;
                }

                AudioManager.instance.SetTrainingState(answer.trainingState);
                currentTrainingChoice = null;


            }
        }

    }

    public void OnMouseDown(TrainingChoice trainingChoice)
    {
        if (currentTrainingChoice == null)
        {
            currentTrainingChoice = trainingChoice;
            cursorImage.gameObject.SetActive(true);
            cursorImage.sprite = currentTrainingChoice.GetComponent<Image>().sprite;
        }
    }

    public void OnChordClicked(TrainingChoice trainingChoice)
    {

        currentTrainingChoice = trainingChoice;
        AudioManager.instance.SetTrainingState(currentTrainingChoice.trainingState);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.chord, this.transform.position);
    }

}
