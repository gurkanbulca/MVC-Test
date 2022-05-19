using System;
using UnityEngine;

public class BallView : ElementOf<BounceController>
{
    private Collider _collider;
    private Rigidbody _rigidbody;
    private bool _checkForCollision = true;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();

        Master.OnGameWin += HandleGameWin;
    }

    private void OnDestroy()
    {
        Master.OnGameWin -= HandleGameWin;
    }

    private void HandleGameWin()
    {
        _collider.material = null;
        _rigidbody.velocity = Vector3.zero;
        _checkForCollision = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_checkForCollision)
            Master.IncreaseBounces();
    }
}