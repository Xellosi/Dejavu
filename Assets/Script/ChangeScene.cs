using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public static Stack<string> LastSceneStack = new Stack<string>();

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        FadeController.Instance.FadeIn(1f);
    }

    public void ChangeToScene(string SceneName)
    {
        string lastSceneName = SceneManager.GetActiveScene().name;
        LastSceneStack.Push(lastSceneName);
        SceneManager.LoadScene(SceneName);
        SceneManager.LoadSceneAsync(SceneName);
        FadeController.Instance.FadeIn(1f);
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
