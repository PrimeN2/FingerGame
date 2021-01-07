using UnityEngine;

public class FrameRate : MonoBehaviour
{
    [SerializeField] private int _frameRate = 90;

    void Start()
    {
        QualitySettings.vSyncCount = 0;
    }

    void Update()
    {
        if (_frameRate != Application.targetFrameRate)
            Application.targetFrameRate = _frameRate;

    }
}


