using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class MemoryManager : MonoBehaviour {


	static TextAsset LevelFile = Resources.Load<TextAsset> ("Levels");
	private static LevelList LEVELS = JsonUtility.FromJson<LevelList> (LevelFile.text);

	static TextAsset TutFile = Resources.Load<TextAsset> ("Tutorials");
	private static TutorialList TUTORIALS = JsonUtility.FromJson<TutorialList> (TutFile.text);

	static TextAsset IndexOffsetFile = Resources.Load<TextAsset> ("indexOffset");
	private static int levelIndexOffset = int.Parse(IndexOffsetFile.text);



	private static LevelData getLevel(){
		int index = SceneManager.GetActiveScene ().buildIndex;
//		Debug.Log ("Getting scene w/ index: " + index + " and levelind " + levelIndexOffset);
		return LEVELS.list [index - levelIndexOffset];
	}


	#region Public Functions

	public static string LoadLevelName(){
		return getLevel().levelName;
	}

	public static int LoadTutorialIndex(){
		int index;
		try
		{
			index = getLevel().tutorialIndex;
		}
		catch(System.ArgumentOutOfRangeException e){
			index = -1;
		}

		return index;
	}

	public static int LoadScore(){
		int score = PlayerPrefs.GetInt (getLevel ().levelName, 0);
		return score;
	}

	public static Tutorial LoadTutorial(int index){
		return TUTORIALS.list[index];
	}


	public static void WriteScore2Memory(int score){
		PlayerPrefs.SetInt (getLevel ().levelName, score);
	}



	public static int[] LoadAllScores(){
		int[] scores = new int[LEVELS.list.Count];
		for(int i = 0; i < LEVELS.list.Count; i++){
			scores [i] = PlayerPrefs.GetInt (LEVELS.list [i].levelName, 0);
//			print (LEVELS.list [i].levelName + " has starcount " + scores [i].ToString ());
		}
		return scores;
	}

	public static TutorialList LoadAllTutorials(){
		TutorialList tutorials = new TutorialList();
		for(int i = 0; i < TUTORIALS.list.Count; i++)
			tutorials.list.Add(TUTORIALS.list[i]);
		return tutorials;
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

	/// <summary>
	/// Loads a .png from path and returns it as a Sprite.
	/// </summary>
	/// <returns>.png as Sprite</returns>
	/// <param name="path">Path to object</param>
	public static Sprite loadIcon(string path){
		//get file
		byte[] data = File.ReadAllBytes(path);

		//create texture from file
		Texture2D texture = new Texture2D(64, 64, TextureFormat.ARGB32, false);
		texture.LoadImage(data);
		texture.name = Path.GetFileNameWithoutExtension(path);

		//create sprite from texture
		Sprite s = Sprite.Create (texture, new Rect (0, 0, texture.width, texture.height), Vector2.zero);
		return s;
	}

	public static LevelList GetLevels(){
		return LEVELS;
	}
		

	#endregion




	#region WriterHelpFunctions

	public static void mem(){
		//writeOnce();
		//readData ();

		//writeTutorials ();

	}

	public static void writeTutorials(){
		TutorialList tut = new TutorialList();
		for (int i = 0; i < 5; i++) {
			string iconPath = Application.dataPath + "/Resources/icons/tutorial" + i + ".png";
			Tutorial t = new Tutorial (LEVELS.list [i].levelName, "item #" + i + " does a lot of fun stuff.", iconPath);
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