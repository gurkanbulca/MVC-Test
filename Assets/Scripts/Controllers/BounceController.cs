using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceController : Element
{
    public BounceModel Model { get; private set; }

    private void Awake()
    {
        Model = ScriptableObject.CreateInstance<BounceModel>();
    }

    public void OnBallHitToGround()
    {
        Model.bounces++;
        App.Notify(BounceNotification._BallHitGround,Model);

        Debug.Log("OnBallHitToGround: "+Model.bounces);
    }
}