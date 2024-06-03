using System.Collections;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class Training : Interactable
{
    [SerializeField] private Camera movingCamera;

    [SerializeField] private Camera playerCamera;

    [SerializeField] private Camera trainingCamera;

    [SerializeField] private GameObject player;
    public GameObject trainingCanvas;
    public GameObject mainUI;
    private float transitionDuration = .3f;
    private bool isTransitioning = false;

    protected override void Interact()
    {
        player.GetComponent<PlayerMotor>().canMove = false;
        if (!isTransitioning)
        {
            StartCoroutine(moveCamera(playerCamera, trainingCamera, transitionDuration));
        }

        player.SetActive(false);
        trainingCanvas.SetActive(true);
        mainUI.SetActive(false);
    }
    public IEnumerator moveCamera(Camera fromCamera, Camera toCamera, float duration)
    {
        isTransitioning = true;

        fromCamera.enabled = false;
        movingCamera.enabled = true;
        movingCamera.GetComponent<StudioListener>().enabled = true;
        playerCamera.GetComponent<StudioListener>().enabled = false;

        Vector3 fromPosition = fromCamera.transform.position;
        Quaternion fromRotation = fromCamera.transform.rotation;

        Vector3 toPosition = toCamera.transform.position;
        Quaternion toRotation = toCamera.transform.rotation;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            movingCamera.transform.position = Vector3.Lerp(fromPosition, toPosition, t);
            movingCamera.transform.rotation = Quaternion.Slerp(fromRotation, toRotation, t);

            yield return null;
        }

        movingCamera.transform.position = toPosition;
        movingCamera.transform.rotation = toRotation;


        isTransitioning = false;

    }
    public void closeTraining()
    {
        if (!isTransitioning)
        {
            StartCoroutine(moveCamera(trainingCamera, playerCamera, transitionDuration));
        }
        trainingCanvas.SetActive(false);
        mainUI.SetActive(true);
        player.SetActive(true);
        player.GetComponent<PlayerMotor>().canMove = true;

        movingCamera.enabled = false;
        movingCamera.GetComponent<StudioListener>().enabled = false;
        playerCamera.GetComponent<StudioListener>().enabled = true;
        playerCamera.enabled = true;
        AudioManager.instance.SetTrainingState(TrainingState.NOTHING);
    }
}

