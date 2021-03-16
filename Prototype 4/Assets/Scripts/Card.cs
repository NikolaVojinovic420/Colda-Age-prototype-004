using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private bool active;
    public void transfer(Transform newParent, Vector3 position, bool active)
    {
        this.active = active;
        gameObject.transform.SetParent(newParent);
        gameObject.transform.position = position;
    }
    public void transfer(Transform newParent, bool active)
    {
        Vector3 position = newParent.position;
        transfer(newParent, position, active);
    }
}
