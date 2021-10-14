using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountdownView : MonoBehaviour
{
    [SerializeField] private Text _countdownText;
    private bool _isCountdownComplete;

    private void Start()
    {
        StartCoroutine(CountdownRoutine());
    }

    private IEnumerator CountdownRoutine()
    {
        var countdownTimer = 3;

        while (countdownTimer >= 0)
        {
            yield return new WaitForSeconds(1);
            _countdownText.text = countdownTimer.ToString();
            countdownTimer--;
        }
        _countdownText.text = "";
        _isCountdownComplete = true;
    }

    public bool IsCountdownComplete()
    {
        return _isCountdownComplete;

    }
}

