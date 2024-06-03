using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ending : MonoBehaviour
{
    public Canvas endingCanvas;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<PlayerMotor>().canMove = false;
            endingCanvas.gameObject.SetActive(true);
        }
    }
}
