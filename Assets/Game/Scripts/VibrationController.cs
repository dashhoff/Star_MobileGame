using UnityEngine;

public class VibrationController : MonoBehaviour
{
    private void OnEnable()
    {
        EventController.OnVictory += MediumVibration;

        EventController.OnDefeat += MediumVibration;

        EventController.OnRefillFuel += LightVibration;
        EventController.OnRefillOxygen += LightVibration;

        EventController.OnCheckPoint += LightVibration;

        EventController.OnForsage += LightVibration;
        EventController.OffForsage += LightVibration;
    }

    private void OnDisable()
    {
        EventController.OnVictory -= MediumVibration;

        EventController.OnDefeat -= MediumVibration;

        EventController.OnRefillFuel -= LightVibration;
        EventController.OnRefillOxygen -= LightVibration;

        EventController.OnCheckPoint -= LightVibration;

        EventController.OnForsage -= LightVibration;
        EventController.OffForsage -= LightVibration;
    }

    private void LightVibration()
    {
        Taptic.Light();
    }

    private void MediumVibration()
    {
        Taptic.Medium();
    }
    private void HighVibration()
    {
        Taptic.Heavy();
    }
}
