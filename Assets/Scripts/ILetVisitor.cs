using UnityEngine;

public interface ILetVisitor
{
    void Visit(Point typeOfLet, GameObject currentObject, Collider2D currentCollider);
    void Visit(Enemy typeOfLet, GameObject currentObject, Collider2D currentCollider);
    void Visit(Debuff typeOfLet, GameObject currentObject, Collider2D currentCollider);
}
