using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {

    public AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource.volume = 0.5f;
        audioSource.Play();
	}

    // Fades the sound source out
    public void fadeOut()
    {
        audioSource.volume -= 0.1f * Time.deltaTime;
    }

    // Fades the sound source in
    public void fadeIn()
    {
        audioSource.volume += 0.1f * Time.deltaTime;
    }

    // reduces the playing track with a specific value
    public void reduceHard()
    {
        audioSource.volume = 0.2f;
    }
	
	
}
