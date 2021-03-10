using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    [SerializeField] AudioClip sound;
    [SerializeField] int targetTasksCompleted;
    bool played = false;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !played && GameManager.instance.playerTasksCompleted >= targetTasksCompleted)
        {
            GameManager.instance.PlaySound(sound);
            played = true;
        }
    }
}
