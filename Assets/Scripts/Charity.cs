using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Charity : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private AudioSource errorSound, buySound;

    public void OnSendButtonClick()
    {
        try
        {
            var value = ulong.Parse(inputField.text);
            if (value <= Money.money)
            {
                Money.money -= value;
                Money.Save();

                ulong charity = ulong.Parse(PlayerPrefs.GetString("charity", "0"));
                charity += value;
                PlayerRating.ReportCharityScore(charity);
                PlayerPrefs.SetString("charity", charity.ToString());

                buySound.Stop(); buySound.Play();
            }
            else
            {
                errorSound.Stop(); errorSound.Play();
            }
        }
        catch
        {
            errorSound.Stop();
            errorSound.Play();
        }
    }
}
