using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuHandler : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TextMeshProUGUI bestScoreText;

    private void Start()
    {
        MenuManager.instance.LoadBestScore();
        bestScoreText.text = $"Best Score : {MenuManager.instance.GetBestName()}: {MenuManager.instance.GetBestScore()}";
    }

    public void onStartPressed()
    {

        if (nameInput.text != "")
        {
            MenuManager.instance.SetName(nameInput.text);
        }
        else
        {
            MenuManager.instance.SetName("Name");
        }

        SceneManager.LoadScene("main");
    }

    public void onQuitPressed()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
