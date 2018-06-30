using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;

public class MyMenu
{
	public static string filePath = @"Assets/MyGroupData.asset";

	[MenuItem("Component/GenerateMyGroupData")]
	public static void Generate()
	{
		MyGroupData gData = (MyGroupData)ScriptableObject.CreateInstance<MyGroupData>();

		MemberData tom = new MemberData();
		tom.name = "Tom";
		tom.hp = 10;
		tom.exp = 20;

		MemberData sam = new MemberData();
		sam.name = "Tom";
		sam.hp = 30;
		sam.exp = 40;

		MemberData bob = new MemberData();
		bob.name = "Tom";
		bob.hp = 50;
		bob.exp = 60;

		gData.members.Add(tom);
		gData.members.Add(sam);
		gData.members.Add(bob);

		string folder = Path.GetDirectoryName(filePath);
		if(Directory.Exists(folder) == false)
		{
			Directory.CreateDirectory(folder);
		}

		AssetDatabase.CreateAsset(gData, filePath);
	}

	[MenuItem("Component/GenerateRandomMember")]
	public static void GenerateRandom()
	{
		if(File.Exists(filePath))
		{
			MyGroupData gData = (MyGroupData)AssetDatabase.LoadAssetAtPath(filePath, typeof(MyGroupData));
			MemberData randomMember = new MemberData();
			randomMember.name = Random.Range(55, 999).ToString();
			randomMember.hp = Random.Range(1, 99);
			randomMember.exp = Random.Range(1, 999);
			gData.members.Add(randomMember);
			EditorUtility.SetDirty(gData);
		}
	}
}