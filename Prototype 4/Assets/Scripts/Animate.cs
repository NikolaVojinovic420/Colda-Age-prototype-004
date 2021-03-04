using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    // move animation
    [SerializeField]
    GameObject moveDestination;
    [SerializeField]
    float moveSpeed;
    // flip animation
    [SerializeField]
    float rotateSpeed;
    [SerializeField]
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        moveDestination = gameObject;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Flip();
        MoveTo();
    }
    //need to use in Udpate or FixedUpdate (prefer FixedUpdate)
    public void MoveTo() => gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, moveDestination.transform.position, moveSpeed * Time.deltaTime);
    public void Flip() => transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, angle, 0), rotateSpeed * Time.deltaTime); 
    public void Poof()
    {

    }
    public void Disapear()
    {

    }
}
