using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class Application : MonoBehaviour
{
    [Serializable]
    private class ControllerDictionary:UnitySerializedDictionary<Type,IController>{}

    [SerializeField] private ControllerDictionary controllerDictionary;

    public void Notify(Object sender, string notificationString, params Object[] data)
    {
        if (GameNotification.Contains(notificationString))
        {
            controllerDictionary[typeof(GameController)].OnNotification(sender,notificationString,data);
        }
        else if (BounceNotification.Contains(notificationString))
        {
            controllerDictionary[typeof(BounceController)].OnNotification(sender,notificationString,data);
        }
    }
}

public interface IController
{
    public abstract void OnNotification(Object sender, string notificationString, params Object[] data);
}

public static class GameNotification
{
    public const string _Win = "game_win";
    public const string _Lose = "game_lose";
    public const string _Start = "game_start";

    public static bool Contains(string notificationString)
    {
        return notificationString == _Win
               || notificationString == _Lose
               || notificationString == _Start;
    }
}

public static class BounceNotification
{
    public static string BallHitGround = "ball_hit_ground";
    
    public static bool Contains(string notificationString)
    {
        return notificationString == BallHitGround;
    }
}
