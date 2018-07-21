using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;

public class MyMenu
{
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

	[MenuItem("Level1/Newlevel1asset")]
	public static void level1Objects(){
		string path = @"Assets/Script/Level1/Level1Objects.asset";
		LevelObjects A = (LevelObjects)ScriptableObject.CreateInstance<LevelObjects>();
		AssetDatabase.CreateAsset(A,path);
	}

	[MenuItem("Level1/GenerateEvents")]
	public static void Level1Triggers(){

	}
}