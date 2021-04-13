using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    private Card card;
    public Vector3 moveDestination;
    // move animation
    [SerializeField]
    float moveSpeed;
    //rotation
    [SerializeField]
    float rotateSpeed;
    //disolve
    public GameObject DisolveEffect;
    [SerializeField]
    GameObject front;

    void Awake()
    {
        card = GetComponent<Card>();       
    }

    void Update()
    {
        Flip();
        MoveTo();
    }
    void MoveTo() => transform.position = Vector3.MoveTowards(gameObject.transform.position, moveDestination, moveSpeed * Time.deltaTime);
    void Flip()
    {
        if(card.IsActive())
            transform.rotation = Quaternion.RotateTowards(transform.rotation.normalized, Quaternion.Euler(transform.rotation.x, 0, 0).normalized, rotateSpeed * Time.deltaTime);
        else if(gameObject.GetComponent<Event>() != null)
            transform.rotation = Quaternion.RotateTowards(transform.rotation.normalized, Quaternion.Euler(transform.rotation.x, 180, -90f).normalized, rotateSpeed * Time.deltaTime);
        else
            transform.rotation = Quaternion.RotateTowards(transform.rotation.normalized, Quaternion.Euler(transform.rotation.x, 180, 0f).normalized, rotateSpeed * Time.deltaTime);
    }
    public void DisolveCard()
    {
        ParticleSystem.ShapeModule shape = DisolveEffect.GetComponent<ParticleSystem>().shape;
        shape.texture = front.GetComponent<SpriteRenderer>().sprite.texture;
        Instantiate(DisolveEffect, GameObject.FindWithTag("EventStage").transform);
    }
}
