using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject textDisplay;
    public int secondsLeft = 30;
    public bool takingAway = false;

    public GameObject Panel;
    public GameObject GOPanel;

    [SerializeField] private ScoreView _highScore;
    [SerializeField] private CountdownView _countdownView;

    void Start()
    {
        GOPanel.SetActive(false);
        textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
    }

    void Update()
    {
        if (_countdownView.IsCountdownComplete())
        {
            if (takingAway == false && secondsLeft > 0)
            {
                StartCoroutine(TimerTake());
            }
        }
    }

    public void GameOver()
    {
        if (secondsLeft == 0)
        {
            Panel.SetActive(false);
            GOPanel.SetActive(true);
            _highScore.HighScore();
        }
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;

        if (secondsLeft < 10)
        {
            textDisplay.GetComponent<Text>().text = "00:0" + secondsLeft;
        }
        else
        {
            textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
        }
        takingAway = false;
        GameOver();
    }

}
