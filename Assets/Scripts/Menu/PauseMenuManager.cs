using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup _groupOfdaPauseCanvas;
    private bool _paused = false;


    private void Start()
    {
        MenuVisibility(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _paused = ! _paused;
            MenuVisibility(_paused);
        }
    }

    private void MenuVisibility(bool isVisible)
    {

            _groupOfdaPauseCanvas.alpha = isVisible ? 1f : 0f;
            Time.timeScale = isVisible ? 0f : 1f;
            _groupOfdaPauseCanvas.blocksRaycasts = isVisible;
            _groupOfdaPauseCanvas.interactable = isVisible;
    }
    public void ContinueDaGame()
    {
        MenuVisibility(_paused = false);
    }
    public void ReturnToMenuOfDaGame()
    {
        SceneManager.LoadScene(0);
    }
    
    public void QuitdaGame()
    {
        Application.Quit();
    }

}
