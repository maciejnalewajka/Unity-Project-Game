using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dziab : MonoBehaviour {
    public AudioClip clip;
    public GameObject prefabKrew;

    void Start () {
        
    }
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
		if(other.gameObject.name == "Player")
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
            other.gameObject.GetComponent<Animator>().SetTrigger("dziab");
            Instantiate(prefabKrew, transform.position, transform.rotation);
        }
	}
}
