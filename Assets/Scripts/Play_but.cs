using UnityEngine.SceneManagement;
using UnityEngine;

public class Play_but : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene("main");
    }
}
