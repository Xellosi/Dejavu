using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using DG.Tweening;
public class DialogueManager : MonoBehaviour
{

	public Text nameText;
	public Text dialogueText;

	public const string SavePath = "Resources/Drama/";
	public const string fileExtension = ".txt";

	public GameObject Dialogbox;
	public Queue<Dialogue> _Dialogue;
	private Queue<string> sentences;

	// Use this for initialization
	void Start ()
	{
		sentences = new Queue<string> ();
		_Dialogue = new Queue<Dialogue>();
		Dialogbox = GameObject.Find ("DialogueBox");
		Dialogbox.SetActive(false);
	}

	public void StartDialogue (string dialoguename)
	{
		_Dialogue.Clear();
		Dialogbox.SetActive(true);
		string line;
		string fileFullPath = Path.Combine (Application.dataPath, SavePath);
		fileFullPath = Path.Combine (fileFullPath, dialoguename + fileExtension);
		if ((Directory.Exists (fileFullPath))) {
			Debug.Log ("無此對話");
			return;
		}
		System.IO.StreamReader file = new System.IO.StreamReader (fileFullPath);
		while((line = file.ReadLine())!=null){
			Debug.Log(line);
		if (line [0] == '#') {
				continue;
			}
		try{
			_Dialogue.Enqueue(JsonUtility.FromJson<Dialogue>(line));
			}
			catch(Exception e){
				Debug.Log (e.Message);
				return;
			}
		}
		file.Close ();
		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
		if (_Dialogue.Count==0) {
			EndDialogue ();
			return;
		}
		Dialogue currentDialogue=_Dialogue.Dequeue();
		nameText.text=currentDialogue.name;
		string sentence = currentDialogue.sentence;
		StopAllCoroutines ();
		StartCoroutine (TypeSentence (sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray()) {
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue ()
	{
		Dialogbox.SetActive(false);
	}

	void SetTestDialog(){
		string fullpath=Path.Combine(Application.dataPath,SavePath);
		fullpath=Path.Combine(fullpath,"test"+fileExtension);
		Dialogue temp = new Dialogue();
		using (System.IO.StreamWriter file = 
            new System.IO.StreamWriter(fullpath))
		{
			for (int i=0 ; i<5 ;i++){
			temp.name="我是第"+Convert.ToString(i)+"人";
			temp.sentence="我是第"+Convert.ToString(i)+"句";
			file.WriteLine(JsonUtility.ToJson(temp));
			}
		}
	}
}
