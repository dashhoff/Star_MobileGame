using UnityEngine;
using NaughtyAttributes;
using static UnityEngine.Rendering.DebugUI;

public class Saves : MonoBehaviour
{
    public static Saves Instance;

    public bool firstSession = true;

    public int checkPoint = 0;

    public string playerName;
    public float bestTime;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void Init()
    {
        if (PlayerPrefs.GetInt("firstSession", 1) == 1)
            firstSession = true;
        else
            firstSession = false;

        checkPoint = PlayerPrefs.GetInt("checkPoint", 0);

        playerName = PlayerPrefs.GetString("PlayerName", "Гость");
        bestTime = PlayerPrefs.GetFloat("bestTime");
    }

    public void SetFirstSession(int value)
    {
        if (value == 1)
        {
            PlayerPrefs.SetInt("firstSession", 1);
            firstSession = true;
        }
        else
        {
            PlayerPrefs.SetInt("firstSession", 0);
            firstSession = false;
        }

        Save();
    }

    public void SetCheckPoint(int value)
    {
        checkPoint = value;

        PlayerPrefs.SetInt("checkPoint", checkPoint);

        Save();
    }

    public void SetPlayerName(string value)
    {
        playerName = value;

        PlayerPrefs.SetString("playerName", playerName);

        Save();
    }

    public void SetBestTime(float value)
    {
        bestTime = value;

        PlayerPrefs.SetFloat("bestTime", bestTime);

        Save();
    }

    public void Save()
    {
        PlayerPrefs.Save();
    }

    [Button]
    public void SaveEditor()
    {
        if (firstSession)
            SetFirstSession(1);
        else
            SetFirstSession(0);

        SetCheckPoint(checkPoint);

        SetPlayerName(playerName);
        SetBestTime(bestTime);
    }
}
