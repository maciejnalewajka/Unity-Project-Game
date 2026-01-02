using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ŚledzeniePlayera1 : MonoBehaviour
{

    public GameObject player;      // Objekt player
    public float przejście;         // Przejście kamery z opuźnieniem
    private Vector3 currVelocity;

    void Start()
    {

    }


    void Update()
    {

        Vector3 newCameraPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z); // Nowa pozycja zczytama z gracza
        transform.position = Vector3.SmoothDamp(transform.position, newCameraPosition, ref currVelocity, przejście);     // Nowa pozycja przypisana do kamery
    }
}