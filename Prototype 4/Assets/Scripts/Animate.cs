using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    // move animation
    public Vector3 moveDestination;
    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float rotateSpeed;
    public bool poof = false;
    public GameObject particleSplash;

    private Card card;

    void Awake()
    {
        card = GetComponent<Card>();
    }

    void Update()
    {
        Flip();
        Poof();
        MoveTo();
    }
    public void MoveTo() => transform.position = Vector3.MoveTowards(gameObject.transform.position, moveDestination, moveSpeed * Time.deltaTime);
    public void Flip()
    {
        if(card.IsActive())
            transform.rotation = Quaternion.RotateTowards(transform.rotation.normalized, Quaternion.Euler(0, 0, 0).normalized, rotateSpeed * Time.deltaTime);
        else
            transform.rotation = Quaternion.RotateTowards(transform.rotation.normalized, Quaternion.Euler(0, 180, 0f).normalized, rotateSpeed * Time.deltaTime);
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
}
