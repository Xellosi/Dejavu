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

	private GameObject Dialogbox;
	private GameObject ContinueButton;
	private Queue<Dialogue> _Dialogue= new Queue<Dialogue>();
	private Image char1,char2,char3;
	private Dictionary<string,Sprite> imagepool=new Dictionary<string,Sprite>();


	// Use this for initialization
	void Start ()
	{
		Dialogbox = GameObject.Find ("DialogueBox");
		char1=GameObject.Find("char1").GetComponent<Image>();
		char2=GameObject.Find("char2").GetComponent<Image>();
		char3=GameObject.Find("char3").GetComponent<Image>();
		ContinueButton=GameObject.Find("ContinueButton");
		EndDialogue();
	}

	public void StartDialogue (string dialoguename)
	{
		_Dialogue.Clear();
		Dialogbox.SetActive(true);
		char1.transform.gameObject.SetActive(true);
		char2.transform.gameObject.SetActive(true);
		char3.transform.gameObject.SetActive(true);
		string line;
		string fileFullPath = Path.Combine (Application.dataPath, SavePath);
		fileFullPath = Path.Combine (fileFullPath, dialoguename + fileExtension);
		if ((Directory.Exists (fileFullPath))) {
			Debug.Log ("無此對話");
			return;
		}
		System.IO.StreamReader file = new System.IO.StreamReader (fileFullPath);
		while((line = file.ReadLine())!=null){
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
		ContinueButton.GetComponentInChildren<Text>().text="Continue>>";
		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
		if (_Dialogue.Count==0) {
			EndDialogue ();
			return;
		}
		else if (_Dialogue.Count==1){
			ContinueButton.GetComponentInChildren<Text>().text="End>>";
		}
		Dialogue currentDialogue=_Dialogue.Dequeue();
		nameText.text=currentDialogue.name;
		string sentence = currentDialogue.sentence;
		Setimage(currentDialogue);
		StopAllCoroutines ();
		ContinueButton.SetActive(false);
		StartCoroutine (TypeSentence (sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray()) {
			dialogueText.text += letter;
			yield return null;
		}
		ContinueButton.SetActive(true);
	}

	//To Do 與上一對話的比較更變
	void Setimage(Dialogue currentDialogue){
		if(currentDialogue.picture1!=""){
			if(!imagepool.ContainsKey(currentDialogue.picture1)){
				imagepool[currentDialogue.picture1]=Resources.Load<Sprite>(Path.Combine("Charactor/",currentDialogue.picture1));
			}
			char1.sprite=imagepool[currentDialogue.picture1];
			if(currentDialogue.effect1!=""){
				if(currentDialogue.effect1=="暗"){
					char1.color=Color.gray;
				}
				else if(currentDialogue.effect1=="震"){
					char1.gameObject.transform.DOShakePosition(0.5f,new Vector2(0,30),randomness:0);
				}
			}
			else{
				char1.color=Color.white;
			}
		}
		else{
			char1.color=Color.clear;
		}
		if(currentDialogue.picture2!=""){
			if(!imagepool.ContainsKey(currentDialogue.picture2)){
				imagepool[currentDialogue.picture2]=Resources.Load<Sprite>(Path.Combine("Charactor/",currentDialogue.picture2));
			}
			char2.sprite=imagepool[currentDialogue.picture2];
			if(currentDialogue.effect2!=""){
				if(currentDialogue.effect2=="暗"){
					char2.color=Color.gray;
				}
				else if(currentDialogue.effect2=="震"){
					char2.gameObject.transform.DOShakePosition(0.5f,new Vector2(0,30),randomness:0);
				}
			}
			else{
				char2.color=Color.white;
			}
		}
		else{
			char2.color=Color.clear;
		}
		if(currentDialogue.picture3!=""){
			if(!imagepool.ContainsKey(currentDialogue.picture3)){
				imagepool[currentDialogue.picture3]=Resources.Load<Sprite>(Path.Combine("Charactor/",currentDialogue.picture3));
			}
			char3.sprite=imagepool[currentDialogue.picture3];
			if(currentDialogue.effect3!=""){
				if(currentDialogue.effect3=="暗"){
					char3.color=Color.gray;
				}
				else if(currentDialogue.effect3=="震"){
					char3.gameObject.transform.DOShakePosition(0.5f,new Vector2(0,30),randomness:0);
				}
			}
			else{
				char3.color=Color.white;
			}
		}
		else{
			char3.color=Color.clear;
		}
		//震動 陰影(對話角色圖片設亮  其它設暗)
	}

	void EndDialogue ()
	{
		Dialogbox.SetActive(false);
		char1.transform.gameObject.SetActive(false);
		char2.transform.gameObject.SetActive(false);
		char3.transform.gameObject.SetActive(false);
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
			temp.picture1="papa";
			file.WriteLine(JsonUtility.ToJson(temp));
			}
		}
	}
}
