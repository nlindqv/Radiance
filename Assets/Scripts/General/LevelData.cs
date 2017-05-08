using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelData{
	public int levelIndex;
//	public int LevelIndex { get { return levelIndex;} }

	public int starCount;

	public string levelName;
//	public string LevelName { get { return levelName;} }

	public LevelData(){
		this.levelIndex = -1;
		this.starCount = 3;
		this.levelName = "testing";
	}

	public LevelData(int levelIndex){
		this.levelIndex = levelIndex;
		this.levelName = "level" + levelIndex;
		starCount = 3;
	}

	public LevelData(int levelIndex, string levelName){
		this.levelIndex = levelIndex;
		this.levelName = levelName;
		starCount = 3;
	}

	public LevelData(int levelIndex, string levelName, int starCount){
		this.levelIndex = levelIndex;
		this.levelName = levelName;
		this.starCount = starCount;
	}

	public override String ToString(){
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
}

[Serializable]
public class LevelList{
	public List<LevelData> list = new List<LevelData>();
}
