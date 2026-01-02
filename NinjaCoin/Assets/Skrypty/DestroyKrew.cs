using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyKrew : MonoBehaviour {

	void Start () {
        Invoke("AutoDestruction", 5f);

	}
	
	void Update () {
		
	}
    void AutoDestruction()
    {
        Destroy(this.gameObject);
    }
}
