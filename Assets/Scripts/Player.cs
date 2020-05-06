using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject restart;
    public GameObject menu;
    public static bool lose = false;
    public static int points = 0;
    public Text point;

    private void Awake()
    {
        lose = false;
        points = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            lose = true;
            restart.SetActive(true);
            menu.SetActive(true);
        }
        if (other.gameObject.tag == "Point")
        {
            points++;
            Destroy(other.gameObject);
            point.text = "Points:" + points.ToString();
            // Мой первый, и скорее всего последний комент в этом коде(
}
    }
}
