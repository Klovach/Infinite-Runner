using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SoundManager : MonoBehaviour
{
    // Singleton instance.
    /*Why a Singleton?
     *A singleton pattern should be utilized when you only want one instance of a class to exist and persist throughout a project.
     *A sound manager is a common use case for a Singleton. Use this class to add and remove sounds as needed. 
     */
    private static SoundManager instance;

    // Audio clips for different sounds:
    public AudioClip clickSound;
    public AudioClip deathSound;
    public AudioClip pickupSound;
    public AudioClip jumpSound;

    // Background music for levels:
    public AudioClip scene1Music;
    public AudioClip scene2Music;
   

    // AudioSource components for sound effects and background music:
    private AudioSource sfxAudioSource;
    private AudioSource bgmAudioSource;

    // Ensure only one instance of SoundManager exists.
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();

                if (instance == null)
                {
                    GameObject soundManagerObject = new GameObject("SoundManager");
                    instance = soundManagerObject.AddComponent<SoundManager>();
                }
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            sfxAudioSource = gameObject.AddComponent<AudioSource>();
            bgmAudioSource = gameObject.AddComponent<AudioSource>();

            bgmAudioSource.volume = 0.2f;
            bgmAudioSource.loop = true;
        }
        else
        {
            // If an instance already exists, destroy this one.
            Destroy(gameObject);
        }
    }

     void Start()
    {
      PlayLevelMusic(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void PlayClickSound()
    {
        PlaySound(clickSound);
    }

    public void PlayDeathSound()
    {
        PlaySound(deathSound);
    }

    public void PlayPickupSound()
    {
        PlaySound(pickupSound);
    }

    public void PlayJumpSound()
    {
        PlaySound(jumpSound);
    }


    public void PlayLevelMusic(int level)
    {
        // Reset
        bgmAudioSource.Stop();
        AudioClip levelMusic = GetLevelMusic(level);

        if (levelMusic != null)
        {
            bgmAudioSource.clip = levelMusic;
            bgmAudioSource.Play();
        }
        else
        {
            Debug.Log(GetLevelMusic(level));
        }
    }

    public void StopLevelMusic()
    {
        bgmAudioSource.Stop();
    }

    private void PlaySound(AudioClip clip)
    {
        if (sfxAudioSource.isPlaying)
        {
            sfxAudioSource.Stop();
        }
        sfxAudioSource.PlayOneShot(clip);
    }

    private AudioClip GetLevelMusic(int level)
    {
        switch (level)
        {
            case 1:
                return scene1Music;
            case 2:
                return scene2Music;
            default:
                return null;
        }
    }
}