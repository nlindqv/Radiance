using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static  class SceneSelector {

	public static  void LoadSceneByName (string SceneName) 
	{
		SceneManager.LoadScene (SceneName);

	}
}
