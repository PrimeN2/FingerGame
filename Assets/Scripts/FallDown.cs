using UnityEngine;
using System;

[RequireComponent(typeof(Collider2D))]
public class FallDown : MonoBehaviour
{
    public static event Action<GameObject, Collider2D, Let> OnEnemyOverFliew;
    public Let CurrentTypeOfLet { get => currentTypeOfLet; }
    public static float FallSpeed { get => fallSpeed; set => fallSpeed = value; }
    private static float fallSpeed = 9.5f;
    private Let currentTypeOfLet;
    private Collider2D currentCollider;

    public void Init(Let _let)
    {
        currentTypeOfLet = _let;
        GetComponent<SpriteRenderer>().sprite = currentTypeOfLet.MainSprite;
        switch (_let.TypeCollider)
        {
            case Let.Colliders.Box:
                currentCollider = GetComponent<BoxCollider2D>();
                BoxCollider2D boxCollider = (BoxCollider2D)currentCollider;
                boxCollider.size = _let.ScaleCollider;
                boxCollider.enabled = true;
                break;
            case Let.Colliders.Capsule:
                currentCollider = GetComponent<CapsuleCollider2D>();
                CapsuleCollider2D capsuleCollider = (CapsuleCollider2D)currentCollider;
                capsuleCollider.size = _let.ScaleCollider;
                capsuleCollider.enabled = true;
                break;
            case Let.Colliders.Circle:
                currentCollider = GetComponent<CircleCollider2D>();
                CircleCollider2D circleCollider = (CircleCollider2D)currentCollider;
                circleCollider.radius = _let.Radius;
                circleCollider.enabled = true;
                break;
        }
        currentCollider.offset = _let.Offset;
        transform.localScale = _let.Scale;
    }
    private void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        if (transform.position.y < -8) OnEnemyOverFliew?.Invoke(gameObject, currentCollider, currentTypeOfLet);
    }
}
