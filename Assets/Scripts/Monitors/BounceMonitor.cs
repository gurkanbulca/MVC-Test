using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

public class BounceMonitor : SubElement<BounceController>
{
    [SerializeField, ReadOnly] private int bounces;

    private void Start()
    {
        bounces = Controller.Model.bounces;
        App.OnBounceNotificationSent += HandleBounceNotification;
    }

    private void HandleBounceNotification(string notificationString, Object[] payload)
    {
        if (notificationString == BounceNotification._BallHitGround)
            bounces = ((BounceModel) payload[0]).bounces;
    }

    [Button]
    private void AddBounce()
    {
        Controller.OnBallHitToGround();
    }
}
