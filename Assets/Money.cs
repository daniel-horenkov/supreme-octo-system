using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public int income = 1;
    public int money;
    public int upgradeCost;
    public int level = 1;

    public TextMeshProUGUI incomeText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI upgradeCostText;

    public Animator cube;

    public void CubeClick()
    {
        money += income;
        cube.Play("cube_click");
    }

    public void UpgradeIncome()
    {
        if(money >= upgradeCost)
        {
            income += level;
            money -= upgradeCost;

            if (upgradeCost < 100)
            {
                upgradeCost += 10; level = 1;
            }
            else if (upgradeCost >= 100 && upgradeCost < 1000)
            {
                upgradeCost += 100; level = 5;
            }
            else if (upgradeCost < 1000)
            {
                level = 10;
            }
        }
    }

    void Update()
    {
        moneyText.text = money.ToString();
        incomeText.text = "Income: $" + income.ToString();
        upgradeCostText.text = "UPGRADE INCOME: $" + upgradeCost.ToString();
    }
}
