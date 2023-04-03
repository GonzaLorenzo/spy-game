using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public enum Language
{
    eng,
    spa
}
public class LanguageManager : MonoBehaviour
{
    [SerializeField] private DataManager dataManager;
    public Language selectedLanguage;
    public Dictionary<Language, Dictionary<string,string>> languageManager;
    public string externalURL ="https://docs.google.com/spreadsheets/d/e/2PACX-1vTFaQCJSbAfB0Rlmnrqz_QTLnT0zaJXx5At5Lst01DqN9wb6dCWxsrasmRi8ED1zYdDelGJ4nrovMi8/pub?output=csv";
    public event Action onUpdate = delegate { };
    private void Start()
    {  
        StartCoroutine(DownloadCSV(externalURL));
    }


    public void ChangeLanguageReference()
    {
        if((selectedLanguage == Language.eng))
        {
        selectedLanguage = Language.spa;
        //levelData.language = 1;
        dataManager.Save(false);
        }
        else
        {           
        selectedLanguage = Language.eng;
        //levelData.language = 0;
        dataManager.Save(false);
        }

        onUpdate();
    }

    public string GetTranslate(string id)
    {
        if(!languageManager[selectedLanguage].ContainsKey(id))
        {
            return "Not Found";
        }
        else
        {
            return languageManager[selectedLanguage][id];
        }
    }

    IEnumerator DownloadCSV (string url)
    {
        var www = new UnityWebRequest(url);
        www.downloadHandler = new DownloadHandlerBuffer();

        yield return www.SendWebRequest();

        languageManager = LanguageU.LoadCodexFromString("www",www.downloadHandler.text);

        onUpdate();
    }
}
