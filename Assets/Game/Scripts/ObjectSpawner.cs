using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _objs;

    [SerializeField] private Vector2 _count;

    [SerializeField] private Transform _parent;

    [SerializeField] private Vector3 _spawnZone;

    [SerializeField] private bool _autoSpawn;

    private void Start()
    {
        if (_autoSpawn) 
            Spawn();
    }

    private void Spawn()
    {
        float count = Random.Range(_count.x, _count.y);

        for (int  i = 0; i < count; i++)
        {
            GameObject newObj = Instantiate(_objs[Random.Range(0, _objs.Length)], _parent);

            newObj.transform.position = new Vector3(
                Random.Range(transform.position.x -_spawnZone.x, transform.position.x + _spawnZone.x),
                Random.Range(transform.position.y  - _spawnZone.y, transform.position.y + _spawnZone.y),
                Random.Range(transform.position.z  - _spawnZone.z, transform.position.z + _spawnZone.z)
                );
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 center = transform.position;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(center, _spawnZone);
    }
}
