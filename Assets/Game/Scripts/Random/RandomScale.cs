using UnityEngine;

public class RandomScale : MonoBehaviour
{
    [SerializeField] private Vector2 _scale;

    [SerializeField] private bool _autoStart;

    private void Start()
    {
        if (_autoStart)
            Init();
    }

    public void Init()
    {
        float scale = Random.Range(_scale.x, _scale.y);

        gameObject.transform.localScale = new Vector3(scale, scale, scale);
    }
}
