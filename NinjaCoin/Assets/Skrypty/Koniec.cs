using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koniec : MonoBehaviour {

    

    public void Wyjdź()
    {
        Application.Quit();
    }

    public void OdNowa()
    {
        Application.LoadLevel("SceneWinter");
    }
}
