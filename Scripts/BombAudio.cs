using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAudio : MonoBehaviour
{
    public AudioSource BombSound;
    public float waittime;

    // Start is called before the first frame update
    void Start()
    {
        BombSound = GetComponent<AudioSource>();
        BombSound.PlayDelayed(waittime);
        BombSound.Play();
    }
}
