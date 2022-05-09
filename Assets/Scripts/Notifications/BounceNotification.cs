public static class BounceNotification
{
    public const string _BallHitGround = "ball_hit_ground";

    public static bool Contains(string notificationString)
    {
        return notificationString == _BallHitGround;
    }
}