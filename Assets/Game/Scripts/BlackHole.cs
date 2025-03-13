using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [SerializeField] private GameObject _pair;

    [SerializeField] private float _offset = 25;

    public void Teleport(GameObject obj)
    {
        if (Random.value < 0.5)
            _offset *= -1;

        obj.transform.position = new Vector3(
            _pair.transform.position.x + _offset,
            _pair.transform.position.y + _offset,
            _pair.transform.position.z + _offset
            );
    }

    public void SetPair(GameObject obj)
    {
        _pair = obj;
    }
}
