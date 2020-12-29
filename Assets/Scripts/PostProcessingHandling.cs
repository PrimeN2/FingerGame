using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingHandling : MonoBehaviour
{
    [SerializeField] private PostProcessVolume postProcessing;

    private Vignette vignette;

    private void Awake()
    {
        postProcessing.profile.TryGetSettings(out vignette);
    }
    public IEnumerator IncreaseVignetting()
    {
        for(int i = 0; i < 10; i++)
        {
            vignette.intensity.value += 0.009f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
