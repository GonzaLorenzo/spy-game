using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private bool _isOnMenu = false;
    public static int completedLevels;
    [SerializeField] private LanguageManager manager;
    [SerializeField] private GameObject _loadObject;
    [SerializeField] private Slider _loadSlider;

    [Header("UI")] 
    [SerializeField] private TextMeshProUGUI _playButtonText;
    [SerializeField] private TextTranslate _playButtonTextTranslator;
    [SerializeField] private Button _playButton;

    

    void Awake()
    {
        if (_isOnMenu && completedLevels >= 1)
        {
            if(manager.selectedLanguage == 0)
            {
                _playButtonText.text = "CONTINUE";
            }
            else
            {
                _playButtonText.text = "CONTINUAR";
            }
            
            _playButtonTextTranslator.ID = "ID_Continue";
            _playButton.onClick = new Button.ButtonClickedEvent();
            _playButton.onClick.AddListener(ContinueGame);
        }
    }

    public void SelectMission(int missionNumber)
    {
        StartCoroutine(AsynchronousLoad(missionNumber));
    }

    public void ContinueGame()
    {
        StartCoroutine(AsynchronousLoad(completedLevels));
        _loadObject.SetActive(true);
    }

    public void ChangeLanguage()
    {
        manager.ChangeLanguageReference();
    }
    /* public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    } */

    public void NextSceneAsync()
    {
        //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(AsynchronousLoad(SceneManager.GetActiveScene().buildIndex + 1));
    }

    /* public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    } */

    public void BackToMenuAsync()
    {
        StartCoroutine(AsynchronousLoad(0));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    /* public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    } */

    public void RetryLevelAsync()
    {
        StartCoroutine(AsynchronousLoad(SceneManager.GetActiveScene().buildIndex));
    }

    public IEnumerator AsynchronousLoad(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            _loadSlider.value = progress;

            //Debug.Log(_loadSlider.value);

            yield return null;
        }
    }
}
