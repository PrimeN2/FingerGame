using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    public void OnPlayHandler()
    {
        SceneManager.LoadScene("main");
    }
    public void OnExitHandler()
    {
        Application.Quit();
    }
    public void OnMenuHandler()
    {
        SceneManager.LoadScene("Menu");
    }
}
