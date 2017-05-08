using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class MemoryManager : MonoBehaviour {

	private static string PATH = Application.persistentDataPath + "/Levels.json";

//	static TextAsset file = (TextAsset)System.IO.File.ReadAllText(Application.persistentDataPath + "/Levels.json");
	private static LevelList LEVELS = JsonUtility.FromJson<LevelList> (System.IO.File.ReadAllText(PATH));


	//TODO implement function that gets indexoffset?
	private const int levelIndexOffset = 7;


	private static LevelData getLevel(){
		int index = SceneManager.GetActiveScene ().buildIndex;
		return LEVELS.list [index - levelIndexOffset];
	}


	private static void Write2Json(){
		LevelList origin = JsonUtility.FromJson<LevelList> (File.ReadAllText (PATH));

		for (int i = 0; i < LEVELS.list.Count; i++) {
			origin.list [i].starCount = LEVELS.list [i].starCount;
		}
		
		string json = JsonUtility.ToJson (LEVELS);

		using (StreamWriter s = new StreamWriter (PATH)) {
			s.Write (json);
		}
	}



	public static string LoadLevelName(){
		print (getLevel ().levelName + " has starCount " + getLevel ().starCount);
		return getLevel().levelName;
	}

	public static int LoadTutorialIndex(){
		return getLevel().tutorialIndex;
	}

	public static int LoadScore(){
		return getLevel ().starCount;
	}


	public static void WriteScore2Memory(int score){
		getLevel ().starCount = score;
		Write2Json ();
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