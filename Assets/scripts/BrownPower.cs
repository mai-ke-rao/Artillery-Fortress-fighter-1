using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownPower : MonoBehaviour
{

    public GameObject Bonus;
    public GameObject pivot;
    public GameObject pivot2;
    private Vector3 randomPos;
    public static bool loaded = false;
    public AudioClip collectSound;

    // Start is called before the first frame update
    void Start()
    {
        loaded = false;

    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyUp(KeyCode.Space))
        {
            StartCoroutine(Coroutine());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        AudioSource.PlayClipAtPoint(collectSound, Camera.main.transform.position);

        loaded = true;
        Debug.Log("brown power is:" + loaded);
        // You can do logic here
    }
    private IEnumerator Coroutine()
    {

        yield return new WaitForSeconds(3);
        if (pivot2.activeSelf)
        {
            float numberX = Random.Range(-2.0f, -6.0f);
            float numberY = Random.Range(0.0f, 4.5f);
            randomPos = new Vector3(numberX, numberY, 0);
            Bonus.transform.position = randomPos;
            loaded = false;

        }
        else if (pivot.activeSelf)
        {
            float numberX = Random.Range(2.0f, 6.0f);
            float numberY = Random.Range(0.0f, 4.5f);
            randomPos = new Vector3(numberX, numberY, 0);
            Bonus.transform.position = randomPos;
            loaded = false;
        }
        else
        {
            Debug.Log("Mistakes my friend");
            
        }
    }
}
