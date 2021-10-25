using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class PlayerData
{
    public string bestScoreName;
    public int bestScore;
}

public class MenuController : MonoBehaviour
{
    public static MenuController instance;

    public Text bestScoreText;
    public string newPlayerName;
    public string bestScoreName;
    public int bestScore;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadGame();
        bestScoreText.text = "Best Score: " + bestScoreName + " " + bestScore;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Exit();
#endif
    }

    public void GetPlayerName(string name)
    {
        newPlayerName = name;
        Debug.Log(newPlayerName);
    }

    public void SaveGame()
    {
        PlayerData savedData = new PlayerData();
        savedData.bestScoreName = bestScoreName;
        savedData.bestScore = bestScore;

        string json = JsonUtility.ToJson(savedData);
        File.WriteAllText(Application.persistentDataPath + "/SaveData.json", json);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/SaveData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData loadedData = JsonUtility.FromJson<PlayerData>(json);

            bestScoreName = loadedData.bestScoreName;
            bestScore = loadedData.bestScore;
        }
    }
}
