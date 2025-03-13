using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private PlayerResources PlayerResources;

    [SerializeField] private Image _fuelBar;
    [SerializeField] private Image _oxygenBar;

    private void Update()
    {
        UpdateBars();
    }

    public void UpdateBars()
    {
        float fuel = PlayerResources.CurrentFuel / PlayerResources.MaxFuel;
        _fuelBar.fillAmount = fuel;

        float oxygen = PlayerResources.CurrentOxygen / PlayerResources.MaxOxygen;
        _oxygenBar.fillAmount = oxygen;
    } 
}
