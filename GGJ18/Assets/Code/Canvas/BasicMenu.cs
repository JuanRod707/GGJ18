using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicMenu : MonoBehaviour
{
    public void NavigateToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
