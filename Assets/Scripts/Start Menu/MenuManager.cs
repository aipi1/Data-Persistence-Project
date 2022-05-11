using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    private string playerName;
    private int playerScore;
    private string bestPlayerName;
    private int bestPlayerScore;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetName(string newName)
    {
        playerName = newName;
    }

    public string GetName()
    {
        return playerName;
    }

    public void SetScore(int score)
    {
        playerScore = score;
    }

    public int GetScore()
    {
        return playerScore;
    }

    public void SetBestName(string newName)
    {
        bestPlayerName = newName;
    }

    public string GetBestName()
    {
        return bestPlayerName;
    }

    public void SetBestScore(int score)
    {
        bestPlayerScore = score;
    }

    public int GetBestScore()
    {
        return bestPlayerScore;
    }

    [Serializable]
    class SaveData
    {
        public string playerName;
        public int playerScore;
    }

    public void SaveNewBestScore()
    {
        SaveData data = new SaveData();
        data.playerName = bestPlayerName;
        data.playerScore = bestPlayerScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.playerName;
            bestPlayerScore = data.playerScore;
        }
    }
}
