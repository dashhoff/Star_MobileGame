using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static PauseController Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void PauseON()
    {
        Time.timeScale = 0;

        EventController.InvokePauseON();
    }

    public  void PauseOFF()
    {
        Time.timeScale = 1;

        EventController.InvokePauseOFF();
    }
}
