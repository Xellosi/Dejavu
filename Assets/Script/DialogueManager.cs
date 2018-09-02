using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using DG.Tweening;
public class DialogueManager : MonoBehaviour
{
	public static string PrefabPath = "Prefab/DialogueCanvas";
	public const string SavePath = "Resources/Dialogue/";
    public const string fileExtension = ".txt";

	public Text nameText,dialogueText; //角色名稱Text, 對話Text
    public GameObject Dialogbox,ContinueButton; //對話框, 繼續鍵
    public Image char1, char2, CG;//角色圖



	private Queue<Dialogue> _Dialogue = new Queue<Dialogue>();
    private Dictionary<string, Sprite> imagepool = new Dictionary<string, Sprite>();
	private Action Callback;

	private static DialogueManager _instance = null;


	private DialogueManager () {}
    // Use this for initialization
    public static DialogueManager Instance{
		get{
			if (_instance == null){
				GameObject manager = (GameObject)Instantiate(Resources.Load(PrefabPath));
				_instance = manager.GetComponent<DialogueManager>();
				_instance.GetComponent<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
				DontDestroyOnLoad(manager);
			}
			return _instance;
		}
    }
 
    public void StartDialogue(string dialoguename)
    {
		_instance.transform.gameObject.SetActive(true);
        _Dialogue.Clear();
        string line;
        string fileFullPath = Path.Combine(Application.dataPath, SavePath);
        fileFullPath = Path.Combine(fileFullPath, dialoguename + fileExtension);
        if ((Directory.Exists(fileFullPath))) {
            Debug.Log("無此對話");
            return;
        }
        System.IO.StreamReader file = new System.IO.StreamReader(fileFullPath);
        while ((line = file.ReadLine()) != null) {
            if (line[0] == '#') {
                continue;
            }
            try {
                _Dialogue.Enqueue(JsonUtility.FromJson<Dialogue>(line));
            }
            catch (Exception e) {
                Debug.Log(e.Message);
                return;
            }
        }
        file.Close();
        ContinueButton.GetComponentInChildren<Text>().text = "Continue>>";
        DisplayNextSentence();
    }
	//https://stackoverflow.com/questions/27547122/c-sharp-override-with-different-parameters
	//https://stackoverflow.com/questions/5414515/c-sharp-passing-a-method-as-a-parameter-to-another-method
	public void StartDialogue(string dialoguename, Action _callback)
	{
		_instance.transform.gameObject.SetActive(true);
		_Dialogue.Clear();
		string line;
		string fileFullPath = Path.Combine(Application.dataPath, SavePath);
		fileFullPath = Path.Combine(fileFullPath, dialoguename + fileExtension);
		if ((Directory.Exists(fileFullPath))) {
			Debug.Log("無此對話");
			return;
		}
		System.IO.StreamReader file = new System.IO.StreamReader(fileFullPath);
		while ((line = file.ReadLine()) != null) {
			if (line[0] == '#') {
				continue;
			}
			try {
				_Dialogue.Enqueue(JsonUtility.FromJson<Dialogue>(line));
			}
			catch (Exception e) {
				Debug.Log(e.Message);
				return;
			}
		}
		Callback = _callback;
		file.Close();
		ContinueButton.GetComponentInChildren<Text>().text = "Continue>>";
		DisplayNextSentence();
	}


    public void DisplayNextSentence()
    {
        if (_Dialogue.Count == 0) {
            EndDialogue();
            return;
        }

        else if (_Dialogue.Count == 1) {
            ContinueButton.GetComponentInChildren<Text>().text = "End>>";
        }
        Dialogue currentDialogue = _Dialogue.Dequeue();
        nameText.text = currentDialogue.name;
        string sentence = currentDialogue.sentence;
        SetImage(currentDialogue);
        StopAllCoroutines();
        ContinueButton.SetActive(false);
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return null;
        }
        ContinueButton.SetActive(true);
	}
		
	void SetImage(Dialogue currentDialogue){
		//角色1
		if(currentDialogue.picture1!=""){
			char1.transform.gameObject.SetActive(true);
			if(!imagepool.ContainsKey(currentDialogue.picture1)){
				imagepool[currentDialogue.picture1]=Resources.Load<Sprite>(Path.Combine("Character/",currentDialogue.picture1));
			}
			char1.sprite=imagepool[currentDialogue.picture1];
			if(currentDialogue.effect1!=""){
				if(currentDialogue.effect1=="暗"){
					char1.color=Color.gray;
				}
				else if(currentDialogue.effect1=="震"){
					char1.gameObject.transform.DOShakePosition(1f,new Vector2(0,200),randomness:0);
				}
			}
			else{
				char1.color=Color.white;
			}
		}else{
			char1.transform.gameObject.SetActive(false);
		}
		//角色2
		if(currentDialogue.picture2!=""){
			char2.transform.gameObject.SetActive(true);
			if(!imagepool.ContainsKey(currentDialogue.picture2)){
				imagepool[currentDialogue.picture2]=Resources.Load<Sprite>(Path.Combine("Character/",currentDialogue.picture2));
			}
			char2.sprite=imagepool[currentDialogue.picture2];
			if(currentDialogue.effect2!=""){
				if(currentDialogue.effect2=="暗"){
					char2.color=Color.gray;
				}
				else if(currentDialogue.effect2=="震"){
					char2.gameObject.transform.DOShakePosition(1f,new Vector2(0,200),randomness:0);
				}
			}
			else{
				char2.color=Color.white;
			}
		}
		else{
			char2.transform.gameObject.SetActive(false);
		}
		//CG
		if (currentDialogue.CG != "") {
			CG.transform.gameObject.SetActive(true);
			if(!imagepool.ContainsKey(currentDialogue.CG)){
				imagepool[currentDialogue.CG]=Resources.Load<Sprite>(Path.Combine("Character/",currentDialogue.CG));
			}
			CG.sprite=imagepool[currentDialogue.CG];
		}
		else{
			CG.transform.gameObject.SetActive(false);
		}
	}

	void EndDialogue ()
	{
		this.transform.gameObject.SetActive(false);
		if (Callback != null)
			Callback.Invoke();
		this.Callback = null;
	}

	//生成測試用對話
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
