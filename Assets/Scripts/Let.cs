using UnityEngine;

public abstract class Let : ScriptableObject
{
    public abstract void Accept(ILetVisitor visiter, GameObject currentObject, Collider2D currentCollider);

    public enum Colliders
    {
        Box,
        Capsule,
        Circle
    }

    [SerializeField] private Sprite mainSprite;
    public Sprite MainSprite { get => mainSprite; protected set => mainSprite = value; }

    [SerializeField] private Colliders typeCollider;
    public Colliders TypeCollider { get => typeCollider; protected set => typeCollider = value; }

    [SerializeField] private Vector3 scale;
    public Vector3 Scale { get => scale; protected set => scale = value; }

    [SerializeField] private Vector2 scaleCollider;
    public Vector2 ScaleCollider { get => scaleCollider; protected set => scaleCollider = value; }

    [SerializeField] private Vector2 offset;
    public Vector2 Offset { get => offset; protected set => offset = value; }

    [SerializeField] private float radius;
    public float Radius { get => radius; protected set => radius = value; }
}