using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class BounceController : ElementOf<Application>
{
    public BounceModel Model { get; private set; }
    public event Action OnGameWin;
    public event Action<BounceModel> OnBallHitToGround;

    private void Awake()
    {
        Model = new BounceModel();
        Master.OnGameNotificationSent += HandleGameNotificationSent;
        Master.OnBounceNotificationSent += HandleBounceNotificationSent;
    }

    private void OnDestroy()
    {
        Master.OnGameNotificationSent -= HandleGameNotificationSent;
        Master.OnBounceNotificationSent -= HandleBounceNotificationSent;
    }

    private void HandleBounceNotificationSent(string notificationString, Object[] payload)
    {
        if (notificationString == BounceNotification._BallHitGround)
        {
            OnBallHitToGround?.Invoke((BounceModel) payload[0]);
        }
    }

    private void HandleGameNotificationSent(string notificationString, Object[] payload)
    {
        if (notificationString == GameNotification._Win)
        {
            OnGameWin?.Invoke();
        }
    }

    public void IncreaseBounces()
    {
        Model.Bounces++;
        Master.Notify(BounceNotification._BallHitGround, Model);
        Debug.Log("Bounces: " + Model.Bounces);
    }
}