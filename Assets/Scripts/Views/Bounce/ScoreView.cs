using TMPro;
using UnityEngine;

public class ScoreView : ElementOf<BounceController>
{
    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        Master.OnBallHitToGround += SetScoreText;
        SetScoreText(Master.Model);
    }

    private void OnDestroy()
    {
        Master.OnBallHitToGround -= SetScoreText;
    }

    private void SetScoreText(BounceModel model)
    {
        scoreText.text = model.Bounces.ToString();
    }
}