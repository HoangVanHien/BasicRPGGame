using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUpgradeMenu : MonoBehaviour
{
    public Text attackText;
    public Text priceText;

    public void OnUpgradeClick()
    {
        if (GameManager.instance.TryUpgradeWeapon())
        {
            UpdateMenu();
        }
    }

    public void UpdateMenu()
    {
        priceText.text = "Gold: " + GameManager.instance.gold.ToString() + " / " + GameManager.instance.weaponPrice.ToString();

        attackText.text = "ATK: " + GameManager.instance.weapon.damagePoint.ToString();
    }
}
