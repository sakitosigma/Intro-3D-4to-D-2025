using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionArea : MonoBehaviour
{
    public GameObject UIInteractionMessage;
    public bool canInteract;
    public DeteccionDeColisiones colisiones;
    public ScoreManager scoreManager;
    public int points;

    void Start()
    {
        UIInteractionMessage.SetActive(false);
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canInteract)
            {
                if (colisiones != null)
                {
                    Destroy(colisiones.gameObject);
                    EndInteraction();
                }
                else
                {
                    canInteract = false;
                    UIInteractionMessage.SetActive(false);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other.gameObject.name);
        colisiones = other.GetComponent<DeteccionDeColisiones>();
        if (colisiones)
        {
            UIInteractionMessage.SetActive(true);
            canInteract = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        EndInteraction();

    }

    void EndInteraction()
    {
        UIInteractionMessage.SetActive(false);
        colisiones = null;
        canInteract = false;
    }
}