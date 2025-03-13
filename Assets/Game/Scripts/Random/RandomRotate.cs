using UnityEngine;

public class RandomRotate : MonoBehaviour
{
    [SerializeField] private Vector3 _minRotate; 
    [SerializeField] private Vector3 _maxRotate;

    [SerializeField] private Vector2 _randomTorque;

    [SerializeField] private bool _autoStart;

    [SerializeField] private Rigidbody _rb;

    private void Start()
    {
        if (_autoStart)
            Init();
    }

    public void Init()
    {
        Quaternion rotate = new Quaternion(
            Random.Range(_minRotate.x, _maxRotate.x),
            Random.Range(_minRotate.y, _maxRotate.y),
            Random.Range(_minRotate.z, _maxRotate.z),
            0
            );
        gameObject.transform.rotation = rotate;

        if (_rb == null)
            return;

        Vector3 torque = new Vector3(
            Random.Range(_randomTorque.x, _randomTorque.y),
            Random.Range(_randomTorque.x, _randomTorque.y),
            Random.Range(_randomTorque.x, _randomTorque.y)
            );
        _rb.AddTorque(torque, ForceMode.Impulse);
    }
}
