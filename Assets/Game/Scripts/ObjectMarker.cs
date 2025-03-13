using UnityEngine;
using UnityEngine.UI;

public class ObjectMarker : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private RectTransform _markerUI;
    [SerializeField] private Canvas _canvas; 
    [SerializeField] private float _screenOffset = 50f;

    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (_target == null) return;

        Vector3 screenPos = _mainCamera.WorldToScreenPoint(_target.position);
        bool isBehind = screenPos.z < 0;

        if (isBehind)
        {
            screenPos.x = Screen.width - screenPos.x;
            screenPos.y = Screen.height - screenPos.y;

            Vector3 dirToTarget = (_target.position - _mainCamera.transform.position).normalized;
            screenPos = GetEdgePosition(dirToTarget);
        }

        screenPos.x = Mathf.Clamp(screenPos.x, _screenOffset, Screen.width - _screenOffset);
        screenPos.y = Mathf.Clamp(screenPos.y, _screenOffset, Screen.height - _screenOffset);

        _markerUI.gameObject.SetActive(true);
        _markerUI.position = screenPos;
    }

    private Vector3 GetEdgePosition(Vector3 direction)
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Vector3 screenDir = _mainCamera.WorldToScreenPoint(_mainCamera.transform.position + direction) - screenCenter;
        screenDir.z = 0;

        float maxX = (Screen.width - _screenOffset) / 2;
        float maxY = (Screen.height - _screenOffset) / 2;
        float scale = Mathf.Min(maxX / Mathf.Abs(screenDir.x), maxY / Mathf.Abs(screenDir.y));

        return screenCenter + screenDir * scale;
    }

    public void SetTarget(Transform newTarget)
    {
        _target = newTarget;
    }
}
