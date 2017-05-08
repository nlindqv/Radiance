﻿using System;
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

	//current score for level
	public int starCount;


	//Tutorial variables go here
	public int tutorialIndex;





	#region Constructors

	public LevelData(){
		this.levelIndex = -1;
		this.starCount = 3;
		this.levelName = "testing";
		tutorialIndex = -1;
	}

	public LevelData(int levelIndex){
		this.levelIndex = levelIndex;
		this.levelName = "Level" + levelIndex;
		starCount = 3;
		tutorialIndex = -1;
	}

	public LevelData(int levelIndex, string levelName){
		this.levelIndex = levelIndex;
		this.levelName = levelName;
		starCount = 3;
		tutorialIndex = -1;
	}

	public LevelData(int levelIndex, string levelName, int starCount){
		this.levelIndex = levelIndex;
		this.levelName = levelName;
		this.starCount = starCount;
		tutorialIndex = -1;
	}

	public LevelData(string path, int levelIndex, string levelName, int starCount){
		this.path = path;
		this.levelIndex = levelIndex;
		this.levelName = levelName;
		this.starCount = starCount;
		tutorialIndex = -1;
	}

	#endregion






	#region Override Functions

	public override string ToString(){
		string s = "Index: " + this.levelIndex.ToString () + " w/ stars: " + this.starCount.ToString() + " & name " + this.levelName;
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
	public Image icon;
}