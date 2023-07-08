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

    public static void ReportCharityScore(int score)
    {
        long lastScore = 0;

        Social.LoadScores("CgkIldSyv7IcEAIQAg", result =>
        {
            foreach (var id in result) 
            {
                if (id.userID == PlayGamesPlatform.Instance.localUser.id)
                    lastScore = id.value; break;
            }
        });

        Social.ReportScore(score + lastScore, "CgkIldSyv7IcEAIQAg", result => { });
    }

    public void LoadIncomeLeaderboard()
    {
        Social.LoadScores("CgkIldSyv7IcEAIQAQ", result => List(result, ref currentPlaceTextIncome, 1));
    }

    public void LoadCharityLeaderboard()
    {
        Social.LoadScores("CgkIldSyv7IcEAIQAg", result => List(result, ref currentPlaceTextCharity, 2));
    }

    private void List(IScore[] data, ref TextMeshProUGUI currentPlaceText, int j) //1 = income 2 = charity
    {
        long[] top10Scores = new long[10];
        for (long i = 0; i < data.Length; i++)
        {
            top10Scores[i] = data[i].rank;
        }

        string[] IDs = new string[data.Length];
        for (long i = 0; i < data.Length; i++) 
        {
            IDs[i] = data[i].userID;
            if (data[i].userID == PlayGamesPlatform.Instance.localUser.id)
                currentPlaceText.text = "Your place is: #" + data[i].rank;
        }

        Social.LoadUsers(IDs, result => SetList(top10Scores, result, j));
    }

    private void SetList(long[] top, IUserProfile[] result, int j)
    {
        Transform list;
        if (j == 1)
            list = top10ListIncome;
        else
            list = top10ListCharity;

        for (int i = 0; i < 10; i++)
        {
            string placement = result[i].userName + " " + top[i];

            list.GetChild(i).GetComponent<TextMeshProUGUI>().text = placement;
        }
    }
}
