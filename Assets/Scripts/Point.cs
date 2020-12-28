using UnityEngine;

[CreateAssetMenu(menuName = "Let/Point", fileName = "new Point")]
public class Point : Let
{
    public override void Accept(ILetVisitor visiter, GameObject currentObject, Collider2D currentCollider)
    {
        visiter.Visit(this, currentObject, currentCollider);
    }
}
