using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    [SerializeField] private CheckPoint[] _checkPoints;
    [SerializeField] private GameObject _finish;
    [SerializeField] private ObjectMarker _marker;
    [SerializeField] private Player _player;

    public void Init()
    {
        int lastCheckPointIndex = Saves.Instance.checkPoint;

        if (lastCheckPointIndex < _checkPoints.Length)
        {
            _player.transform.position = _checkPoints[lastCheckPointIndex].SpawnPoint.position;
        }

        foreach (CheckPoint checkPoint in _checkPoints)
        {
            if (checkPoint.Index < lastCheckPointIndex)
                checkPoint.Deactivate();
        }

        SetNewTarget();
    }

    private void OnEnable()
    {
        EventController.OnCheckPoint += SetNewTarget;
    }

    private void OnDisable()
    {
        EventController.OnCheckPoint -= SetNewTarget;
    }

    private void SetNewTarget()
    {
        int nextCheckPointIndex = Saves.Instance.checkPoint + 1;

        if (nextCheckPointIndex < _checkPoints.Length)
        {
            _marker.SetTarget(_checkPoints[nextCheckPointIndex].transform);
        }
        else
        {
            _marker.SetTarget(_finish.transform);
        }
    }
}
