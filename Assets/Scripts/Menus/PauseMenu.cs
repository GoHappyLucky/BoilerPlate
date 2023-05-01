using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PauseMenu : MenuBase<PauseMenu>
{
    public static event Action LoadMainMenu;
    [SerializeField] Button ContinueButton;
    [SerializeField] Button QuitToMainButton;

    private void Start()
    {
        if (ContinueButton)
        {
            ContinueButton.onClick.RemoveAllListeners();
            ContinueButton.onClick.AddListener(delegate { Continue(ContinueButton); });
        }
        if (QuitToMainButton)
        {
            QuitToMainButton.onClick.RemoveAllListeners();
            QuitToMainButton.onClick.AddListener(delegate { QuitToMain(QuitToMainButton); });
        }
    }

    private void OnDestroy()
    {
    }

    private void Update()
    {
        
    }

    public void ShowPauseMenu(InputAction.CallbackContext context)
    {
        if (context.performed)
            menuCanvas.gameObject.SetActive(true);
    }

    private void Continue(Button continueButton)
    {
        menuCanvas.gameObject.SetActive(false);
    }

    private void QuitToMain(Button quitToMainButton)
    {
        menuCanvas.gameObject.SetActive(false);
        LoadMainMenu?.Invoke();
        for (int s = 0; s < SceneManager.sceneCount; s++)
        {
            var scene = SceneManager.GetSceneAt(s);
            if (scene.buildIndex == 1)
            {
                SceneManager.UnloadSceneAsync(1);
                break;
            }
        }
        
    }
}
