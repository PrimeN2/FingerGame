using UnityEngine;

public class MoveBG : MonoBehaviour
{
    [SerializeField] private MeshRenderer BGMesh;

    public static float SpeedBGScroll { get => speedOfBG; set => speedOfBG = value; }
    [SerializeField] private static float speedOfBG = 0.755f;
    public static float TimeAccelerationFactor { get => timeAccelerationFactor; set => timeAccelerationFactor = value; }
    private static float timeAccelerationFactor = 0.01275f;
    private float time = 0;

    private Vector2 BGOffset;

    private void Awake()
    {
        if (BGMesh) BGOffset = BGMesh.sharedMaterial.GetTextureOffset("_MainTex");
        speedOfBG = 0.755f;
    }
    private void Move(MeshRenderer mesh, Vector2 savedOffset, float speed)
    {
        Vector2 offset = Vector2.zero;
        float tmp = Mathf.Repeat(time * speed, 1);
        time += timeAccelerationFactor;
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