using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerRating : MonoBehaviour
{
    [SerializeField] private GameObject incomeAward, charityAward;

    public void Start()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate(result => { });
        StartCoroutine(FirstPlaceLoader());
    }

    public static void ReportIncomeScore(int score)
    {
        Social.ReportScore(score, "CgkIldSyv7IcEAIQAQ", result => { });
    }

    public static void ReportCharityScore(ulong score)
    {
        Social.ReportScore((long)score, "CgkIldSyv7IcEAIQAg", result => { });
    }

    public void LoadLeaderboard()
    {
        StopAllCoroutines();
        StartCoroutine(FirstPlaceLoader());
        Social.ShowLeaderboardUI();
    }

    private IEnumerator FirstPlaceLoader()
    {
        //Income
        Social.LoadScores("CgkIldSyv7IcEAIQAQ", result => CheckList(result, incomeAward));
        //Charity
        Social.LoadScores("CgkIldSyv7IcEAIQAg", result => CheckList(result, charityAward));

        yield return new WaitForEndOfFrame();
    }

    private void CheckList(IScore[] scores, GameObject bg)
    {
        if (scores[1].userID == Social.localUser.id)
            bg.SetActive(true);
        else
            bg.SetActive(false);
    }
}
