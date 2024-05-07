using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public AudioSource musicSource1;
    public AudioSource musicSource2;
    public AudioSource FiresfxSource;
    private AudioSource activeSource;

    private bool transitioning = false;
    // private bool isPlaying = false;
    void Awake()
    {
        // isPlaying = activeSource.isPlaying;
        // Make sure that there is only one instance of the AudioManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (TimeController.isPresent) PlayMusic(FiresfxSource);
        FiresfxSource.loop = true;
        activeSource = musicSource1;
        PlayMusic(activeSource);
        activeSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayMusic(AudioSource source)
    {
        if (!source.isPlaying)
        {
            source.Play();
        }
    }

    public void TransitionMusic(bool isPresent)
    {
        if (!transitioning)
        {
            StartCoroutine(TransitionCoroutine(isPresent));
        }
    }

    IEnumerator TransitionCoroutine(bool isPresent)
    {
        transitioning = true;

        // Gradually reduce the volume of the current music
        while (activeSource.volume > 0 && FiresfxSource.volume > 0)
        {
            FiresfxSource.volume -= Time.deltaTime * 0.5f;
            activeSource.volume -= Time.deltaTime;
            yield return null;
        }

        // Stop current music
        activeSource.Stop();
        FiresfxSource.Stop();

        // Swap the active source
        activeSource = (activeSource == musicSource1) ? musicSource2 : musicSource1;

        // Play the new music and gradually increase its volume
        PlayMusic(activeSource);
        activeSource.volume = 0;
        activeSource.Play();
        activeSource.loop = true;
        FiresfxSource.volume = 0;
        FiresfxSource.Play();
        FiresfxSource.loop = true;
        while (activeSource.volume < 1 && FiresfxSource.volume < 0.3)
        {
            // Debug.Log("Change sound and now the ispresent is " + TimeController.isPresent);
            // Play the fire sound effect on present
            if (!isPresent) FiresfxSource.volume += Time.deltaTime * 0.5f;
            activeSource.volume += Time.deltaTime * 0.5f;
            yield return null;
        }
        


        transitioning = false;
    }
}
