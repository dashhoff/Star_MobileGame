using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private UI_Panel _startPanel;

    [SerializeField] private UI_Panel _mainPanel;
    
    [SerializeField] private UI_Panel _pausePanel;

    [SerializeField] private UI_Panel _victoryPanel;

    [SerializeField] private UI_Panel _defeatPanel;

    private void OnEnable()
    {
        EventController.OnPause += OnPause;
        EventController.OffPause += OffPause;

        EventController.OnVictory += OnVictory;
        EventController.OnDefeat += OnDefeat;
    }

    private void OnDisable()
    {
        EventController.OnPause -= OnPause;
        EventController.OffPause -= OffPause;

        EventController.OnVictory -= OnVictory;
        EventController.OnDefeat -= OnDefeat;
    }

    private void OnPause()
    {
        _pausePanel.Open();

        _mainPanel.Close();
    }

    private void OffPause()
    {
        _mainPanel.Open();

        _pausePanel.Close();
    }

    private void OnVictory()
    {
        _victoryPanel.Open();

        _mainPanel.Close();
    }

    private void OnDefeat()
    {
        _defeatPanel.Open();
            
        _mainPanel.Close();
    }
}
