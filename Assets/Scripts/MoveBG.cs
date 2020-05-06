using UnityEngine;

public class MoveBG : MonoBehaviour
{
    [SerializeField]
    private float fallSpeed = 10;
    public static bool sp = true;

    void Update()
    {
        if (transform.position.y < -15)
        {
            sp = true;
            Destroy(gameObject);
        }
        transform.position -= new Vector3(0, fallSpeed * Time.deltaTime, 0);
    }
}
