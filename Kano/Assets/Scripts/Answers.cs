using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answers : MonoBehaviour
{
    public bool isCorrect;
    public GameObject correct;
    public GameObject wrong;

    [SerializeField] private Manager _manager;

    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private CountdownView _countdownView;

    IEnumerator TransitionToCorrect()
    {
        correct.SetActive(true);

        yield return new WaitForSeconds(1f);

        correct.SetActive(false);
    }

    IEnumerator TransitionToWrong()
    {
        wrong.SetActive(true);

        yield return new WaitForSeconds(1f);

        wrong.SetActive(false);
    }

    public void Correct()
    {
        if (_countdownView.IsCountdownComplete())
        {
            if (isCorrect)
            {
                _manager.correct();
                _scoreView.AddScore();
                StartCoroutine(TransitionToCorrect());
            }
            else
            {
                _manager.correct();
                _scoreView.MinusScore();
                StartCoroutine(TransitionToWrong());
            }
        }
 
    }
}

