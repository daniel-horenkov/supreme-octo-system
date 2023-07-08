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

    private AudioSource selectSound, buySound, errorSound; 

    void Start()
    {
        selectSound = GameObject.Find("Click").GetComponent<AudioSource>();
        buySound = GameObject.Find("Buy").GetComponent<AudioSource>();
        errorSound = GameObject.Find("Error").GetComponent<AudioSource>();

        cube = GameObject.Find("Cube").GetComponent<MeshRenderer>();

        preview.sprite = skin.preview;
        textName.text = skin.skinName;

        if (!skin.owned)
            textBuyButton.text = "Buy: $" + skin.cost.ToString();
        else
            textBuyButton.text = "Select";
    }

    private void Update()
    {
        if (skin.owned)
            textBuyButton.text = "Select";
    }

    public void BuySkin()
    {
        if (!skin.owned && Money.money >= (ulong)skin.cost)
        {
            Money.money -= (ulong)skin.cost;
            skin.SaveOwn();
            textBuyButton.text = "Select";
            ChangeSkin();
            Money.Save();
            buySound.Stop(); buySound.Play();
        }
        else if (skin.owned)
        {
            ChangeSkin();
            selectSound.Stop(); selectSound.Play();
        }
        else
        {
            errorSound.Stop(); errorSound.Play();
        }
    }

    private void ChangeSkin()
    {
        PlayerPrefs.SetString("currentSkin", skin.name);
        cube.material = skin.material;
    }
}