using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class DebounceControll : MonoBehaviour
{
    private CircleCollider2D circleCollider;

    void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    public void DisableCollider()
    {
        if (circleCollider != null)
            circleCollider.enabled = false;
        Debug.Log("Collider Disabled");
    }

    public void EnableCollider()
    {
        if (circleCollider != null)
            circleCollider.enabled = true;
        Debug.Log("Collider Enabled");
    }
}
