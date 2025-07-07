using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeteccionDeColisiones : MonoBehaviour
{
    public ScoreManager scoreManager;
    public int points;


    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>(); // devuelve primer componente que encuentre de ese tipo

    }
    private void OnCollisionEnter(Collision col) // funcion para que suceda algo cuando suceda una colision
    {
        Debug.Log("Contacto");

        if (col.gameObject.name == "Player")
        {
            Destroy(gameObject);
            scoreManager.AddScore(points);
        }
    }
}