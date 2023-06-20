using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class Money : MonoBehaviour
{
    public static int income = 1;
    public static int money;
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
        money = PlayerPrefs.GetInt("money", 0);
        upgradeCost = PlayerPrefs.GetInt("upgradeCost", 10);
        level = PlayerPrefs.GetInt("level", 1);
    }

    public void CubeClick()
    {
        money += income;
        cube.Play("cube_click");
        click.Stop(); click.Play();
        Save();
    }

    public void UpgradeIncome()
    {
        if(money >= upgradeCost)
        {
            buy.Stop(); buy.Play();

            income += level;
            money -= upgradeCost;

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
        }
        else
        {
            buyError.Stop(); buyError.Play();
        }


        Save();
    }

    public static void Save()
    {
        PlayerPrefs.SetInt("income", income);
        PlayerPrefs.SetInt("money", money);
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
