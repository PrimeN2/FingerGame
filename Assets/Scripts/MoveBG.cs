using UnityEngine;

public class MoveBG : MonoBehaviour
{
    [SerializeField] private MeshRenderer BGMesh;

    [SerializeField] private float BGSpeed = 0.76f;

    private Vector2 BGOffset;

    private void Awake()
    {
        if (BGMesh) BGOffset = BGMesh.sharedMaterial.GetTextureOffset("_MainTex");
        BGSpeed = 0.76f;
    }
    private void Move(MeshRenderer mesh, Vector2 savedOffset, float speed)
    {
        Vector2 offset = Vector2.zero;
        float tmp = Mathf.Repeat(Time.time * speed, 1);
        offset = new Vector2(savedOffset.x, tmp);
        mesh.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    private void Update()
    {
        if (!Player.Lose) Move(BGMesh, BGOffset, BGSpeed);
    }

    private void OnDisable()
    {
        if (BGMesh) BGMesh.sharedMaterial.SetTextureOffset("_MainTex", BGOffset);
    }
}