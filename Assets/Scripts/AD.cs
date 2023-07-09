using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AD : MonoBehaviour
{
    private bool canShowAD;

    [Header("Interstitial")]
    [SerializeField] private string interstitialID;
    private InterstitialAd interstitialAd;

    [Header("Rewarded")]
    [SerializeField] private string rewardedID;
    private RewardedAd rewardedAd;

    private void Start()
    {
        canShowAD = false;
        MobileAds.Initialize(result => { });
        LoadInterstitial();
        LoadRewarded();
        StartCoroutine(AdTimer());
    }

    private IEnumerator AdTimer()
    {
        yield return new WaitForSeconds(1);
        canShowAD = true;
        ShowInterstitial();

        while (true)
        {
            yield return new WaitForSeconds(15);
            ShowInterstitial();
        }
    }

    private void LoadInterstitial()
    {
        interstitialAd = null;

        InterstitialAd.Load(interstitialID, new AdRequest(), (InterstitialAd ad, LoadAdError loadAdError) =>
        {
            interstitialAd = ad;
        });
    }

    private void ShowInterstitial()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            if (canShowAD)
            {
                canShowAD = false;
                interstitialAd.Show();
            }
        }
        canShowAD = true;
        LoadInterstitial();
    }

    private void LoadRewarded()
    {
        rewardedAd = null;

        RewardedAd.Load(rewardedID, new AdRequest(), (RewardedAd ad, LoadAdError loadAdError) =>
        {
            rewardedAd = ad;
        });
    }

    public void ShowRewarded()
    {
        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            if (canShowAD)
            {
                canShowAD = false;
                rewardedAd.Show(callback => 
                {
                    if (callback.Amount > 0)
                    {
                        Money.income += 20;
                        Money.Save();
                    }
                });
            }
        }
        canShowAD = true;
        LoadRewarded();
    }
}
