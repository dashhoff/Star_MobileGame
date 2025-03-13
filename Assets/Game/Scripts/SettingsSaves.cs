using UnityEngine;

public class SettingsSaves : MonoBehaviour
{
    public static SettingsSaves Instance;

    public int targetFPS = 60;
    public int graphicsIndex = 0;
    public float sensitivity = 5;

    private void Awake() 
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        targetFPS =  PlayerPrefs.GetInt("targetFPS", 60);
        graphicsIndex = PlayerPrefs.GetInt("graphicsIndex", 1);
        sensitivity = PlayerPrefs.GetFloat("sensitivity", 50);
    }

    public void Save()
    {
        PlayerPrefs.SetInt("targetFPS", targetFPS);
        PlayerPrefs.SetInt("graphicsIndex", graphicsIndex);
        PlayerPrefs.SetFloat("sensitivity", sensitivity);

        PlayerPrefs.Save();
    }
}
