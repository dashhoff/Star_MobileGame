using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private UI_Panel _rulesPanel;

    [SerializeField] private UI_Panel _mainPanel;

    [SerializeField] private TMP_Text _liederBoard;

    [SerializeField] private TMP_InputField _inputName;

    public void Init()
    {
        SetLiederboard();
    }

    public void Play()
    {
        if (Saves.Instance.firstSession)
            OpenRules();
    }

    public void OpenRules()
    {
        _rulesPanel.Open();

        _mainPanel.Close();
    }

    public void StartGame()
    {
        if (Saves.Instance.firstSession)
            SceneController.Instance.FadeIn(1);
        else
            SceneController.Instance.FadeIn(1);
    }

    public void SetPlayerName()
    {
        Saves.Instance.SetPlayerName(_inputName.name);
    }

    public void SetLiederboard()
    {
        _liederBoard.text = PlayerPrefs.GetString("playerName", "Гость") + ": " +  PlayerPrefs.GetFloat("bestTime", 180);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
