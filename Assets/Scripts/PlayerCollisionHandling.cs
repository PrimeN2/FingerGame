using System;
using UnityEngine;

public class PlayerCollisionHandling : ILetVisitor
{
    public static event Action<GameObject, Collider2D, Let> OnLetTaken;

    private Player player = GameObject.Find("Finger_l").GetComponent<Player>();

    public void Visit(Point typeOfLet, GameObject currentObject, Collider2D currentCollider)
    {
        OnLetTaken?.Invoke(currentObject, currentCollider, typeOfLet);
        TryChangePoint(1); 
    }
    public void Visit(Enemy typeOfLet, GameObject currentObject, Collider2D currentCollider)
    {
        Player.Lose = true;
        player.Restart.SetActive(true);
        player.Menu.SetActive(true);
    }
    public void Visit(Debuff typeOfLet, GameObject currentObject, Collider2D currentCollider)
    {
        OnLetTaken?.Invoke(currentObject, currentCollider, typeOfLet);
        TryChangePoint(-1);
    }
    private void TryChangePoint(int sign = 1)
    {
        if (Player.Points < 0) throw new ArgumentOutOfRangeException("CountPointsOutOfRange");
        else
        {
            Player.Points += 1 * sign;
            player.Point.text = "Points:" + Player.Points.ToString();
        }
    }
}