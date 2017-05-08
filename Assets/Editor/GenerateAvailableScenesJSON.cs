using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System.IO;
using UnityEditor.Callbacks;

public static class GenerateAvailableScenesJSON
{
    [PostProcessBuild]
    public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
    {
		Debug.Log("OnPostprocessBuild executed");

		LevelList ls = new LevelList ();
		List<string> paths = GetLevelScenes();

		int i = 0;
		foreach (string path in paths) {
			int lastBackslash = path.LastIndexOf ('/');
			int lastDot = path.LastIndexOf ('.');

			string name = path.Substring (lastBackslash + 1, lastDot-lastBackslash-1);

			int score = Mathf.RoundToInt(Random.Range(0,4));

			LevelData t = new LevelData (path, i++, name, score);

			ls.list.Add (t);
		}

		string jsonObj = UnityEngine.JsonUtility.ToJson(ls);
		Debug.Log("scenes retrieved");

		using (StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/Levels.json", false))
		{
			writer.Write(jsonObj);
		}


		Debug.Log("scenes written");
    }

    /// <summary>
    ///  Ger en ordnad lista baserat på namn på alla scener med sökväg i mappen "levels"
    /// </summary>
    /// <returns>Lista med levels sorterade på namn</returns>
	private static List<string> GetLevelScenes()
	{
		//hämta alla scener, lägg bara till de scener som ska ingå som nivåer
		List<string> sceneList = new List<string>();
		foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes) {
			if(scene.path.Contains("GameScenes/Levels"))
				sceneList.Add(scene.path);
		}

		sceneList.Sort ();

		return sceneList;
	}
}
