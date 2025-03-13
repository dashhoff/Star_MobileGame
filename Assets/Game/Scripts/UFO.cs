using UnityEngine;
using System.Collections;

public class UFO : MonoBehaviour
{
    public enum UFOState { Patrolling, Observing, Chasing }

    public UFOState CurrentState { get; private set; } = UFOState.Patrolling;

    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _chaseSpeed = 8f;
    [SerializeField] private float _detectionRadius = 15f;
    [SerializeField] private float _viewDistance = 20f;
    [SerializeField] private Transform _player;
    [SerializeField] private LayerMask _obstacleMask;

    [SerializeField] private Vector3 _patrolZoneSize;
    [SerializeField] private Vector2 _observeTimeRange = new Vector2(2f, 5f);
    [SerializeField, Range(0f, 1f)] private float _observeChance = 0.2f;

    private UFOState _currentState = UFOState.Patrolling;
    private Vector3 _patrolCenter;
    private Vector3 _patrolTarget;
    private Vector3 _velocity = Vector3.zero;

    private void Start()
    {
        _patrolCenter = transform.position;
        StartCoroutine(PatrolRoutine());
    }

    private void Update()
    {
        switch (_currentState)
        {
            case UFOState.Patrolling:
                Patrol();
                CheckForPlayer();
                break;

            case UFOState.Observing:
                break;

            case UFOState.Chasing:
                ChasePlayer();
                CheckIfLostPlayer();
                break;
        }
    }

    private void Patrol()
    {
        if (Vector3.Distance(transform.position, _patrolTarget) < 1f)
        {
            if (Random.value < _observeChance)
            {
                _currentState = UFOState.Observing;
                StartCoroutine(ObserveRoutine());
            }
            else
            {
                SetRandomPatrolPoint();
            }
        }

        MoveSmoothly(_patrolTarget, _speed);
    }

    private void ChasePlayer()
    {
        if (_player != null)
        {
            Vector3 target = _player.position;
            if (!IsInsidePatrolZone(target))
                target = ClampToPatrolZone(target);

            MoveSmoothly(target, _chaseSpeed);
        }
    }

    private void CheckForPlayer()
    {
        if (Vector3.Distance(transform.position, _player.position) <= _detectionRadius)
        {
            if (!Physics.Raycast(transform.position, (_player.position - transform.position).normalized, _viewDistance, _obstacleMask))
            {
                _currentState = UFOState.Chasing;
            }
        }
    }

    private void CheckIfLostPlayer()
    {
        if (Vector3.Distance(transform.position, _player.position) > _detectionRadius)
            _currentState = UFOState.Patrolling;
    }

    private void MoveSmoothly(Vector3 target, float speed)
    {
        transform.position = Vector3.SmoothDamp(transform.position, target, ref _velocity, 0.5f, speed);
    }

    private IEnumerator PatrolRoutine()
    {
        while (true)
        {
            if (_currentState == UFOState.Patrolling)
                SetRandomPatrolPoint();

            yield return new WaitForSeconds(5f);
        }
    }

    private IEnumerator ObserveRoutine()
    {
        float waitTime = Random.Range(_observeTimeRange.x, _observeTimeRange.y);
        yield return new WaitForSeconds(waitTime);
        _currentState = UFOState.Patrolling;
    }

    private void SetRandomPatrolPoint()
    {
        _patrolTarget = _patrolCenter + new Vector3(
            Random.Range(-_patrolZoneSize.x / 2, _patrolZoneSize.x / 2),
            Random.Range(-_patrolZoneSize.y / 2, _patrolZoneSize.y / 2),
            Random.Range(-_patrolZoneSize.z / 2, _patrolZoneSize.z / 2)
        );
    }

    private bool IsInsidePatrolZone(Vector3 position)
    {
        Vector3 minBounds = _patrolCenter - _patrolZoneSize / 2;
        Vector3 maxBounds = _patrolCenter + _patrolZoneSize / 2;
        return position.x >= minBounds.x && position.x <= maxBounds.x &&
               position.y >= minBounds.y && position.y <= maxBounds.y &&
               position.z >= minBounds.z && position.z <= maxBounds.z;
    }

    private Vector3 ClampToPatrolZone(Vector3 position)
    {
        Vector3 minBounds = _patrolCenter - _patrolZoneSize / 2;
        Vector3 maxBounds = _patrolCenter + _patrolZoneSize / 2;
        return new Vector3(
            Mathf.Clamp(position.x, minBounds.x, maxBounds.x),
            Mathf.Clamp(position.y, minBounds.y, maxBounds.y),
            Mathf.Clamp(position.z, minBounds.z, maxBounds.z)
        );
    }

    public void SetPlayer(GameObject newPlayer)
    {
        _player = newPlayer.transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_currentState == UFOState.Patrolling)
            SetRandomPatrolPoint();
    }

    private void OnDrawGizmosSelected()
    {
        _patrolCenter = transform.position;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_patrolCenter, _patrolZoneSize);
    }
}
