using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;

    [SerializeField] private AudioSource _footSound;
    [SerializeField] private AudioSource _flySound;

    public void Update()
    {
        FootSound();
        FlySound();
    }

    private void FootSound()
    {
        if(_footSound.isPlaying && !_playerMovement._isMoving)
            _footSound.Stop();
        else if (!_footSound.isPlaying && _playerMovement._isMoving)
            _footSound.Play();
        else if (_footSound.isPlaying && _playerMovement._isMoving)
            _footSound.Stop();
    }

    private void FlySound()
    {
        if (_flySound.isPlaying && !_playerMovement._isVerticalMoving)
            _flySound.Stop();
        else if (!_flySound.isPlaying && _playerMovement._isVerticalMoving)
            _flySound.Play();
        else if (_flySound.isPlaying && _playerMovement._isVerticalMoving)
            _flySound.Stop();
    }
}
