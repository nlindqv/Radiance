using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MemoryManager : MonoBehaviour {


	static TextAsset LevelFile = Resources.Load<TextAsset> ("Levels");
	private static LevelList LEVELS = JsonUtility.FromJson<LevelList> (LevelFile.text);

//	static TextAsset TutFile = Resources.Load<TextAsset> ("Tutorials");
//	private static TutorialList TUTORIALS = JsonUtility.FromJson<TutorialList> (TutFile.text);

	private static readonly int levelIndexOffset = GetIndexOffset();


	#region Private functions

	/// <summary>
	/// Gets index offset for levels, that is removes all menu scenes and testlevels from
	/// indexing to make sure we access correct space in memory
	/// </summary>
	/// <returns>offset</returns>
	private static int GetIndexOffset(){
		int offset = 0;
		foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes) {
			if (!scene.path.Contains ("GameScenes/Levels")) {
				offset++;
			}
			else if(scene.path.Contains("GameScenes/Levels"))
				break;
		}
		print (offset);
		return offset;
	}

	private static LevelData getLevel(){
		int index = SceneManager.GetActiveScene ().buildIndex;
		return LEVELS.list [index - levelIndexOffset];
	}

	#endregion

	#region Public Functions

	public static string LoadLevelName(){
		return getLevel().levelName;
	}

	public static int LoadTutorialIndex(){
		return getLevel().tutorialIndex;
	}

	public static int LoadScore(){
		int score = PlayerPrefs.GetInt (getLevel ().levelName, 0);
		return score;
	}

	public static Tutorial LoadTutorial(int index){
		return new Tutorial();
	}


	public static void WriteScore2Memory(int score){
		PlayerPrefs.SetInt (getLevel ().levelName, score);
	}



	public static int[] LoadAllScores(){
		int[] scores = new int[LEVELS.list.Count];
		for(int i = 0; i < LEVELS.list.Count; i++){
			scores [i] = PlayerPrefs.GetInt (LEVELS.list [i].levelName, 0);
			print (LEVELS.list [i].levelName + " has starcount " + scores [i].ToString ());
		}
		return scores;
	}

	/// <summary>
	/// Loads paths for all levels.
	/// </summary>
	/// <returns>Paths as list of strings</returns>
	public static List<string> LoadPaths(){
		List<string> paths = new List<string>();
		foreach (LevelData level in LEVELS.list) {
			paths.Add (level.path);
		}
		return paths;
	}

	public static LevelList GetLevels(){
		return LEVELS;
	}
		

	#endregion




	#region TestFunctions

	public static void mem(){
		//writeOnce();
		//readData ();

		writeTutorials ();

	}

	public static void writeTutorials(){
		TutorialList tut = new TutorialList();
		for (int i = 0; i < 5; i++) {
			Tutorial t = new Tutorial (LEVELS.list [i].levelName, "item #" + i + " does a lot of fun stuff.");
			tut.list.Add(t);
		}
		string path2write = "Assets/Resources/Tutorials.json";
		using (StreamWriter s = new StreamWriter (path2write)) {
			s.Write(JsonUtility.ToJson(tut));
		}
	}

	public static void writeOnce(){
		LevelList ls = new LevelList ();
		for (int i = 1; i <= 20; i++) {
			string name = "Level " + i;
			LevelData t = new LevelData (i - 1, name);
			ls.list.Add (t);
		}
		string path2write = "Assets/Resources/infoTest.json";
		using (StreamWriter s = new StreamWriter (path2write)) {
			s.Write(JsonUtility.ToJson(ls));
		}

	}

	public static void writeData(string data){

		LevelData l1 = new LevelData (1, data);

		LevelData l2 = new LevelData (2, "men");

		LevelData l3 = new LevelData (5, "nytt");

		LevelData l4 = new LevelData (3, "gam");

//		print (l1);
//		print (l2);
//		print (l3);
//		print (l4);

//		LevelData[] ls = { l1, l2, l3, l4 };
		LevelList ls = new LevelList();
		ls.list.Add (l1);
		ls.list.Add (l2);
		ls.list.Add (l3);
		ls.list.Add (l4);
		ls.list.Add (l1);

		//Comparer<LevelData> c = new Comparer<LevelData> ();

		//ls.list.Sort (c);


		string path2write = "Assets/Resources/infoTest.json";
		using (StreamWriter s = new StreamWriter (path2write)) {
			s.Write(JsonUtility.ToJson(ls));
		}
	}

	private static void readData(){
		string path = "Assets/Resources/infoTest.json";
		using (StreamReader s = new StreamReader (path)) {
			string katt = s.ReadLine ();
			LevelList l = JsonUtility.FromJson<LevelList> (katt);
			foreach (LevelData ld in l.list)
				print (ld);
		}
	}




	#endregion

}