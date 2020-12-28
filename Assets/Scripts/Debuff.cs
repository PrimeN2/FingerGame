using UnityEngine;

[CreateAssetMenu(menuName = "Let/Debuff", fileName = "new Debuff")]
public class Debuff : Let
{
    public override void Accept(ILetVisitor visiter, GameObject currentObject, Collider2D currentCollider)
    {
        visiter.Visit(this, currentObject, currentCollider);
    }
}
