using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

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
    void OnCollisionEnter2D(Collision2D collision)
    {

        DebounceControll debounceControll = collision.gameObject.GetComponent<DebounceControll>();

        if(Player1.debounceActive || Player2.debounceActive)
        {
            Player1.deactivateDebounce();
            Player2.deactivateDebounce();
        }
        else if (debounceControll != null)
        {
            debounceControll.DisableCollider();  
        }
        
        StartCoroutine(TurHit());

       
    }
    public IEnumerator TurHit()
    {
        AudioSource.PlayClipAtPoint(blastSound, Camera.main.transform.position);
        yield return new WaitForSeconds(0.3f);
        Debug.Log("bP" + (BrownPower.loadedP1 | BrownPower.loadedP2));
        if (BrownPower.loadedP1 | BrownPower.loadedP2)
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
