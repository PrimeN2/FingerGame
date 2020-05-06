using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Menu");
    }
}
