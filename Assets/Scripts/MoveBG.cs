using UnityEngine;

public class MoveBG : MonoBehaviour
{
    public static float TimeAccelerationFactor { get; set; } = 1f;

    [SerializeField] private MeshRenderer BGMesh;
    [SerializeField] private float speedOfBG = 0.94f;
    private float TimeT = 0f;
    private Vector2 BGOffset;

    private void Awake()
    {
        if (BGMesh) BGOffset = BGMesh.sharedMaterial.GetTextureOffset("_MainTex");
        TimeAccelerationFactor = 1f;
        speedOfBG = 0.94f;
        TimeT = 0f;
}
    private void Move(MeshRenderer mesh, Vector2 savedOffset, float speed)
    {
        Vector2 offset = Vector2.zero;
        TimeT += TimeAccelerationFactor * Time.deltaTime;
        float tmp = Mathf.Repeat(TimeT * speed, 1);
        
        offset = new Vector2(savedOffset.x, tmp);
        mesh.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
    private void Update()
    {
        if (!Player.Lose) Move(BGMesh, BGOffset, speedOfBG);
    }

    private void OnDisable()
    {
        if (BGMesh) BGMesh.sharedMaterial.SetTextureOffset("_MainTex", BGOffset);
    }
}