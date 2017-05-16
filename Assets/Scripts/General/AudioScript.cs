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
		audioSource = this.gameObject.GetComponent <AudioSource> ();
		if (this.transform.FindChild ("Sound Effect") != null) {
			volumeSlider = this.transform.FindChild ("Sound Effect").GetComponentInChildren<Slider> ();
			if (PlayerPrefs.GetInt ("Volume") == 1)
				this.transform.FindChild ("Sound On").GetComponentInChildren<Toggle> ().isOn = true;
			else if (PlayerPrefs.GetInt ("Volume") == 0)
				this.transform.FindChild ("Sound On").GetComponentInChildren<Toggle> ().isOn = false;
		}
		
		
		if(this.transform.FindChild ("Sound Effect") != null)
		volumeSlider.value = PlayerPrefs.GetFloat ("Value", 0.5f);
		audioSource.Play ();

		//audioSource.time = PlayerPrefs.GetFloat ("Audio position", 0.0f)+0.4f;

	}
	private void Update(){
		//SaveSound ();
		if (PlayerPrefs.GetInt ("Volume") == 1)
			audioSource.volume = PlayerPrefs.GetFloat ("Value", 0.5f);
		else
			audioSource.volume = 0;
	}

	public void SaveSound(){
		PlayerPrefs.SetFloat ("Audio position", audioSource.time);
	}

	/*private void SetSound(){
		if (PlayerPrefs.GetInt ("SoundOn") == 1)
			soundOn = true;
		else
			soundOn = false;

	}
	*/

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
		bool IsOn = this.transform.FindChild ("Sound On").GetComponentInChildren<Toggle> ().isOn;
		if (IsOn)
			audioSource.volume = volumeSlider.value;
		PlayerPrefs.SetFloat ("Value", volumeSlider.value);
	}

	public void ToggleSound(){
		Debug.Log ("Toggled");
		bool IsOn = this.transform.FindChild ("Sound On").GetComponentInChildren<Toggle> ().isOn;
		if (IsOn) {
			Debug.Log ("On");
			audioSource.volume = PlayerPrefs.GetFloat("Value");
			PlayerPrefs.SetInt ("Volume", 1);

		} else {
			Debug.Log ("Off");
			audioSource.volume = 0;
			PlayerPrefs.SetInt ("Volume", 0);
		}
	}
}