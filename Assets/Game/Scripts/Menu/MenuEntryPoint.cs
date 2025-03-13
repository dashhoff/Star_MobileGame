using UnityEngine;

public class MenuEntryPoint : MonoBehaviour
{
    [SerializeField] private SceneController _sceneController;

    [SerializeField] private Saves _saves;

    [SerializeField] private MenuController _menuController;

    private void Start()
    {
        Init();
    }

    public void Init() 
    {
        _sceneController.Init();

        _saves.Init();

        _menuController.Init();
    }
}
