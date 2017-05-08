using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MemoryManager : MonoBehaviour {

	LevelData[] levels;

	public static void mem(){
		writeData ("kult");
		readData ();
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

}