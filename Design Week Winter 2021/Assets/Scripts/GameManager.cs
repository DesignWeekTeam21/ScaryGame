using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private AudioSource audioSource;

    [SerializeField] List<AudioClip> creepSounds = new List<AudioClip>();
    private List<AudioClip> activeCreepSounds = new List<AudioClip>();

    [SerializeField] List<AudioClip> playerFootsteps = new List<AudioClip>();
    private List<AudioClip> activePlayerFootsteps = new List<AudioClip>();

    public AudioClip lockingDoor;
    public AudioClip ambientMusic;

    public float playSoundDelay;
    private float playSoundTimer = 0;

    public float playMusicDelay;
    private float playMusicTimer = 0;
    private bool musicPlaying = false;

    public int playerTasksCompleted = 0;

    [Header("Quest Items")]

    private bool movedWateringCan = false;
    public GameObject wateringCan;
    public GameObject centrePiece;
    [SerializeField] Transform wateringCanMovePosition;
    [SerializeField] Transform centrePieceMovePosition;

    public GameObject catFood;
    public GameObject catBowl;
    public Sprite filledCatBowl;
    private bool updatedCatBowl = false;
    public GameObject flashlight;
    public GameObject key;

    public Image fadeToBlack;
    public Text gameOverText;
    private float a = 0;
    private float d = 0;

    public bool GameOver = false;

    public float reloadSceneDelay;
    private float reloadSceneTimer = 0;


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

        QuestUpdates();

        if (GameOver)
        {
            GameOverFade();
        }

        playMusicTimer += Time.deltaTime;

        //Start playing music after a delay
        if (playMusicTimer > playMusicDelay && !musicPlaying)
        {
            audioSource.PlayOneShot(ambientMusic);
            musicPlaying = true;
        }
    }

    void QuestUpdates()
    {
        if (PlayerController.instance.reachedKitchen && !movedWateringCan)
        {
            wateringCan.transform.position = wateringCanMovePosition.position;
            centrePiece.transform.position = centrePieceMovePosition.position;
            centrePiece.transform.rotation = centrePieceMovePosition.rotation;
            movedWateringCan = true;
        }

        if(playerTasksCompleted >= 3)
        {
            Checklist.instance.ShowFinalTask();
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

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void GameOverFade()
    {
        Debug.Log("this went");
        //fadeToBlack.gameObject.transform.Translate(0, 15 * Time.deltaTime, 0);
        fadeToBlack.color = new Color(fadeToBlack.color.r, fadeToBlack.color.g, fadeToBlack.color.b, a);
        a += 2 * Time.deltaTime;

        if(a >= 1)
        {
            //gameOverText.gameObject.transform.Translate(0, 15 * Time.deltaTime, 0);
            gameOverText.color = new Color(gameOverText.color.r, gameOverText.color.g, gameOverText.color.b, d);
            d += 2 * Time.deltaTime;
        }

        reloadSceneTimer += Time.deltaTime;

        if(reloadSceneTimer > reloadSceneDelay)
        {
            SceneManager.LoadScene("StartScreen");
            reloadSceneTimer = 0;
        }
        
    }

}
