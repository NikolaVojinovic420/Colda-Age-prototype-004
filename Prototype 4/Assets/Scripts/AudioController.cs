using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    AudioClip engageDisengageClip;
    [SerializeField]
    AudioClip drawClip;
    [SerializeField]
    AudioClip flipClip;
    AudioSource AS;
    void Awake()
    {
        AS = GetComponent<AudioSource>();
    }
    public void PlayEngageDisengage()
    {
        AS.clip = engageDisengageClip;
        AS.Play();
    }
    public void PlayDraw()
    {
        AS.clip = drawClip;
        AS.Play();
    }
    public void PlayFlip()
    {
        AS.clip = flipClip;
        AS.Play();
    }
    //inserting new card audio
    public void PlayInserting()
    {

    }
}
