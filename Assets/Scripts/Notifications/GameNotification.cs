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