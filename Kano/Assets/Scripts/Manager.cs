using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Manager : MonoBehaviour
{
    public List<Questions> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject narwhals;
    [SerializeField] private Timer _timer;
    [SerializeField] private CountdownView _countdownView;

    private void Start()
    {
        generateQuestion();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void correct()
    { 
        QnA[currentQuestion].CurrentNarwhal.SetActive(false);
        generateQuestion();
    }
    
    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Answers>().isCorrect = false;
            options[i] = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<Answers>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            narwhals = QnA[currentQuestion].CurrentNarwhal;
            QnA[currentQuestion].CurrentNarwhal.SetActive(true);
            SetAnswers();
        }
        else
        {
            _timer.GameOver();
        }
    }
}