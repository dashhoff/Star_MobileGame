using UnityEngine;

public class GameEntryPoint : MonoBehaviour
{
    [SerializeField] private SceneController _sceneController;

    [SerializeField] private Saves _saves;

    [SerializeField] private CheckPointController _checkPointController;

    private void Start()
    {
        Init();
    }

    public void Init() 
    {
        _sceneController.Init();

        _saves.Init();

        _checkPointController.Init();

        EventController.InvokeGameStart();
    }
}
