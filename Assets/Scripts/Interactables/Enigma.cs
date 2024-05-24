using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enigma : Interactable
{
    [SerializeField]
    private Camera movingCamera;

    [SerializeField]
    private Camera playerCamera;

    [SerializeField]
    private Camera enigmaCamera;

    [SerializeField]
    private GameObject player;
    public GameObject enigmaCanvas;
    public GameObject mainUI;
    private float transitionDuration = .3f;
    private bool isTransitioning = false;

    [SerializeField]
    private GameObject door;

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
        playerCamera.enabled = true;
    }

    public void victory()
    {
        Invoke(nameof(closeEnigma), 1f);
        door.GetComponent<Animator>().SetBool("IsOpen", true);
        player.GetComponent<PlayerUI>().UpdateText("You have solved the enigma!");
    }
}
