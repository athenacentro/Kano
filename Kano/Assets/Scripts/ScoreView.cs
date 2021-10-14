using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Text _scoreNum;
    [SerializeField] private Text _highScore;
    private int _scoreValue = 0;
    private float _timer = 0.0f;
    public int seconds;

    [SerializeField] private CountdownView _countdownView;

    private int _highScoreValue = 0;
    private const string HIGH_SCORE = "HIGH_SCORE";

    private void Start()
    {
        _highScoreValue = SaveLoadManager.LoadData(HIGH_SCORE, 0);
        _highScore.text = _highScoreValue.ToString();
    }

    void Update()
    {
        if (_countdownView.IsCountdownComplete())
        {
            _timer += Time.deltaTime;
            seconds = (int)(_timer % 60);
        }
    }

    public void HighScore()
    {
        if (_scoreValue > _highScoreValue)
        {
            _highScore.text = _highScoreValue.ToString();
            SaveLoadManager.SaveData(HIGH_SCORE, _scoreValue);
        }
    }   

    public void AddScore()
    {
        if (_timer > 0f && _timer < 2f)
        {
            _scoreValue = _scoreValue + 450;
            _scoreNum.text = _scoreValue.ToString();
            _timer = 0.0f;
        }
        else if (_timer >= 2f && _timer <= 5f)
        {
            _scoreValue = _scoreValue + 350;
            _scoreNum.text = _scoreValue.ToString();
            _timer = 0.0f;
        }
        else if (_timer > 5f)
        {
            _scoreValue = _scoreValue + 200;
            _scoreNum.text = _scoreValue.ToString();
            _timer = 0.0f;
        }
        HighScore();
    }

    public void MinusScore()
    {
        if (_timer > 0f && _timer < 2f)
        {
            _scoreValue = _scoreValue - 200;  
            _scoreNum.text = _scoreValue.ToString();
            _timer = 0.0f;
        }
        else if (_timer >= 2f && _timer <= 5f)
        {
            _scoreValue = _scoreValue - 350;
            _scoreNum.text = _scoreValue.ToString();
            _timer = 0.0f;
        }
        else if (_timer > 5f)
        {
            _scoreValue = _scoreValue - 400;
            _scoreNum.text = _scoreValue.ToString();
            _timer = 0.0f;
        }
        HighScore();
    }
}
