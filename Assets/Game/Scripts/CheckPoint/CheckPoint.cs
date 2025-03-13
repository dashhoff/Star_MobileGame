using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public int Index;

    public Transform SpawnPoint;

    [SerializeField] private ParticleSystem _particleSystem;

    public void Activate()
    {
        _particleSystem.Play();
    }

    public void Deactivate()
    {
        _particleSystem.Stop();
    }
}
