using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public AudioSource musicSource1;
    public AudioSource musicSource2;
    private AudioSource activeSource;

    private bool transitioning = false;
    private bool isPlaying = false;
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

    public void TransitionMusic()
    {
        if (!transitioning)
        {
            StartCoroutine(TransitionCoroutine());
        }
    }

    IEnumerator TransitionCoroutine()
    {
        transitioning = true;

        // Gradually reduce the volume of the current music
        while (activeSource.volume > 0)
        {
            activeSource.volume -= Time.deltaTime;
            yield return null;
        }

        // Stop current music
        activeSource.Stop();

        // Swap the active source
        activeSource = (activeSource == musicSource1) ? musicSource2 : musicSource1;

        // Play the new music and gradually increase its volume
        PlayMusic(activeSource);
        activeSource.volume = 0;
        activeSource.Play();

        while (activeSource.volume < 1)
        {
            activeSource.volume += Time.deltaTime;
            yield return null;
        }

        transitioning = false;
    }
}
