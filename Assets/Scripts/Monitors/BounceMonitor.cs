using Sirenix.OdinInspector;
using UnityEngine;

public class BounceMonitor : ElementOf<BounceController>
{
    [SerializeField, ReadOnly] private int bounces;

    private void Start()
    {
        bounces = Master.Model.Bounces;
        Master.OnBallHitToGround += HandleBallHitToGround;
    }

    private void OnDestroy()
    {
        Master.OnBallHitToGround -= HandleBallHitToGround;
    }

    private void HandleBallHitToGround(BounceModel model)
    {
        bounces = model.Bounces;
    }

    [Button]
    private void AddBounce()
    {
        Master.IncreaseBounces();
    }
}