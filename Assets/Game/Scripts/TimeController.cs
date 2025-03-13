using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static TimeController Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SetTime(float newTime)
    {
        Time.timeScale = newTime;
    }

    public void StopTime()
    {
        Time.timeScale = 0f;
    }

    public void ContinueTime()
    {
        Time.timeScale = 1f;
    }
}
