using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _3DCamera;
    [SerializeField] private GameObject _1DCamera;

    [SerializeField] private bool _3DMode = true;

    public void SwitchCamera()
    {
        if (_3DMode)
        {
            _3DMode = false;

            _1DCamera.SetActive(true);
            _3DCamera.SetActive(false);
        }
        else
        {
            _3DMode = true;

            _3DCamera.SetActive(true);
            _1DCamera.SetActive(false);
        }
    }
}
