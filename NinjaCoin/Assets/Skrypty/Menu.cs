using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public void Zacznij()
    {
        Application.LoadLevel("Ziemia");
    }

    public void Wyjdź()
    {
        Application.Quit();
    }

    public void Autor()
    {
        Application.OpenURL("https://www.facebook.com/maciek.nalewajka");
    }
}
