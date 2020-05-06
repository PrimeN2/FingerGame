using System.Collections;
using UnityEngine;

public class SpawnLet : MonoBehaviour
{
    public GameObject[] let;
    public GameObject point;
    public GameObject BG;

    private void SpawnObject(GameObject obj) => Instantiate(obj, 
                                                            new Vector2(Random.Range(-2.5f, 2.5f), 5.6f), 
                                                            Quaternion.identity);
    void Start()
    {
        StartCoroutine(Spawn());
    }

    private void Update()
    {
        if(MoveBG.sp)
        {
            Instantiate(BG, new Vector3(0, 15, 10), Quaternion.identity);
            MoveBG.sp = false;
        }
    }
    IEnumerator Spawn()
    {
        while (!Player.lose)
        {
            int f = Random.Range(0, 4);
            if (f == 0)
                SpawnObject(point);
            else
                SpawnObject(let[0]);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
