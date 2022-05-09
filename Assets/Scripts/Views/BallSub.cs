using UnityEngine;

public class BallSub : SubElement<BounceController>
{
    private Collider _collider;
    private Rigidbody _rigidbody;
    private bool _checkForCollision = true;

    protected override void Awake()
    {
        base.Awake();

        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();

        App.OnGameNotificationSent += HandleGameNotification;
    }

    private void HandleGameNotification(string notificationString, Object[] payload)
    {
        if (notificationString == GameNotification._Win)
        {
            HandleGameWin();
        }
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
            Controller.OnBallHitToGround();
    }
}