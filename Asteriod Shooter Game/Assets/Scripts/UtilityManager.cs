using System;
using UnityEngine;

public class UtilityManager
{
    MonoBehaviour monoBehaviour = null;

    public delegate void OnLeftRotation();
    public delegate void OnRightRotation();
    public delegate void OnAccelerate();
    public delegate void OnShoot();    

    public OnLeftRotation OnPlayerLeftRotate;
    public OnRightRotation OnPlayerRightRotate;
    public OnAccelerate OnPlayerAcceleration;
    public OnShoot OnPlayerShooting;

    public UtilityManager(MonoBehaviour _monoBehaviour)
    {
        monoBehaviour = _monoBehaviour;
    }

    public void OnLoad()
    {

    }

    public void OnUpdate()
    {

    }

    public void OnUnload()
    {

    }

    public void GoVisibility(bool status, params GameObject[] objs)
    {
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].SetActive(status);
        }
    }

}
