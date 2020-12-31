using System;
using UnityEngine;

public class SpeedLevelHandler : MonoBehaviour
{
    [SerializeField] private PostProcessingHandling postProcessingHandling;
    public static int CurrentCountPointOfNextLevelSpeed { get; set; }
    public int CountOfPointForNextLevelSpeed { get => countOfPointForNextLevelSpeed; }
    [SerializeField] private int countOfPointForNextLevelSpeed = 1;

    [SerializeField] private int maxLevelSpeed = 5;
    private int currentLevelOfSpeed = 1;

    private void Awake()
    {
        currentLevelOfSpeed = 1;
        CurrentCountPointOfNextLevelSpeed = 0;
    }
    private void OnLevelTaked()
    {
        if(currentLevelOfSpeed <= maxLevelSpeed)
        {
            currentLevelOfSpeed++;
            LetKeeper.FallSpeed *= 1.1f;
            MoveBG.TimeAccelerationFactor *= 1.1f;
            StartCoroutine(postProcessingHandling.IncreaseVignetting());
        }
    }
    private void OnEnable()
    {
        PlayerCollisionHandling.NewLevelHasBeenTaken += OnLevelTaked;
    }
    private void OnDisable()
    {
        PlayerCollisionHandling.NewLevelHasBeenTaken -= OnLevelTaked;
    }
}
