using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuySlot : MonoBehaviour
{
    public CubeSkin skin;

    public Image preview;
    public TextMeshProUGUI textName;

    public TextMeshProUGUI textBuyButton;
    private MeshRenderer cube;

    void Start()
    {
        cube = GameObject.Find("Cube").GetComponent<MeshRenderer>();

        preview.sprite = skin.preview;
        textName.text = skin.skinName;

        if (!skin.owned)
            textBuyButton.text = "Buy: $" + skin.cost.ToString();
        else
            textBuyButton.text = "Select";
    }

    public void BuySkin()
    {
        if (!skin.owned && Money.money >= skin.cost)
        {
            Money.money -= skin.cost;
            textBuyButton.text = "Select";
            ChangeSkin();
        }
        else
            ChangeSkin();
    }

    private void ChangeSkin()
    {
        cube.material = skin.material;
    }
}