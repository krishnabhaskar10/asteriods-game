using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour
{
    public GameObject gameHudPanel = null;
    public GameObject mainMenuPanel = null;

    public Button playButton = null;
    public Button leftRotateButton = null;
    public Button rightRotateButton = null;
    public Button accelerateButton = null;
    public Button shootButton = null;

    public TMP_Text timeText = null;
    private float timer = 5.0f;
        
    private void Start()
    {
        ShowMainMenuPanel();
        AddOnClickListeners();
    }

    private void Update()
    {
        timer -= Time.deltaTime/60;
        SetTimer(timer);
        if (timer <= 0.0f)
        {
            SceneManager.LoadScene(0);
        }
    }
       
    public void SetTimer(float _value)
    {
        timeText.text = _value.ToString("#00.00");
    }

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
