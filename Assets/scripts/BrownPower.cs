using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Random = UnityEngine.Random;
using Debug = UnityEngine.Debug;


public class BrownPower : MonoBehaviour
{

    public GameObject Bonus;
    
    private Vector3 randomPos;
    public static bool loadedP1 = false;
    public static bool loadedP2 = false;
    public AudioClip collectSound;
    public SpriteRenderer spriteRenderer;

    public GameObject braonAsteroid;
    public GameObject siviAsteroid;

    public Sprite fireSprite;
    public Sprite rockSprite;

    // Start is called before the first frame update
    void Start()
    {
        
        float numberX = Random.Range(-2.0f, -6.0f);
        float numberY = Random.Range(0.0f, 4.5f);
        randomPos = new Vector3(numberX, numberY, 0);
        Bonus.transform.position = randomPos;
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyUp(KeyCode.Space))
        {
            StartCoroutine(Coroutine());
        }


         if(Input.GetKeyUp(KeyCode.R))
        {
            if (PlayerTurn.Player1)
            {
                if (Player1.fireBall < 1)
                {
                    Debug.Log("UI will prevent it");
                }
                else
                {
                    Player1.useFireBall();

                    loadedP1 = true;
                    SpriteRenderer sr = braonAsteroid.GetComponent<SpriteRenderer>();
                    sr.sprite = fireSprite;
                }

            }
            else if (!PlayerTurn.Player1)
            {
                if (Player2.fireBall < 1)
                {
                    Debug.Log("UI will prevent it");
                }
                else
                {
                    Player2.useFireBall();
                    loadedP2 = true;
                    SpriteRenderer sr = siviAsteroid.GetComponent<SpriteRenderer>();
                    sr.sprite = fireSprite;
                }
            }
        }

         if(Input.GetKeyUp(KeyCode.T))
        {

            if (PlayerTurn.Player1)
            {
                if (Player1.debounce < 1)
                {
                    Debug.Log("UI will prevent it");
                }
                else
                {
                    Player1.useDebounce();
                }
            }

            if (!PlayerTurn.Player1)
            {
                if (Player2.debounce < 1)
                {
                    Debug.Log("UI will prevent it");
                }
                else
                {
                    Player2.useDebounce();
                }
            }
        }
    }

  

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        AudioSource.PlayClipAtPoint(collectSound, Camera.main.transform.position);
        if (PlayerTurn.Player1)
        {
            loadedP1 = true;
        }
        else if (!PlayerTurn.Player1)
        {
            loadedP2 = true;
        }
        //loaded = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }
        //Debug.Log("brown power is:" + loaded);
        // You can do logic here
    }
    private IEnumerator Coroutine()
    {

        yield return new WaitForSeconds(3.5f);
        spriteRenderer.enabled = true;
        loadedP1 = false; loadedP2 = false;
        Debug.Log("loaded 1 and 2 are: " + loadedP1 + loadedP2);
            Debug.Log("Bonus is active" + Bonus.activeSelf);
        if (PlayerTurn.Player1)
        {
            float numberX = Random.Range(-2.0f, -6.0f);
            float numberY = Random.Range(0.0f, 4.5f);
            randomPos = new Vector3(numberX, numberY, 0);
            Bonus.transform.position = randomPos;

            SpriteRenderer sr = siviAsteroid.GetComponent<SpriteRenderer>();
            sr.sprite = rockSprite;


        }
        else if (!PlayerTurn.Player1)
        {
            float numberX = Random.Range(2.0f, 6.0f);
            float numberY = Random.Range(0.0f, 4.5f);
            randomPos = new Vector3(numberX, numberY, 0);
            Bonus.transform.position = randomPos;

            //Vracamo na stari rock sprite
            SpriteRenderer sr = braonAsteroid.GetComponent<SpriteRenderer>();
            sr.sprite = rockSprite;

        }
        else
        {
            Debug.Log("No captio hombre");
            
        }
    }
}
