using System.Collections;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class Enigma : Interactable
{
    [SerializeField] private Camera movingCamera;

    [SerializeField] private Camera playerCamera;

    [SerializeField] private Camera enigmaCamera;

    [SerializeField] private GameObject player;
    public GameObject enigmaCanvas;
    public GameObject mainUI;
    public MusicState onFinishState;
    private float transitionDuration = .3f;
    private bool isTransitioning = false;

    [SerializeField] private GameObject door;

    protected override void Interact()
    {
        player.GetComponent<PlayerMotor>().canMove = false;
        if (!isTransitioning)
        {
            StartCoroutine(moveCamera(playerCamera, enigmaCamera, transitionDuration));

        }

        player.SetActive(false);
        enigmaCanvas.SetActive(true);
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

    public void closeEnigma()
    {
        if (!isTransitioning)
        {
            StartCoroutine(moveCamera(enigmaCamera, playerCamera, transitionDuration));
        }
        enigmaCanvas.SetActive(false);
        mainUI.SetActive(true);
        player.SetActive(true);
        player.GetComponent<PlayerMotor>().canMove = true;

        movingCamera.enabled = false;
        movingCamera.GetComponent<StudioListener>().enabled = false;
        playerCamera.GetComponent<StudioListener>().enabled = true;
        playerCamera.enabled = true;

    }

    public void victory()
    {
        StartCoroutine(VictorySequence());
    }

    private IEnumerator VictorySequence()
    {
        yield return new WaitForSeconds(1f);
        closeEnigma();
        door.GetComponent<Animator>().SetBool("IsOpen", true);
        player.GetComponent<PlayerUI>().UpdateText("You have solved the enigma!");
        promptMessage = "You have solved the enigma!";
        AudioManager.instance.SetMusicState(onFinishState);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.enigmaOpeningSFX, this.transform.position);

    }
}

