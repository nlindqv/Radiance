using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
public class LevelData{

	//index for level
	public int levelIndex;

	//name for level
	public string levelName;

	//path to current scene
	public string path;


	//Tutorial variables go here
	public int tutorialIndex;





	#region Constructors

	public LevelData(){
		this.levelIndex = -1;
		this.levelName = "testing";
		tutorialIndex = -1;
	}

	public LevelData(int levelIndex){
		this.levelIndex = levelIndex;
		this.levelName = "Level" + levelIndex;
		tutorialIndex = -1;
	}

	public LevelData(int levelIndex, string levelName){
		this.levelIndex = levelIndex;
		this.levelName = levelName;
		tutorialIndex = -1;
	}

	public LevelData(string path, int levelIndex, string levelName){
		this.path = path;
		this.levelIndex = levelIndex;
		this.levelName = levelName;
		tutorialIndex = -1;
	}

	public LevelData(string path, int levelIndex, string levelName, int tutorialIndex){
		this.path = path;
		this.levelIndex = levelIndex;
		this.levelName = levelName;
		this.tutorialIndex = tutorialIndex;
	}

	#endregion






	#region Override Functions

	public override string ToString(){
		string s = "Index: " + this.levelIndex.ToString () + " w/ path: " + this.path + " & name " + this.levelName;
		return s;
	}
	/*
	public class Comparer<LevelData> : IComparer<LevelData>
	{
		private LevelData comparer;
		public Comparer(Func<T, T, int> comparer)
		{
			this.comparer = comparer;
		}
		public static IComparer<T> Create(Func<T, T, int> comparer)
		{
			return new FunctionalComparer<T>(comparer);
		}
		public int Compare(T x, T y)
		{
			return comparer(x, y);
		}
	}*/

	#endregion


}

[Serializable]
public class LevelList{
	public List<LevelData> list = new List<LevelData>();
}


[Serializable]
public class Tutorial{
	public string title;
	public string tutorialText;
	public string iconPath;
    public bool tutorialPlayedBefore;

    public Tutorial(){
		this.title = "Title";
		this.tutorialText = "text";
		this.icon = null;
	}


	public Tutorial(string title = "Title", string text = "text", string path = ""){
		this.title = title;
		this.tutorialText = text;
		this.iconPath = path;
	}
}

[Serializable]
public class TutorialList{
	public List<Tutorial> list = new List<Tutorial> ();
}
