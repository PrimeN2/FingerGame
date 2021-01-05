using UnityEngine;

public class ControllPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed = 30f;

    private static float border = 0;
    public static float Border
    {
        get
        {
            if(border == 0)
            {
                var cam = Camera.main;
                border = cam.aspect * cam.orthographicSize;
            }
            return border - 0.3f;
        }
    }

    private void OnMouseDrag()
    {
        if (!Player.Lose)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.x = mousePos.x > Border - 0.1f ? Border - 0.1f : mousePos.x;
            mousePos.x = mousePos.x < -(Border + 0.1f) ? -(Border + 0.1f) : mousePos.x;
            player.position = Vector3.MoveTowards(player.position, new Vector3(mousePos.x, player.position.y, player.position.y), speed * Time.deltaTime);
        }
    }
}
