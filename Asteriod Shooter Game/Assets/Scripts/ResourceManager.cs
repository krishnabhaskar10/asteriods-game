using System;
using UnityEngine;
using System.Collections;

public class ResourceManager
{
    MonoBehaviour monoBehaviour = null;

    public ResourceManager(MonoBehaviour _monoBehaviour)
    {
        monoBehaviour = _monoBehaviour;
    }

    public IEnumerator LoadGameObject(string path, Action<GameObject> OnLoaded)
    {
        GameObject resource = LoadResources(path);
        yield return resource;        

        GameObject go = AddResourcetoScene(resource);
        yield return go;

        OnLoaded(go);
    }

    private GameObject AddResourcetoScene(GameObject _obj)
    {
        GameObject go = null;
        
        try
        {            
            go = UnityEngine.Object.Instantiate(_obj) as GameObject;
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("Asset Not Loaded." + e.Message);
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }

        return go;

    }

    private GameObject LoadResources(string _path)
    {
        if (string.IsNullOrEmpty(_path))
        {
            Debug.LogError("Path is empty.");
            return null;
        }        

        GameObject go = null;

        try
        {
            go = Resources.Load(_path) as GameObject;
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("Asset Not Loaded." + e.Message);
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }


        return go;
    }

    public void OnLoad()
    {
        
    }

    public void OnUpdate()
    {

    }

    public void OnUnload()
    {
        monoBehaviour = null;
    }
}
