using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Monetization;

public class AD : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Timer());
        StartCoroutine(AdCooldown());
    }

    public void ShowAD()
    {
        Advertisement.Load("Rewarded_Android", new Rewarded());
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);

        Advertisement.Initialize("5317868", testMode: false);

        yield return new WaitForSeconds(1);

        if (Advertisement.isInitialized)
            Advertisement.Load("Interstitial_Android", new Interstitial());
    }

    private IEnumerator AdCooldown()
    {
        while (true) 
        {
            yield return new WaitForSeconds(45);

            Advertisement.Load("Interstitial_Android", new Interstitial());
        }
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
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
    }

    public void OnUnityAdsShowStart(string placementId) 
    {
    }
    public void OnUnityAdsShowClick(string placementId) 
    {
    }
}

public class Rewarded : IUnityAdsLoadListener, IUnityAdsShowListener
{
    public void OnUnityAdsAdLoaded(string placementId)
    {
        Advertisement.Show("Rewarded_Android", this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
    }

    public void OnUnityAdsShowStart(string placementId) 
    {
        Money.money += 999;
        Money.Save();
    }
    public void OnUnityAdsShowClick(string placementId) 
    {
    }
}
