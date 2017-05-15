using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioScript : MonoBehaviour {

    public AudioSource audioSource;
	public Slider volumeSlider;

	// Use this for initialization
	void Start () {
		audioSource.volume = PlayerPrefs.GetFloat ("Volume");
		volumeSlider.value = PlayerPrefs.GetFloat ("Volume");
		audioSource.Play ();

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

	/*public void VolumeController(){
		volumeSlider.value = audioSource.volume;
	}
	*/

	// Changes the volume according to slider value
	public void ChangeVolume(){
		Debug.Log ("changed");
		audioSource.volume = volumeSlider.value;
		PlayerPrefs.SetFloat ("Volume", volumeSlider.value);
	}
}