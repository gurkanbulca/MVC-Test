using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour, IController
{
    public void OnNotification(Object sender, string notificationString, params Object[] data)
    {
        throw new System.NotImplementedException();
    }
}
