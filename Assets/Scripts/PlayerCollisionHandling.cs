using System;
using UnityEngine;

public class PlayerCollisionHandling : ILetVisitor
{
    public static event Action<Let, Collider2D, GameObject> OnLetTaken;
    public static event Action NewLevelHasBeenTaken;

    [SerializeField] private Player player = GameObject.Find("Finger_l").GetComponent<Player>();
    [SerializeField] private SpeedLevelHandler speedLevelHandler = GameObject.Find("Main Camera").GetComponent<SpeedLevelHandler>();

    public void Visit(Point typeOfLet, GameObject currentObject, Collider2D currentCollider)
    {
        OnLetTaken?.Invoke(typeOfLet, currentCollider, currentObject);
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
        OnLetTaken?.Invoke(typeOfLet, currentCollider, currentObject);
        NewLevelHasBeenTaken?.Invoke();
        TryChangePoint(-1);
    }
    private void TryChangePoint(int sign = 1)
    {
        if (Player.Points == 0 && sign == -1) throw new ArgumentOutOfRangeException("CountPointsOutOfRange");
        else
        {
            Player.Points += 1 * sign;
            player.Point.text = "Points:" + Player.Points.ToString();
            if (speedLevelHandler.CountOfPointForNextLevelSpeed + SpeedLevelHandler.CurrentCountPointOfNextLevelSpeed == Player.Points)
            {
                SpeedLevelHandler.CurrentCountPointOfNextLevelSpeed = Player.Points;
                NewLevelHasBeenTaken?.Invoke();
            }
        }
    }
}