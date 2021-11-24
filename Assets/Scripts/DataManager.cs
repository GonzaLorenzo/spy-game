using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class DataManager : MonoBehaviour
{
    private LevelData levelData;
    public LanguageManager manager;
    private string saveFileName = "LevelData.sav";
    private string fullSavePath;

    private void Awake() 
    {
        levelData = new LevelData();
        fullSavePath = Path.Combine(Application.persistentDataPath, saveFileName);

        Load();
    }
    public void Save()
    {
        levelData.language = (int)manager.selectedLanguage;
        
        StreamWriter streamWriter = null;
        try
        {
            if(!File.Exists(fullSavePath))
            {
                File.Create(fullSavePath);     
            }
            streamWriter = new StreamWriter(fullSavePath, false);
            
            streamWriter.Write(levelData.ToJson());

            
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
            if(levelData == null)
            {
                levelData = new LevelData();
            }
            
            manager.selectedLanguage = (Language)levelData.language;

            if(streamReader != null)
            {
                streamReader.Close();
            }           
        }        
    }
}
