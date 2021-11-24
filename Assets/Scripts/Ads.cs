using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{
    [SerializeField]
    private AdTypes adTypes;
    private string adTypeName;
    void Start()
    {
        #if UNITY_EDITOR
        Advertisement.Initialize("4470972", true);
        #else
        Advertisement.Initialize("4470972", false);
        #endif
        adTypeName = adTypes.ToString();
        StartCoroutine(WaitForAd());
    }

    private IEnumerator WaitForAd()
    {
        while (!Advertisement.IsReady(adTypeName))
        {
            yield return null;
        }

        ShowOptions options = new ShowOptions { resultCallback = AdFinished };

        Advertisement.Show(adTypeName, options);
    }

    void AdFinished(ShowResult result)
    {
        Debug.Log(result.ToString());

        if (result == ShowResult.Finished)
        {
            //Rewards
        }
    }
}
