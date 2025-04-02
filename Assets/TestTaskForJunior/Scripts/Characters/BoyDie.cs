using Score;
using UnityEngine;

public class BoyDie : MonoBehaviour
{
    private ScoreView _scoreView;

    public void Init(ScoreView scoreView)
    {
        _scoreView = scoreView;
    }

    public void Perform()
    {
        gameObject.SetActive(false);
        _scoreView.Increase();
    }
}
