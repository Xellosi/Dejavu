using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour {

    public static Stack<string> LastSceneStack = new Stack<string>();

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
	public void ChangeToScene(string SceneName)
    {
        string lastSceneName = SceneManager.GetActiveScene().name;
        LastSceneStack.Push(lastSceneName);
        SceneManager.LoadSceneAsync(SceneName);
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
