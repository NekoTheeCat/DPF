using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string LastName;
    public string HighscoreName;
    public int HighScore;
    public Text CurrentNameText;
    public Text CurrentHighscoreText;
    [System.Serializable]
    public class SaveData
    {
        public string SavedHighScoreName;
        public string SavedLastName;        
        public int HighScore;

    }
    private void Awake()
    {
                    
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadName();
    }
    // Start is called before the first frame update
    void Start()
    {

            CurrentNameText.text = "Name " + LastName;
            CurrentHighscoreText.text = "Highscore " + HighscoreName + " " + HighScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveName()
    {
        SaveData data = new SaveData();
        data.SavedLastName = LastName;
        data.SavedHighScoreName = HighscoreName;
        data.HighScore = HighScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            LastName = data.SavedLastName;
            HighscoreName = data.SavedHighScoreName;
            HighScore = data.HighScore;
        }
    }


}
