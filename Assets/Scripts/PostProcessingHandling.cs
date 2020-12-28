using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingHandling : MonoBehaviour
{
    [SerializeField] private PostProcessVolume postProcessing;

    private Vignette vignette;

    private void Awake()
    {
        postProcessing.profile.TryGetSettings(out vignette);
    }
}
