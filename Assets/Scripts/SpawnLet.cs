using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLet : MonoBehaviour
{
    [SerializeField] private GameObject letPrefab;
    [Tooltip("Puddle всегда в последнем элементе")]
    [SerializeField] private List<Let> letSetting;
    [SerializeField] private int poolCount;

    public static Dictionary<GameObject, LetKeeper> Lets = new Dictionary<GameObject, LetKeeper>();
    private Queue<GameObject> currentLet;

    public static float DeleyOfRespawn = 1f;

    private void Awake()
    {
        LetKeeper.FallSpeed = 9.5f;
    }
    private void Start()
    {
        Lets = new Dictionary<GameObject, LetKeeper>();
        currentLet = new Queue<GameObject>();

        for (int i = 0; i < poolCount; ++i)
        {
            var prefab = Instantiate(letPrefab);
            prefab.transform.SetParent(transform, true);
            var script = prefab.GetComponent<LetKeeper>();
            prefab.SetActive(false);
            Lets.Add(prefab, script);
            currentLet.Enqueue(prefab);
        }
        StartCoroutine(Spawn());
    }
    private void ReturnLet(Let _currentTypeOfLet, Collider2D _colliderType, GameObject _let)
    {
        _colliderType.enabled = false;
        _let.transform.position = transform.position;
        _let.SetActive(false);
        currentLet.Enqueue(_let);
    }
    IEnumerator Spawn()
    { 
        while (!Player.Lose)
        {
            if(currentLet.Count > 0)
            {
                var let = currentLet.Dequeue();
                var script = Lets[let];
                let.SetActive(true);

                int rand = Random.Range(0, letSetting.Count);
                
                if (!CanSpawnNewPuddle()) rand = Random.Range(0, letSetting.Count - 1);
                script.Init(letSetting[rand]);

                float xPosition = Random.Range(-ControllPlayer.Border, ControllPlayer.Border);
                let.transform.position = new Vector2(xPosition, transform.position.y);
            }
            yield return new WaitForSeconds(DeleyOfRespawn);
        }
    }
    private bool CanSpawnNewPuddle()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.GetComponent<LetKeeper>().CurrentTypeOfLet is Debuff)
            {
                return false;
            }
        }
        return true;
    }
    private void OnEnable()
    {
        LetKeeper.OnEnemyOverFliew += ReturnLet;
        PlayerCollisionHandling.OnLetTaken += ReturnLet;
    }
    private void OnDisable()
    {
        LetKeeper.OnEnemyOverFliew -= ReturnLet;
        PlayerCollisionHandling.OnLetTaken -= ReturnLet;
    }
}

