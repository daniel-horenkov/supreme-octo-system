using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Advertisements;

public class AD : MonoBehaviour, IUnityAdsInitializationListener
{
    public static bool canWatchAD = false;

    private void Start()
    {
        canWatchAD = false;
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        Advertisement.Initialize("5318615", false, this);

        while (true)
        {
            yield return new WaitForSeconds(45);
            if (canWatchAD)
            {
                canWatchAD = false;
                Advertisement.Load("Interstitial_Android", new Interstitial());
            }
        }
    }

    public void ShowAD()
    {
        if (canWatchAD)
        {
            canWatchAD = false;
            Advertisement.Load("Rewarded_Android", new Rewarded());
        }         
    }

    public void OnInitializationComplete()
    {
        Advertisement.Load("Interstitial_Android", new Interstitial());
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        canWatchAD = true;
    }
}

public class Interstitial : IUnityAdsLoadListener, IUnityAdsShowListener
{
    public void OnUnityAdsAdLoaded(string placementId)
    {
        Advertisement.Show("Interstitial_Android", this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        AD.canWatchAD = true;
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        AD.canWatchAD = true;
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        AD.canWatchAD = true;
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        AD.canWatchAD = true;
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        AD.canWatchAD = true;
    }
}

public class Rewarded : IUnityAdsLoadListener,  IUnityAdsShowListener
{
    public void OnUnityAdsAdLoaded(string placementId)
    {
        Advertisement.Show("Rewarded_Android", this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        AD.canWatchAD = true;
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        AD.canWatchAD = true;
        Money.income += 20;
        Money.Save();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        AD.canWatchAD = true;
        Money.income += 20;
        Money.Save();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        AD.canWatchAD = true;
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        AD.canWatchAD = true;
    }
}