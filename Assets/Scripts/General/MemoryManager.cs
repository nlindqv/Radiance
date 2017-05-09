using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class MemoryManager : MonoBehaviour {

//	private static string PATH = Application.persistentDataPath + "/Levels.json";

	static TextAsset file = Resources.Load<TextAsset> ("Levels");
	private static LevelList LEVELS = JsonUtility.FromJson<LevelList> (file.text);


	//TODO implement function that gets indexoffset?
	private const int levelIndexOffset = 7;


	private static LevelData getLevel(){
		int index = SceneManager.GetActiveScene ().buildIndex;
		return LEVELS.list [index - levelIndexOffset];
	}





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


	public static int[] LoadAllScores(){
		int[] scores = new int[LEVELS.list.Count];
		for(int i = 0; i < LEVELS.list.Count; i++){
			scores [i] = PlayerPrefs.GetInt (LEVELS.list [i].levelName, 0);
			print (LEVELS.list [i].levelName + " has starcount " + scores [i].ToString ());
		}
		return scores;
	}



	public static void WriteScore2Memory(int score){
		PlayerPrefs.SetInt (getLevel ().levelName, score);
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







	#region TestFunctions

	public static void mem(){
		//writeOnce();
		//readData ();

	}

	public static void writeOnce(){
		LevelList ls = new LevelList ();
		for (int i = 1; i <= 20; i++) {
			string name = "Level " + i;
			LevelData t = new LevelData (i - 1, name, Mathf.RoundToInt(Random.Range(0,4)));
			ls.list.Add (t);
		}
		string path2write = "Assets/Resources/infoTest.json";
		using (StreamWriter s = new StreamWriter (path2write)) {
			s.Write(JsonUtility.ToJson(ls));
		}

	}

	public static void writeData(string data){

		LevelData l1 = new LevelData (1, data, 2);

		LevelData l2 = new LevelData (2, "men", 1);

		LevelData l3 = new LevelData (5, "nytt", 4);

		LevelData l4 = new LevelData (3, "gam", 0);

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