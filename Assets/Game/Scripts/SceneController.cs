using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    [SerializeField] private Image _fadeBackgorud;

    [SerializeField] private float _fadeInDuration; 
    [SerializeField] private float _fadeOutDuration;

    [SerializeField] private float _delay;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void Init()
    {
        FadeOut();
    }

    public void LoadLevel(int id)
    {
        SceneManager.LoadScene(id);
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void FadeIn(int id)
    {
        DOTween.Sequence()
            .SetUpdate(true)
            .Append(_fadeBackgorud.DOFade(1, _fadeInDuration))
            .AppendInterval(_delay)
            .OnComplete(() => 
            {
                LoadLevel(id);
            });
    }

    public void FadeIn(string name)
    {
        DOTween.Sequence()
            .SetUpdate(true)
            .Append(_fadeBackgorud.DOFade(1, _fadeInDuration))
            .AppendInterval(_delay)
            .OnComplete(() =>
            {
                LoadLevel(name);
            });
    }

    public void FadeOut()
    {
        _fadeBackgorud.gameObject.SetActive(true);

        DOTween.Sequence()
            .SetUpdate(true)
            .Append(_fadeBackgorud.DOFade(0, _fadeOutDuration))
            .OnComplete(() =>
            {
                _fadeBackgorud.gameObject.SetActive(false);
            });
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
