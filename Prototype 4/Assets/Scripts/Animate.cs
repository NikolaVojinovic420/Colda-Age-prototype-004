using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    // move animation
    public Transform moveDestination;
    [SerializeField]
    float moveSpeed;
    // flip animation
    [SerializeField]
    float rotateSpeed;
    [SerializeField]
    float angle;
    public bool poof = false;
    public GameObject particleSplash;
    void FixedUpdate()
    {
        Flip();
        Poof();
        CheckParent();
    }
    public void MoveTo() => gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, moveDestination.transform.position, moveSpeed * Time.deltaTime);
    public void Flip()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, angle, 0), rotateSpeed * Time.deltaTime);
    }
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
    void CheckParent()
    {
        if (moveDestination != gameObject.transform.parent)
            moveDestination = gameObject.transform.parent;
        MoveTo();
    }
}
