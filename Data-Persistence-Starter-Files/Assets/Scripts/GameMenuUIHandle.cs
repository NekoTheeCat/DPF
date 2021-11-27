using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameMenuUIHandle : MonoBehaviour
{
    public Text CurrentNameText;
    public Text CurrentHighscoreText;
    public static MainManager Instance;
 
    public void StartGame()
    {
        SceneManager.LoadScene(1);


    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

}
