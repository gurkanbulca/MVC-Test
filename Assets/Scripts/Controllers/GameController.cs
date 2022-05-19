using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class GameController : ElementOf<Application>
{
    private GameModel _model;

    [SerializeField] private int winCondition;

    private void Awake()
    {
        _model = new GameModel(winCondition);
        
        Master.OnBounceNotificationSent += HandleBounceNotification;
    }

    private void HandleBounceNotification(string notificationString, Object[] payload)
    {
        if (notificationString == BounceNotification._BallHitGround)
        {
            HandleBallHitToGround(payload);
        }
    }

    private void HandleBallHitToGround(Object[] payload)
    {
        var bounces = ((BounceModel) payload[0]).Bounces;
        var isWin = CheckForWinCondition(bounces);
        if (isWin)
            GameWin();
    }

    private void GameWin()
    {
        Master.Notify(GameNotification._Win);
    }

    private bool CheckForWinCondition(int bounces)
    {
        return bounces >= _model.WinCondition;
    }
}