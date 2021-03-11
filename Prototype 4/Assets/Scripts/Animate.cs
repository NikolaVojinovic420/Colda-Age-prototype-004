using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    // move animation
    [SerializeField]
    public GameObject moveDestination;
    [SerializeField]
    float moveSpeed;
    // flip animation
    [SerializeField]
    float rotateSpeed;
    [SerializeField]
    float angle;
    // effects
    public bool poof = false;
    public GameObject particleSplash;
    void Awake() //change parent = change new destination
    {
        moveDestination = gameObject;
    }
    void FixedUpdate()
    {
        Flip();
        MoveTo();
        Poof();
    }
    //need to use in Udpate or FixedUpdate (prefer FixedUpdate)
    public void MoveTo() => gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, moveDestination.transform.position, moveSpeed * Time.deltaTime);
    public void Flip() => transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, angle, 0), rotateSpeed * Time.deltaTime);
    public void Poof()
    {
        if (poof)
        {
            Instantiate(particleSplash, gameObject.transform);
            poof = false;
        }
    }      
    public void Disapear()
    {

    }
}
