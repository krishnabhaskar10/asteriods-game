using UnityEngine;

public class AppManager : MonoBehaviour
{
    #region Variables

    public static AppManager Instance = null;

    internal UIManager uIManager = null;
    internal ResourceManager resourceManager = null;
    internal UtilityManager utilityManager = null;
    internal DataManager dataManager = null;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this as AppManager;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
        

        uIManager = new UIManager(this);
        resourceManager = new ResourceManager(this);
        utilityManager = new UtilityManager(this);
        dataManager = new DataManager();
    }

    private void Start()
    {
        resourceManager.OnLoad();
        uIManager.OnLoad();
        utilityManager.OnLoad();
        dataManager.OnLoad();
    }

    private void Update()
    {
        resourceManager.OnUpdate();
        uIManager.OnUpdate();
        utilityManager.OnUpdate();
        dataManager.OnUpdate();
    }

    private void OnDestroy()
    {
        resourceManager.OnUnload();
        uIManager.OnUnload();
        utilityManager.OnUnload();
        dataManager.OnUnload();
    }

    #endregion


}
