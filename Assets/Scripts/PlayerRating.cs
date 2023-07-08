using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerRating : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentPlaceTextIncome, currentPlaceTextCharity;
    [SerializeField] private Transform top10ListIncome, top10ListCharity;

    public void Start()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate(result => { });
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
        Social.ShowLeaderboardUI();
    }
}
