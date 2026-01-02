using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dalej : MonoBehaviour {

    public void Grzybnia()
    {
        Application.LoadLevel("Grzybnia");
    }

    public void Chmury()
    {
        Application.LoadLevel("Chmury");
    }

    public void Koniec()
    {
        Application.LoadLevel("Koniec");
    }
}
