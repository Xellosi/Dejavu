using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;

public class Menu
{
	/*
	public static string filePath = @"Assets/DramaEvents.asset";
	//[MenuItem("Component/GenerateMyGroupData")]
	public static void Generate()
	{
		DramaTriggers gData = (DramaTriggers)ScriptableObject.CreateInstance<DramaTriggers>();

		DramaEvents tom = new DramaEvents();
		DramaEvents sam = new DramaEvents();
		DramaEvents bob = new DramaEvents();

		gData.triggers.Add(tom);
		gData.triggers.Add(sam);
		gData.triggers.Add(bob);

		string folder = Path.GetDirectoryName(filePath);
		if(Directory.Exists(folder) == false)
		{
			Directory.CreateDirectory(folder);
		}

		AssetDatabase.CreateAsset(gData, filePath);
	}

	//[MenuItem("Component/GenerateRandomMember")]
	public static void GenerateRandom()
	{
		if(File.Exists(filePath))
		{
			DramaTriggers gData = (DramaTriggers)AssetDatabase.LoadAssetAtPath(filePath, typeof(DramaTriggers));
			DramaEvents randomMember = new DramaEvents();
			gData.triggers.Add(randomMember);
			EditorUtility.SetDirty(gData);
		}
	}
	*/

	[MenuItem("Level1/Newlevel1asset")]
	public static void level1Objects(){
		string path = @"Assets/Resources/Level1/Level1Objects.asset";
		string folder = Path.GetDirectoryName(path);
		if (!File.Exists (path)) {
			if(Directory.Exists(folder) == false){
			Directory.CreateDirectory(folder);
			}
			LevelObjects A = (LevelObjects)ScriptableObject.CreateInstance<LevelObjects> ();
			AssetDatabase.CreateAsset (A, path);
		}
	}
	//interest https://social.msdn.microsoft.com/Forums/vstudio/en-US/a6a4f573-9257-4116-b5af-895bcabd4d32/create-the-name-of-an-object-instance-dynamically?forum=csharpgeneral

	[MenuItem("Level1/NewlevelEvents")]
	public static void Level1Triggers(){
		string Objectspath = @"Assets/Resources/Level1/Level1Objects.asset";
		string Eventpath = @"Assets/Resources/Level1/Level1Events.asset";
		LevelObjects A = (LevelObjects)AssetDatabase.LoadAssetAtPath(Objectspath, typeof(LevelObjects));
		DramaTriggers D = (DramaTriggers)ScriptableObject.CreateInstance<DramaTriggers> ();
		foreach (string drag in A.drag) {
			foreach (string hit in A.hit) { 
				string e = drag + "," + hit;
				D.triggers.Add (new DramaEvents(e));
			}
		}
		if (File.Exists (Objectspath)) {
			AssetDatabase.CreateAsset (D, Eventpath);
		}
	}
}