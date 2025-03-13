using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    [SerializeField] private Player Player;
    [SerializeField] private PlayerMovement PlayerMovement;

    [SerializeField] private float _maxOxygen = 120f;
    [SerializeField] private float _maxFuel = 12f;
    [SerializeField] private float _oxygenConsumptionRate = 1f;
    [SerializeField] private float _fuelConsumptionRate = 0.5f;

    [SerializeField] private float _currentOxygen;
    [SerializeField] private float _currentFuel;
    [SerializeField] bool _isConsumingOxygen = true;
    [SerializeField] private bool _isConsumingFuel = false;

    [SerializeField] private bool _forsageMode;

    public float MaxOxygen
    {
        get => _maxOxygen;
        //private set => _currentOxygen = Mathf.Clamp(value, 0, _maxOxygen);
    }

    public float MaxFuel
    {
        get => _maxFuel;
        //private set => _currentOxygen = Mathf.Clamp(value, 0, _maxOxygen);
    }

    public float CurrentOxygen
    {
        get => _currentOxygen;
        //private set => _currentOxygen = Mathf.Clamp(value, 0, _maxOxygen);
    }

    public float CurrentFuel
    {
        get => _currentFuel;
        //private set => _currentFuel = Mathf.Clamp(value, 0, _maxFuel);
    }

    public void Init()
    {
        _currentOxygen = _maxOxygen;
        _currentFuel = _maxFuel;
    }

    private void Update()
    {
        if (_isConsumingOxygen) ConsumeOxygen();
        if (_isConsumingFuel) ConsumeFuel();

        if (/*_currentFuel <= 0 ||*/ _currentOxygen <= 0)
            Player.Defeat();
    }

    private void OnEnable()
    {
        EventController.OnVictory += SetFalseConsumption;
        EventController.OnDefeat += SetFalseConsumption;
    }

    private void OnDisable()
    {
        EventController.OnVictory -= SetFalseConsumption;
        EventController.OnDefeat -= SetFalseConsumption;
    }

    private void ConsumeOxygen()
    {
        _currentOxygen -= _oxygenConsumptionRate * Time.deltaTime;
        _currentOxygen = Mathf.Max(_currentOxygen, 0f);
    }

    private void ConsumeFuel()
    {
        if (PlayerMovement._forsageMode)
            _currentFuel -= _fuelConsumptionRate * Time.deltaTime * 3;
        else
            _currentFuel -= _fuelConsumptionRate * Time.deltaTime;

        _currentFuel = Mathf.Max(_currentFuel, 0f);

        if (_currentFuel <= 0)
            PlayerMovement.SetFuelZero(true);
        else
            PlayerMovement.SetFuelZero(false);
    }

    public void AddOxygen(float amount)
    {
        _currentOxygen = Mathf.Min(_currentOxygen + amount, _maxOxygen);
    }

    public void AddFuel(float amount)
    {
        _currentFuel = Mathf.Min(_currentFuel + amount, _maxFuel);
    }

    public void RefillOxygen()
    {
        _currentOxygen = _maxOxygen;
    }

    public void RefillFuel()
    {
        _currentFuel = _maxFuel;
    }

    public void SetFalseConsumption()
    {
        _isConsumingOxygen = false;
        _isConsumingFuel = false;
    }

    public void SetOxygenConsumption(bool isConsuming)
    {
        _isConsumingOxygen = isConsuming;
    }

    public void SetFuelConsumption(bool isConsuming)
    {
        _isConsumingFuel = isConsuming;
    }

    public float GetOxygenPercentage()
    {
        return _currentOxygen / _maxOxygen;
    }

    public float GetFuelPercentage()
    {
        return _currentFuel / _maxFuel;
    }

    public void ChangeForsageMode()
    {
        if (_forsageMode)
            _forsageMode = false;
        else
            _forsageMode = true;
    }
}
