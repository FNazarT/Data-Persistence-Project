using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
       using UnityEditor;
#endif

[System.Serializable]
public class PlayerData
{
    public string name;
    public int score;
}

public class MenuController : MonoBehaviour
{
    public static MenuController instance;

    public string playerName;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        playerName = name;
        Debug.Log(playerName);
    }
}
