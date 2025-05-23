using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHit : MonoBehaviour
{
    public GameObject successor;
    public GameObject current;
    public GameObject final;
    public AudioClip blastSound;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D()
    {
        AudioSource.PlayClipAtPoint(blastSound, Camera.main.transform.position);

        StartCoroutine(Coroutine());

       
    }
    private IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(0.3f);
        Debug.Log("bP" + BrownPower.loaded);
        if (BrownPower.loaded)
        {
            current.SetActive(false);
            final.SetActive(true);
        }
        else
        {
            successor.SetActive(true);
            current.SetActive(false);
        }
    }
}
