using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static int Points { get; set; }
    public static bool Lose { get; set; }

    public GameObject Restart { get => restart; }
    [SerializeField] private GameObject restart;

    public GameObject Menu { get => menu; }
    [SerializeField] private GameObject menu;

    public Text Point { get => point; }
    [SerializeField] private Text point;

    private void Awake()
    {
        Points = 0;
        Lose = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Let currentLet = other.gameObject.GetComponent<LetKeeper>().CurrentLet;
        currentLet.Accept(new PlayerCollisionHandling(), other.gameObject, other);
    }
}
