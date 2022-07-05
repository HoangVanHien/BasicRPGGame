using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUpgradeMenu : MonoBehaviour
{
    public Text attackText;
    public Text priceText;

    private void Start()
    {
        UpdateMenu();
    }

    public void OnUpgradeClick()
    {
        if (GameManager.instance.TryUpgradeWeapon())
        {
            UpdateMenu();
        }
    }

    private void UpdateMenu()
    {
        int weaponLv = GameManager.instance.weapon.weaponLevel;
        if (weaponLv < GameManager.instance.weaponPrices.Count) priceText.text = "Price: " + GameManager.instance.weaponPrices[weaponLv].ToString();
        else priceText.text = "MAX";

        attackText.text = "ATK: " + GameManager.instance.weapon.damagePoint.ToString();
    }
}
