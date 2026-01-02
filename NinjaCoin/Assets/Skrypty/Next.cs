/*-----------------------------------------------------------------------------------------------------------------------------------------------------
    Author: Maciej Nalewajka
    Edit Date: 02/01/2026.
    Version: 1.1
    Copyright © 2026 Maciej Nalewajka. All rights reserved.
-----------------------------------------------------------------------------------------------------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next : MonoBehaviour {

    public void Jungle()
    {
        Application.LoadLevel("SceneJungle");
    }

    public void Cluods()
    {
        Application.LoadLevel("SceneClouds");
    }

    public void TheEnd()
    {
        Application.LoadLevel("SceneTheEnd");
    }
}