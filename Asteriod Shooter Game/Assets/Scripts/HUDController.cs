using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    #region Variables

    public GameObject gameHudPanel = null;
    public GameObject mainMenuPanel = null;

    public Button playButton = null;
    public Button leftRotateButton = null;
    public Button rightRotateButton = null;
    public Button accelerateButton = null;
    public Button shootButton = null;

    #endregion

    #region Unity Methods

    private void Start()
    {
        ShowMainMenuPanel();
        AddOnClickListeners();
    }

    #endregion

    private void DisableAllPanels()
    {
        AppManager.Instance.utilityManager.GoVisibility(false, gameHudPanel, mainMenuPanel);
    }

    private void ShowMainMenuPanel()
    {
        DisableAllPanels();
        AppManager.Instance.utilityManager.GoVisibility(true, mainMenuPanel);
    }

    private void ShowGameHudPanel()
    {
        DisableAllPanels();
        AppManager.Instance.utilityManager.GoVisibility(true, gameHudPanel);
    }

    private void AddOnClickListeners()
    {
        playButton.onClick.AddListener(() => OnClickPlayButton());
        leftRotateButton.onClick.AddListener(() => OnClickLeftRotateButton());
        rightRotateButton.onClick.AddListener(() => OnClickRightRotateButton());
        accelerateButton.onClick.AddListener(() => OnClickAccelerateButton());
        shootButton.onClick.AddListener(() => OnClickShootButton());
    }

    private void OnClickPlayButton()
    {
        ShowGameHudPanel();
        AppManager.Instance.uIManager.AddGameElements();
    }

    private void OnClickLeftRotateButton()
    {
        AppManager.Instance.utilityManager.OnPlayerLeftRotate();
    }

    private void OnClickRightRotateButton()
    {
        AppManager.Instance.utilityManager.OnPlayerRightRotate();
    }

    private void OnClickAccelerateButton()
    {
        AppManager.Instance.utilityManager.OnPlayerAcceleration();
    }

    private void OnClickShootButton()
    {
        AppManager.Instance.utilityManager.OnPlayerShooting();
    }

}
