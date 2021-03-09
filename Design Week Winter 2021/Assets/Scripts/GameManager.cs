using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private AudioSource audioSource;

    [SerializeField] List<AudioClip> creepSounds = new List<AudioClip>();
    private List<AudioClip> activeCreepSounds = new List<AudioClip>();

    [SerializeField] List<AudioClip> playerFootsteps = new List<AudioClip>();
    private List<AudioClip> activePlayerFootsteps = new List<AudioClip>();

    public float playSoundDelay;
    private float playSoundTimer = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(playSoundTimer < playSoundDelay)
        {
            playSoundTimer += Time.deltaTime;
        }
        else
        {
            PlayCreepSound();
            playSoundTimer = 0;
        }
    }

    public void PlayCreepSound()
    {
        if(activeCreepSounds.Count == 0)
        {
            for (int i = 0; i < creepSounds.Count; i++)
            {
                activeCreepSounds.Add(creepSounds[i]);
            }
        }

        int randomNumber = Random.Range(0, activeCreepSounds.Count);

        audioSource.PlayOneShot(activeCreepSounds[randomNumber]);
        activeCreepSounds.RemoveAt(randomNumber);
    }

    public void PlayFootStep()
    {
        if (activePlayerFootsteps.Count == 0)
        {
            for (int i = 0; i < playerFootsteps.Count; i++)
            {
                activePlayerFootsteps.Add(playerFootsteps[i]);
            }
        }

        int randomNumber = Random.Range(0, activePlayerFootsteps.Count);

        audioSource.PlayOneShot(activePlayerFootsteps[randomNumber]);
        activePlayerFootsteps.RemoveAt(randomNumber);
    }

}
