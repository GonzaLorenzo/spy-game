using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class DataManager : MonoBehaviour
{
    private LevelData levelData;
    [SerializeField] private LanguageManager manager;
    [SerializeField] private MainMenu mainMenu;
    private string saveFileName = "GameData.sav";
    private string fullSavePath;
    

    private void Awake() 
    {
        levelData = new LevelData();
        fullSavePath = Path.Combine(Application.persistentDataPath, saveFileName);

        Load();
    }

    public void Save(bool completedALevel)
    {
        if (completedALevel && levelData.completedLevels == 0 || levelData.completedLevels == SceneManager.GetActiveScene().buildIndex )
        {
            levelData.completedLevels = SceneManager.GetActiveScene().buildIndex + 1;
        }
        else
        {
            levelData.selectedLanguage = (int)manager.selectedLanguage;
        }

        StreamWriter streamWriter = null;
        try
        {
            if(!File.Exists(fullSavePath))
            {
                File.Create(fullSavePath);     
            }
            streamWriter = new StreamWriter(fullSavePath, false);
            
            streamWriter.Write(levelData.ToJson());
            Debug.Log("saved to " + fullSavePath);
        }
        catch(Exception e)
        {
            Debug.LogException(e);
        }
        finally
        {
            if(streamWriter != null)
            {
                streamWriter.Close();
            }           
        }        
    }

    public void Load()
    {
        StreamReader streamReader = null;
        try
        {
            if(File.Exists(fullSavePath))
            {
                streamReader = new StreamReader (fullSavePath);
                levelData = LevelData.FromJson(streamReader.ReadToEnd());
            }       
        }
        catch(Exception e)
        {
            Debug.LogException(e);
        }
        finally
        {
            /* if(levelData == null)
            {
                levelData = new LevelData();
            } */

            if(manager != null)
            {
                manager.selectedLanguage = (Language)levelData.selectedLanguage;
            }

            MainMenu.completedLevels = levelData.completedLevels;

            /* if(levelData.completedLevels != 0)
            {
                MainMenu.completedLevels = levelData.completedLevels;
            }
            else
            {
                levelData.completedLevels = 0;
            } */
            

            if(streamReader != null)
            {
                streamReader.Close();
            }           
        }        
    }
}
