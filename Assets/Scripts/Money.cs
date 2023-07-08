using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class Money : MonoBehaviour
{
    public static int income = 1;
    public static ulong money;
    public static int upgradeCost;
    public static int level = 1;

    [SerializeField] private AudioSource buy, buyError, click;

    public TextMeshProUGUI incomeText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI upgradeCostText;

    public Animator cube;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        income = PlayerPrefs.GetInt("income", 1);
        money = ulong.Parse(PlayerPrefs.GetString("money", "0"));
        upgradeCost = PlayerPrefs.GetInt("upgradeCost", 10);
        level = PlayerPrefs.GetInt("level", 1);
    }

    public void CubeClick()
    {
        money += (ulong)income;
        cube.Play("cube_click");
        click.Stop(); click.Play();
        Save();
    }

    public void UpgradeIncome()
    {
        if(money >= (ulong)upgradeCost)
        {
            buy.Stop(); buy.Play();

            income += level;
            money -= (ulong)upgradeCost;

            MoneyCheck();
        }
        else
        {
            buyError.Stop(); buyError.Play();
        }

        Save();
    }

    void MoneyCheck()
    {
        if (upgradeCost < 100)
        {
            upgradeCost += 10; level = 1;
        }
        else if (upgradeCost >= 100 && upgradeCost < 1000)
        {
            upgradeCost += 100; level = 3;
        }
        else if (upgradeCost >= 1000)
        {
            upgradeCost += 500; level = 5;
        }
        else if (upgradeCost >= 5000)
        {
            upgradeCost += 1000; level = 10;
        }
        else if (upgradeCost >= 10000)
        {
            upgradeCost += 2500; level = 15;
        }
    }

    public static void Save()
    {
        PlayerPrefs.SetInt("income", income);
        PlayerRating.ReportIncomeScore(income);

        PlayerPrefs.SetString("money", money.ToString());
        PlayerPrefs.SetInt("upgradeCost", upgradeCost);
        PlayerPrefs.SetInt("level", level);
    }

    void Update()
    {
        moneyText.text = money.ToString();
        incomeText.text = "Income: $" + income.ToString();
        upgradeCostText.text = "UPGRADE INCOME: $" + upgradeCost.ToString();
    }
}
