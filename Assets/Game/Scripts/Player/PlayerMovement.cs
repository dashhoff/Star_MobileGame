using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerResources PlayerResources;

    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _verticalSpeed;
    [SerializeField] private float _rotationSpeed;

    [Space(20f)]
    [SerializeField] private bool _fuelZero = false;
    [SerializeField] private bool _canMoving = true;
    public bool _isMoving;
    public bool _isVerticalMoving;
    [SerializeField] private bool _isRotating;

    [Space(20f)]
    public bool _forsageMode;

    [Space(20f)]
    [SerializeField] private Joystick _leftJoystick;
    [SerializeField] private Joystick _rightJoystick;

    [Space(20f)]
    [SerializeField] private Rigidbody _rb;

    private void Start()
    {
        if (_rb == null)
            _rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //MovePlayer();
        //RotatePlayer();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
        PlayerInput();
    }

    private void PlayerInput()
    {
        if (_isMoving || _isVerticalMoving)
            PlayerResources.SetFuelConsumption(true);
        else
            PlayerResources.SetFuelConsumption(false);
    }

    private void MovePlayer()
    {
        //Vector3 input = new Vector3(_leftJoystick.Direction.x, 0, _leftJoystick.Direction.y);
        Vector3 verticalInput = new Vector3(0, _rightJoystick.Direction.y, 0);

        Vector3 moveDirection = transform.right * _leftJoystick.Direction.x + _leftJoystick.Direction.y * transform.forward;

        if (moveDirection.x != 0 || moveDirection.y != 0)
        {
            _isMoving = true;

            if (_fuelZero)
                _rb.AddForce(moveDirection * _horizontalSpeed * 0.5f);
            else
                _rb.AddForce(moveDirection * _horizontalSpeed);
        }
        else
        {
            _isMoving = false;
        }

        if (verticalInput.y != 0 && !_fuelZero)
        {
            _isVerticalMoving = true;

            _rb.AddForce(verticalInput * _verticalSpeed);
        }
        else
        {
            _isVerticalMoving = false;
        }
    }

    private void RotatePlayer()
    {
        Vector3 rotatingInput = new Vector3(0, _rightJoystick.Direction.x, 0);

        if (rotatingInput.x != 0 || rotatingInput.y != 0)
        {
            _isRotating = true;

            _rb.AddTorque(rotatingInput * _rotationSpeed * SettingsSaves.Instance.sensitivity / 50);
        }
        else
        {
            PlayerResources.SetFuelConsumption(false);

            _isRotating = false;
        }
    }

    public void OnForsage()
    {
        _forsageMode = true;

        EventController.InvokeOnForsage();
    }

    public void OffForsage()
    {
        _forsageMode = false;

        EventController.InvokeOffForsage();
    }

    public void SetFuelZero(bool value)
    {
        _fuelZero = value;
    }
}
