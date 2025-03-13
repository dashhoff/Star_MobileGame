using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuSettings : MonoBehaviour
{
    [SerializeField] private Slider _sensitivitySlide;
    [SerializeField] private TMP_Dropdown _targetFPS; 
    [SerializeField] private TMP_Dropdown _targetGraphics;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        _sensitivitySlide.value = SettingsSaves.Instance.sensitivity;

        switch (SettingsSaves.Instance.targetFPS)
        {
            case 60:
                _targetFPS.value = 0;
                break;
            case 75:
                _targetFPS.value = 1;
                break;
            case 90:
                _targetFPS.value = 2;
                break;
            case 120:
                _targetFPS.value = 3;
                break;
        }

        _targetGraphics.value = SettingsSaves.Instance.graphicsIndex;
    }


    public void SliderSettings()
    {
        SettingsSaves.Instance.sensitivity = _sensitivitySlide.value * 100;
        SettingsSaves.Instance.Save();
    }

    public void FPSSettings()
    {
        SettingsSaves.Instance.targetFPS = _targetFPS.value;
        SettingsSaves.Instance.Save();

        switch (_targetGraphics.value)
        {
            case 0:
                Application.targetFrameRate = 60;
                break;
            case 1:
                Application.targetFrameRate = 75;
                break;
            case 2:
                Application.targetFrameRate = 90;
                break;
            case 3:
                Application.targetFrameRate = 120;
                break;
        }
    }

    public void GraphicsSettings()
    {
        SettingsSaves.Instance.graphicsIndex = _targetGraphics.value;
        SettingsSaves.Instance.Save();

        switch (_targetGraphics.value) 
        {
            case 0:
                QualitySettings.SetQualityLevel(0);
                break;
            case 1:
                QualitySettings.SetQualityLevel(1);
                break;
            case 2:
                QualitySettings.SetQualityLevel(2);
                break;
        }
    }
}
