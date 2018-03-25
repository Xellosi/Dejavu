using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class DialogueManager : MonoBehaviour
{

	public Text nameText;
	public Text dialogueText;

	public const string SavePath = "Resources/Drama/";
	public const string fileExtension = ".txt";
	public List<string> dramaame;

	public Animator animator;
	public GameObject Dialogbox;
	public Dialogue _Dialogue;
	private Queue<string> sentences;

	// Use this for initialization
	void Start ()
	{
		sentences = new Queue<string> ();
		Dialogbox = GameObject.Find ("DialogueBox");
	}

	public void StartDialogue (string dialoguename)
	{
		/*animator.SetBool("IsOpen", true);

		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();*/
		string line;
		string fileFullPath = Path.Combine (Application.dataPath, SavePath);
		fileFullPath = Path.Combine (fileFullPath, dialoguename + fileExtension);
		if (Directory.Exists (fileFullPath)) {
			Debug.Log ("無此對話");
			return;
		}
		System.IO.StreamReader file = new System.IO.StreamReader (fileFullPath);
		while ((line = file.ReadLine ()) != null) {
			if (line [0] == '#') {
				continue;
			}
			try{
			_Dialogue = JsonUtility.FromJson<Dialogue> (line);
			}
			catch(Exception e){
				Debug.Log ("格式錯誤");
			}
		}
		file.Close ();
	}

	public void DisplayNextSentence ()
	{
		if (sentences.Count == 0) {
			EndDialogue ();
			return;
		}

		string sentence = sentences.Dequeue ();
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
		animator.SetBool ("IsOpen", false);
	}




}
