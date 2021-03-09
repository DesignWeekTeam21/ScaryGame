using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    
    [SerializeField] AudioClip SoundToPlay;
    [SerializeField] float volume;
    [SerializeField] bool PlayedOnce = false;
    AudioSource audio;
    
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D col) {

        if (col.tag == "reticle"& !PlayedOnce) {
            Debug.Log("game");
            audio.PlayOneShot(SoundToPlay, volume);
            PlayedOnce = true;
        }
   
    
    }

}
