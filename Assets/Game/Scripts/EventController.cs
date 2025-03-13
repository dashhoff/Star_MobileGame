using UnityEngine;
using System;

public static class EventController
{
    public static event Action OnGameStart;

    public static event Action OnForsage;

    public static event Action OffForsage;

    public static event Action OnVictory;

    public static event Action OnDefeat;

    public static event Action OnPause;

    public static event Action OffPause;

    public static event Action OnRefillFuel;

    public static event Action OnRefillOxygen;

    public static event Action OnBlackHole;

    public static event Action OnCheckPoint;

    public static void InvokeGameStart()
    {
        Debug.Log("Start!");

        OnGameStart?.Invoke();
    }

    public static void InvokeOnForsage()
    {
        Debug.Log("OnForsage!");

        OnForsage?.Invoke();
    }

    public static void InvokeOffForsage()
    {
        Debug.Log("OffForsage!");

        OffForsage?.Invoke();
    }

    public static void InvokeVictory()
    {
        Debug.Log("Victory!");

        OnVictory?.Invoke();
    }

    public static void InvokeDefeat()
    {
        Debug.Log("Defeat!");

        OnDefeat?.Invoke();
    }

    public static void InvokePauseON()
    {
        Debug.Log("PauseON!");

        OnPause?.Invoke();
    }

    public static void InvokePauseOFF()
    {
        Debug.Log("PauseOFF!");

        OffPause?.Invoke();
    }

    public static void InvokeRefillFuel()
    {
        Debug.Log("Fuel!");

        OnRefillFuel?.Invoke();
    }

    public static void InvokeRefillOxygen()
    {
        Debug.Log("Oxygen!");

        OnRefillOxygen?.Invoke();
    }

    public static void InvokeBlackHole()
    {
        Debug.Log("BlackHole!");

        OnBlackHole?.Invoke();
    }

    public static void InvokeCheckPoint()
    {
        Debug.Log("CheckPoint!");

        OnCheckPoint?.Invoke();
    }
}
