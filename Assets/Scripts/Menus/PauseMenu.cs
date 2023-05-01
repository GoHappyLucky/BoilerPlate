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
        if (context.performed && PlayableSceneLoaded())
        {
            var active = menuCanvas.gameObject.activeSelf;
            menuCanvas.gameObject.SetActive(!active); // toggle pause menu
        }
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
            if (scene.buildIndex > 0)
            {
                SceneManager.UnloadSceneAsync(scene.buildIndex);
                break;
            }
        }
        
    }

    private bool PlayableSceneLoaded()
    {
        var playableSceneLoaded = false;
        for (int s = 0; s < SceneManager.sceneCount; s++)
        {
            var scene = SceneManager.GetSceneAt(s);
            if (scene.buildIndex >= 1)
            {
                playableSceneLoaded = true;
                break;
            }
        }
        return playableSceneLoaded;
    }
}
