using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerResources _playerResources;

    [SerializeField] private bool _victory = false; 
    [SerializeField] private bool _defeat = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void Victory()
    {
        _victory = true;

        EventController.InvokeVictory();
    }

    public void Defeat()
    {
        _defeat = true;

        EventController.InvokeDefeat();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("UFO"))
        {
            if (_defeat || _victory)
                return;

            Defeat();
        }

        if (collision.gameObject.CompareTag("Fuel"))
        {
            _playerResources.RefillFuel();

            ResourceFuel fuel = collision.gameObject.GetComponent<ResourceFuel>();
            fuel.Collect();

            EventController.InvokeRefillFuel();
        }

        if (collision.gameObject.CompareTag("Oxygen"))
        {
            ResourceOxygen oxygen = collision.gameObject.GetComponent<ResourceOxygen>();
            oxygen.Collect();

            _playerResources.RefillOxygen();

            EventController.InvokeRefillOxygen();
        }

        if (collision.gameObject.CompareTag("BlackHole"))
        {
            BlackHole blackHole = collision.gameObject.GetComponent<BlackHole>();
            blackHole.Teleport(gameObject);

            EventController.InvokeBlackHole();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            if (_defeat || _victory)
                return;

            Victory();
        }

        if (other.gameObject.CompareTag("CheckPoint"))
        {
            CheckPoint checkPoint = other.GetComponent<CheckPoint>();

            if (checkPoint.Index <= Saves.Instance.checkPoint)
                return;

            Saves.Instance.SetCheckPoint(checkPoint.Index);

            EventController.InvokeCheckPoint();
        }
    }
}
