using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class Application : MonoBehaviour
{
    public event Action<string, Object[]> OnGameNotificationSent;
    public event Action<string, Object[]> OnBounceNotificationSent;

    public void Notify(string notificationString, params Object[] data)
    {
        if (GameNotification.Contains(notificationString))
        {
            OnGameNotificationSent?.Invoke(notificationString, data);
        }
        else if (BounceNotification.Contains(notificationString))
        {
            OnBounceNotificationSent?.Invoke(notificationString, data);
        }
    }
}