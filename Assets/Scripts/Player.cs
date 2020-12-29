using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static int Points { get; set; }
    public static bool Lose { get; set; }

    [SerializeField] private GameObject restart;
    public GameObject Restart { get => restart; }

    [SerializeField] private GameObject menu;
    public GameObject Menu { get => menu; }

    [SerializeField] private Text point;
    public Text Point { get => point; }

    private void Awake()
    {
        Points = 0;
        Lose = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Let currentTypeOfLet = other.gameObject.GetComponent<LetKeeper>().CurrentTypeOfLet;
        currentTypeOfLet.Accept(new PlayerCollisionHandling(), other.gameObject, other);
    }
}
