using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        SceneManager.LoadScene("StartScene");
    }
}
