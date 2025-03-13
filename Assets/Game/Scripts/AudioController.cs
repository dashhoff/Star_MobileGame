using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    [SerializeField] private AudioSource _music;

    [SerializeField] private AudioSource _victorySound;
    [SerializeField] private AudioSource _defeatSound;

    [SerializeField] private AudioSource _checkPointSound;

    [SerializeField] private AudioSource _ufoSound;

    [SerializeField] private AudioSource _footSound; 
    [SerializeField] private AudioSource _flySound;

    [SerializeField] private AudioSource _forsageSound;

    [SerializeField] private AudioSource _fuelSound;
    [SerializeField] private AudioSource _oxygenSound;

    [SerializeField] private AudioSource _uiSound;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void OnEnable()
    {
        EventController.OnVictory += OnVictory;
        EventController.OnVictory += OffUFO;
        EventController.OnVictory += OffForsage;

        EventController.OnDefeat += OnDefeat;
        EventController.OnDefeat += OffUFO; 
        EventController.OnDefeat += OffForsage;

        EventController.OnRefillFuel += OnFuel;
        EventController.OnRefillOxygen += OnOxygen;

        EventController.OnCheckPoint += OnCheckPoint;

        EventController.OnForsage += OnForsage;
        EventController.OffForsage += OffForsage;
    }

    private void OnDisable()
    {
        EventController.OnVictory -= OnVictory;
        EventController.OnVictory -= OffUFO;
        EventController.OnVictory -= OffForsage;

        EventController.OnDefeat -= OnDefeat;
        EventController.OnDefeat -= OffUFO;
        EventController.OnDefeat -= OffForsage;

        EventController.OnRefillFuel -= OnFuel;
        EventController.OnRefillOxygen -= OnOxygen;

        EventController.OnCheckPoint -= OnCheckPoint;

        EventController.OnForsage -= OnForsage;
        EventController.OffForsage -= OffForsage;
    }

    private void OnMusic()
    {
        _music.Play();
    }

    private void OffMusic()
    {
        _music.Stop();
    }

    private void OnVictory()
    {
        Instantiate(_victorySound, Player.Instance.transform);
    }

    private void OnDefeat()
    {
        Instantiate(_defeatSound, Player.Instance.transform);
    }

    private void OnCheckPoint()
    {
        Instantiate(_checkPointSound, Player.Instance.transform);
    }

    private void OnUFO() 
    { 

    }

    private void OffUFO()
    {

    }

    public void OnFuel()
    {
        Instantiate(_fuelSound, Player.Instance.transform);
    }

    public void OnOxygen()
    {
        Instantiate(_oxygenSound, Player.Instance.transform);
    }

    private void OnForsage()
    {
        _forsageSound.Play();
    }

    private void OffForsage()
    {
        _forsageSound.Stop();
    }

    public void OnUI() 
    {
        Instantiate(_uiSound, Player.Instance.transform);
    }
}
