using UnityEngine;

public class Controll : MonoBehaviour
{
    public Transform player;
    [SerializeField]
    private float speed = 15f;
    void OnMouseDrag()
    {
        if (!Player.lose)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.x = mousePos.x > 2.5f ? 2.5f : mousePos.x;
            mousePos.x = mousePos.x < -2.5f ? -2.5f : mousePos.x;
            player.position = Vector2.MoveTowards(player.position, new Vector2(mousePos.x, player.position.y), speed * Time.deltaTime);
        }
        
    }
}
