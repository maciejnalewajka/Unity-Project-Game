/*-----------------------------------------------------------------------------------------------------------------------------------------------------
    Author: Maciej Nalewajka
    Edit Date: 02/01/2026.
    Version: 1.1
    Copyright © 2026 Maciej Nalewajka. All rights reserved.
-----------------------------------------------------------------------------------------------------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class KontrolerPlayer : MonoBehaviour
{
    public Text wynikText;
    public Text zyciaText;
    public Button ButtonDalej;
    public Button ESC;
    public Text TextPkt;
    public Image ImageDalej;
    private int wynik;
    private int zycia;
    private bool czyEsc;

    public AudioClip clipCoin;
    public AudioClip clipJump;
    public AudioClip clipPlus;
    public AudioClip clipMeta;

    public float playerPredkosc;    // Przypisanie predkości
    public float playerSkok;        // Przypisanie mocy skoku
    private float ruchLP;
    public Transform czyNaZiemi;
    public Transform naStart;
    public LayerMask layerMask;
    Animator anim;          
    Rigidbody2D rgBody;
    bool czyPrawo = true;  // Do zmiany kierunku playera
    private bool naZiemi;
    private float radious = 0.3f;

    void Start()
    {// Przyposanie komponentów
        zycia = 5;
        czyEsc = false;



        anim = GetComponent<Animator>();
        rgBody = GetComponent<Rigidbody2D>();
    }
   

    public void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(czyEsc == false)
            {
                ESC.gameObject.SetActive(true);
                czyEsc = true;
            }
            else
            {
                ESC.gameObject.SetActive(false);
                czyEsc = false;
            }
        }
        ESC.onClick.AddListener(() => {
            ESC.gameObject.SetActive(false);
            czyEsc = false;
            Application.LoadLevel("SceneMenu");
        });
       
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Dziab"))
        {
            rgBody.velocity = Vector2.zero;
            return;
        }

        // Z danego pkt unity sprawdza okrąg o zadanym promieniu i czy koliduje z czymś
        naZiemi = Physics2D.OverlapCircle(czyNaZiemi.position, radious, layerMask);

        // Zczytanie pozycji x
        ruchLP = Input.GetAxis("Horizontal");
        rgBody.velocity = new Vector2(ruchLP * playerPredkosc, rgBody.velocity.y);          // Przypisanie nowego x i y
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetMouseButtonDown(0)) && naZiemi) // Jeżeli nacisne klawisz do obiektu zostanie przypisana siła
        {
            rgBody.AddForce(new Vector2(0f, playerSkok));
            AudioSource.PlayClipAtPoint(clipJump, transform.position);
            anim.SetTrigger("skok");

        }
        // Nadanie prędkości playerowi
        anim.SetFloat("predkosc", Mathf.Abs(ruchLP));
        // Obrót bohatera w zależności od naciśniętych strzałek
        if (ruchLP < 0 && czyPrawo)             
        {
            Obrót();                
        }
        if (ruchLP > 0 && !czyPrawo)
        {
            Obrót();
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Coin")
        {
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(clipCoin, transform.position);
            wynik++;
            wynikText.text = wynik.ToString();
        }       // Dotknięcie Coina
        if(other.gameObject.name == "Mushroom" || other.gameObject.name == "Kolce" || other.gameObject.name == "Grób" || other.gameObject.name == "Krzyż" || other.gameObject.name == "Crystal")
        {
            zycia = zycia - 1;
            if (zycia == 0)
            {
                Application.LoadLevel("SceneTheEnd");
            }
            zyciaText.text = zycia.ToString();
        }  // Dotknięcie grzyba
        if(other.gameObject.name == "Plus")
        {
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(clipPlus, transform.position);
            zycia = zycia + 1;
            zyciaText.text = zycia.ToString();
        }
        if (other.gameObject.name == "Meta")
        {
            AudioSource.PlayClipAtPoint(clipMeta, transform.position);
            ButtonDalej.gameObject.SetActive(true);
            TextPkt.text = "Twój wynik to: " + wynik.ToString() + "/135 punktów.";
            TextPkt.gameObject.SetActive(true);
            ImageDalej.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
        if (other.gameObject.name == "Meta2")
        {
            AudioSource.PlayClipAtPoint(clipMeta, transform.position);
            ButtonDalej.gameObject.SetActive(true);
            TextPkt.text = "Twój wynik to: " + wynik.ToString() + "/725 punktów.";
            TextPkt.gameObject.SetActive(true);
            ImageDalej.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
        if (other.gameObject.name == "Meta3")
        {
            AudioSource.PlayClipAtPoint(clipMeta, transform.position);
            ButtonDalej.gameObject.SetActive(true);
            TextPkt.text = "Twój wynik to: " + wynik.ToString() + "/275 punktów.";
            TextPkt.gameObject.SetActive(true);
            ImageDalej.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

    }
    // Funkcja obracająca playera
    void Obrót()
    {
        czyPrawo = !czyPrawo;
        Vector3 playerXXX = gameObject.transform.localScale;
        playerXXX.x *= -1;
        gameObject.transform.localScale = playerXXX;
    }
    // Funkcja powracająca na start
    public void Restart()
    {
        gameObject.transform.position = naStart.position;
    }

}
