using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMeAfterTime : MonoBehaviour
{
    [SerializeField]
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time += Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (time < Time.time)
            Destroy(gameObject);
    }
}
