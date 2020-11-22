using UnityEngine;
using System;
using System.Collections;

public class UIManager
{
    MonoBehaviour monoBehaviour = null;

    public UIManager(MonoBehaviour _monoBehaviour)
    {
        monoBehaviour = _monoBehaviour;
    }

    private void OnHUDLoaded(GameObject _go) {
        
    }

    private void OnGameElementsLoaded(GameObject _go)
    {

    }

    public void OnLoad()
    {
        monoBehaviour.StartCoroutine(AppManager.Instance.resourceManager.LoadGameObject(Common.inGameHUDPath, OnHUDLoaded));        
    }

    public void OnUpdate()
    {

    }

    public void OnUnload()
    {
        monoBehaviour = null;
    }

    public void AddGameElements()
    {
        monoBehaviour.StartCoroutine(AppManager.Instance.resourceManager.LoadGameObject(Common.gameElements, OnGameElementsLoaded));
    }
}
