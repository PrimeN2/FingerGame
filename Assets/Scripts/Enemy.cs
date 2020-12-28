using UnityEngine;

[CreateAssetMenu(menuName = "Let/Enemy", fileName = "new Enemy")]
public class Enemy : Let
{
    public override void Accept(ILetVisitor visiter, GameObject currentObject, Collider2D currentCollider)
    {
        visiter.Visit(this, currentObject, currentCollider);
    }
}