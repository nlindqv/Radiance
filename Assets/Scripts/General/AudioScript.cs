using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioScript : MonoBehaviour {

    private AudioSource audioSource;
	private Slider volumeSlider;
	private bool soundOn;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
		SetSound ();
		audioSource = this.gameObject.GetComponent <AudioSource> ();
		if(this.transform.FindChild ("Sound Effect") !=null)
		volumeSlider = this.transform.FindChild ("Sound Effect").GetComponentInChildren<Slider> ();

		audioSource.volume = PlayerPrefs.GetFloat ("Volume", 0.5f);
		if(this.transform.FindChild ("Sound Effect") != null)
		volumeSlider.value = PlayerPrefs.GetFloat ("Volume", 0.5f);
		audioSource.Play ();

		//audioSource.time = PlayerPrefs.GetFloat ("Audio position", 0.0f)+0.4f;

	}
	private void Update(){
		//SaveSound ();
		audioSource.volume = PlayerPrefs.GetFloat ("Volume", 0.5f);
	}

	public void SaveSound(){
		PlayerPrefs.SetFloat ("Audio position", audioSource.time);
	}

	private void SetSound(){
		if (PlayerPrefs.GetInt ("SoundOn") == 1)
			soundOn = true;
		else
			soundOn = false;
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
		if (volumeSlider.value == 0) {
			Text text = this.transform.FindChild ("Toggle Sound").GetComponentInChildren<Text> ();
			text.text = "Sound off";
			soundOn = false;
		} else {
			Text text = this.transform.FindChild ("Toggle Sound").GetComponentInChildren<Text> ();
			text.text = "Sound on";
			soundOn = true;
		}
			
	}

	public void ToggleSound(){
		if (soundOn) {
			audioSource.volume = 0;
			volumeSlider.value = 0;
			PlayerPrefs.SetFloat ("Volume", 0);
			Text text = this.transform.FindChild ("Toggle Sound").GetComponentInChildren<Text> ();
			text.text = "Sound off";
		} else {
			audioSource.volume = 0.5f;
			volumeSlider.value = 0.5f;

			PlayerPrefs.SetFloat ("Volume", 0.5f);
			Text text = this.transform.FindChild ("Toggle Sound").GetComponentInChildren<Text> ();
			text.text = "Sound on";
		}
		soundOn = !soundOn;
	}
}