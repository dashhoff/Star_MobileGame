using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText;
    private float _time;
    private bool _isRunning;

    private void OnEnable()
    {
        EventController.OnVictory += StopTimer;
        EventController.OnDefeat += StopTimer;
    }

    private void OnDisable()
    {
        EventController.OnVictory -= StopTimer;
        EventController.OnDefeat -= StopTimer;
    }

    public void StartTimer()
    {
        _time = 0f;
        _isRunning = true;
    }

    private void Update()
    {
        if (!_isRunning) return;

        _time += Time.deltaTime;
        _timerText.text = _time.ToString("F2");
    }

    private void StopTimer()
    {
        _isRunning = false;


    }
}
