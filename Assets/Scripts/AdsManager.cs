using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener 
{
	public Button myButton;
	private string gameId = "3937299";
	private string myPlacementId  = "rewardedVideo";

    void Start()
    {
    	myButton.interactable = Advertisement.IsReady (myPlacementId); 
    	if (myButton) myButton.onClick.AddListener (ShowRewardedVideo);

    	Advertisement.AddListener (this);
     	Advertisement.Initialize(gameId, false);
    }

    public void ShowRewardedVideo()
    {
		Advertisement.Show(myPlacementId);
    }

    public void OnUnityAdsReady (string placementId) {
        if (placementId == myPlacementId) {        
            myButton.interactable = true;
        }
    }

    public void OnUnityAdsDidFinish (string placementId, ShowResult showResult) {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished) {
            //SceneManager.LoadScene("Stages");
            GameManager.Instance.reset = false;
            SceneManager.LoadScene("Stages");
            //GameObject.Find("Scene Controller").GetComponent<SceneController>().BackToGameScene();

            // Reward the user for watching the ad to completion.
        } else if (showResult == ShowResult.Skipped) {
            // Do not reward the user for skipping the ad.
        } else if (showResult == ShowResult.Failed) {
            Debug.LogWarning ("The ad did not finish due to an error.");
        }
    }
    public void OnUnityAdsDidError (string message) {
        // Log the error.
    }

    public void OnUnityAdsDidStart (string placementId) {
        // Optional actions to take when the end-users triggers an ad.
    } 
}
