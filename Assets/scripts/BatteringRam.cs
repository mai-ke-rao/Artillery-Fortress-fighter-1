using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteringRam : MonoBehaviour
{
    public GameObject sTower;
    public GameObject pivot;
    public GameObject pivot2;

    public Rigidbody2D turret1;
    public Rigidbody2D turret1_ostecen;
    public Rigidbody2D turret2;
    public Rigidbody2D turret2_ostecen;
    public Rigidbody2D nexus_ostecen;
    public Rigidbody2D nexus;

    public AudioClip collectSound;
    //position before the movement of sTower
    private Vector3 currentPosition;
    private Vector3 newPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            Debug.Log("KeyCode E is up");
            if (pivot2.activeSelf)
            {
                Debug.Log("Pivot is rolling");
                sTower.SetActive(true);
                currentPosition = sTower.transform.position;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space) && sTower.activeSelf && pivot2.activeSelf)
        {
            //od 3.5 do -6.5
            currentPosition = sTower.transform.position;
            StartCoroutine(Coroutine());
        }
    }


    private IEnumerator Coroutine()
    {

        yield return new WaitForSeconds(3);
        AudioSource.PlayClipAtPoint(collectSound, Camera.main.transform.position);
        while (currentPosition.x > -5 && sTower.transform.position.x > currentPosition.x - 5)
        {
            Debug.Log("Why am I even here");
            newPos = new Vector3(sTower.transform.position.x - 0.03f, sTower.transform.position.y, 0);
            sTower.transform.position = newPos;
            yield return new WaitForSeconds(0.003f);
        }

        if (currentPosition.x < -5)
        {
            //-7.1 small, -7.92 medium , -9.22 big
            if (nexus.gameObject.activeSelf)
            {
                while (sTower.transform.position.x > -9.22)
                {
                    newPos = new Vector3(sTower.transform.position.x - 0.03f, sTower.transform.position.y, 0);
                    sTower.transform.position = newPos;
                    yield return new WaitForSeconds(0.003f);
                }
                TurretHit tHit = nexus.GetComponent<TurretHit>();

                StartCoroutine(tHit.TurHit());
                sTower.SetActive(false);


            }

            else if (nexus_ostecen.gameObject.activeSelf)
            {
                while (sTower.transform.position.x > -9.22)
                {
                    newPos = new Vector3(sTower.transform.position.x - 0.03f, sTower.transform.position.y, 0);
                    sTower.transform.position = newPos;
                    yield return new WaitForSeconds(0.003f);
                }
                TurretHit tHit = nexus_ostecen.GetComponent<TurretHit>();

                StartCoroutine(tHit.TurHit());
                sTower.SetActive(false);


            }

            else if (turret2.gameObject.activeSelf)
            {
                while (sTower.transform.position.x > -7.92)
                {
                    newPos = new Vector3(sTower.transform.position.x - 0.03f, sTower.transform.position.y, 0);
                    sTower.transform.position = newPos;
                    yield return new WaitForSeconds(0.003f);
                }
                TurretHit tHit = turret2.GetComponent<TurretHit>();

                StartCoroutine(tHit.TurHit());
                sTower.SetActive(false);


            }


            else if (turret2_ostecen.gameObject.activeSelf)
            {
                while (sTower.transform.position.x > -7.92)
                {
                    newPos = new Vector3(sTower.transform.position.x - 0.03f, sTower.transform.position.y, 0);
                    sTower.transform.position = newPos;
                    yield return new WaitForSeconds(0.003f);
                }
                TurretHit tHit = turret2_ostecen.GetComponent<TurretHit>();

                StartCoroutine(tHit.TurHit());
                sTower.SetActive(false);


            }

            else if (turret1.gameObject.activeSelf)
            {
                while (sTower.transform.position.x > - 7.1)
                {
                    newPos = new Vector3(sTower.transform.position.x - 0.03f, sTower.transform.position.y, 0);
                    sTower.transform.position = newPos;
                    yield return new WaitForSeconds(0.003f);
                }
                TurretHit tHit = turret1.GetComponent<TurretHit>();

                StartCoroutine(tHit.TurHit());
                sTower.SetActive(false);


            }
            else if (turret1_ostecen.gameObject.activeSelf)
            {
                while (sTower.transform.position.x > -7.1)
                {
                    newPos = new Vector3(sTower.transform.position.x + 0.03f, sTower.transform.position.y, 0);
                    sTower.transform.position = newPos;
                    yield return new WaitForSeconds(0.003f);
                }
                TurretHit tHit = turret1_ostecen.GetComponent<TurretHit>();

                StartCoroutine(tHit.TurHit());
                sTower.SetActive(false);


            }
        }



    }
}
