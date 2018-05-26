using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public static Stack<string> LastSceneStack = new Stack<string>();

    public void ChangeToScene(string SceneName)
    {
        string lastSceneName = SceneManager.GetActiveScene().name;
        LastSceneStack.Push(lastSceneName);
        SceneManager.LoadScene(SceneName);
        // SceneManager.LoadSceneAsync(SceneName);
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
