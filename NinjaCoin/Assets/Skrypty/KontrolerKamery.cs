using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KontrolerKamery : MonoBehaviour
{

    public Transform cameraTransform;
    public float parallaxFactor;

    private Vector3 poprzedniaPozycjaKamery;
    private Vector3 deltaPozycjaCamery;

    void Start()
    {
        poprzedniaPozycjaKamery = cameraTransform.position; // Nadanie początkowego położenia kamery

    }

    void Update()
    {
        deltaPozycjaCamery = cameraTransform.position - poprzedniaPozycjaKamery;
        Vector3 parallaxPozycja = new Vector3(transform.position.x + (deltaPozycjaCamery.x * parallaxFactor), transform.position.y, transform.position.z);
        transform.position = parallaxPozycja;
        poprzedniaPozycjaKamery = cameraTransform.position;
    }
}
