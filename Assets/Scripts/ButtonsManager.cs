using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    public void OnMouseDown()
    {
        if (name == "Play") SceneManager.LoadScene("main");
        else if (name == "Restart") SceneManager.LoadScene("main");
        else if (name == "Exit") Application.Quit();
        else if (name == "Menu") SceneManager.LoadScene("Menu");
    }
}
