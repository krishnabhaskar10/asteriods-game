using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class DataManager
{    
    public DataManager()
    {
        
    }

    private IEnumerator ParseData(string _path)
    {
        UnityWebRequest www = new UnityWebRequest(_path);
        yield return www;

        if (www.isDone)
        {
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.LogError("Unable to parse json: " + www.error);
            }
            else
            {   
                Debug.Log("JsonData");
            }
        }
    }

    public void OnLoad()
    {
        ParseData(Common.jsonPath);
    }

    public void OnUpdate()
    {

    }

    public void OnUnload()
    {

    }
}
