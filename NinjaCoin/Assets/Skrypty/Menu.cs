/*-----------------------------------------------------------------------------------------------------------------------------------------------------
    Author: Maciej Nalewajka
    Edit Date: 02/01/2026.
    Version: 1.1
    Copyright © 2026 Maciej Nalewajka. All rights reserved.

    Color resources: https://colorhunt.co/palette/0000005682b1739ec9ffe8db
    Music resources: Music by Mykola Sosin (https://pixabay.com/users/mfcc-28627740) from Pixabay (https://pixabay.com/music)
-----------------------------------------------------------------------------------------------------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public void Start()
    {
        Application.LoadLevel("SceneWinter");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Author()
    {
        Application.OpenURL("https://maciejnalewajka.github.io");
    }
}
