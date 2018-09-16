using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour {

    public static Stack<string> LastSceneStack = new Stack<string>();
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
	public void ChangeToScene(string SceneName)
    {
        string lastSceneName = SceneManager.GetActiveScene().name;
        LastSceneStack.Push(lastSceneName);
        SceneManager.LoadSceneAsync(SceneName);
        if(gameObject.name=="right to left button" & PlayerDataManager.instance.data.Level1_Progress["Potion"]=="背包" & SceneName=="1-1Leftside"){
            FadeController.Instance.FadeIn(1.0f,()=>{
                DialogueManager.Instance.StartDialogue("Level1/給公主藥水",()=>{
                    Destroy(GameObject.Find("Potion"));
                    SceneManager.LoadScene(4);
                    FadeController.Instance.FadeIn(1.0f,()=>{
                        DialogueManager.Instance.StartDialogue("Level1/新聲音");
                    });
                });
            });
        }
    }

    public void ReturnToLastScene()
    {
        if (LastSceneStack.Count > 0)
        {
            string goToScene = LastSceneStack.Pop();
            SceneManager.LoadScene(goToScene);
        }
    }

}
