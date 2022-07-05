using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    //Text fields
    public Text levelText, hitpointText, goldText, upgradeCostText, xpText;

    //Logic
    private int currentCharacterSelection = 0;
    public Image characterSelectionSprite;
    public Image weaponSprite;
    public RectTransform xpBar;

    ////Character selection
    //public void OnArrowClick(bool right)
    //{
    //    if (right)
    //    {
    //        currentCharacterSelection++;
            
    //        //if we went too far
    //        if (currentCharacterSelection == GameManager.instance.playerSprites.Count)
    //        {
    //            currentCharacterSelection = 0;
    //        }

    //        OnSelectionChanged();
    //    }

    //    else
    //    {
    //        currentCharacterSelection--;

    //        //if we went too far
    //        if (currentCharacterSelection <0)
    //        {
    //            currentCharacterSelection = GameManager.instance.playerSprites.Count - 1;
    //        }

    //        OnSelectionChanged();
    //    }
    //}

    //private void OnSelectionChanged()
    //{
    //    characterSelectionSprite.sprite = GameManager.instance.playerSprites[currentCharacterSelection];
    //    GameManager.instance.player.SwapSprite(currentCharacterSelection);
    //}

    //public void OnUpgradeClick()
    //{
    //    if (GameManager.instance.TryUpgradeWeapon())
    //    {
    //        UpdateMenu();
    //    }
    //}

    //public void UpdateMenu()
    //{
    //    //Weapon
    //    int weaponLv= GameManager.instance.weapon.weaponLevel;
    //    weaponSprite.sprite = GameManager.instance.weaponSprites[weaponLv];
    //    if (weaponLv < GameManager.instance.weaponPrices.Count) upgradeCostText.text = GameManager.instance.weaponPrices[weaponLv].ToString();
    //    else upgradeCostText.text = "MAX";

    //    //Meta
    //    int currentLevel = GameManager.instance.GetCurrentLevel();

    //    levelText.text = currentLevel.ToString();
    //    hitpointText.text = GameManager.instance.player.hitpoint.ToString();
    //    goldText.text = GameManager.instance.gold.ToString();

    //    //xp bar
    //    if (currentLevel == GameManager.instance.xpTable.Count+1)
    //    {
    //        xpText.text = "Max";
    //        xpBar.localScale = Vector3.one;
    //    }
    //    else
    //    {
    //        int prevLevelXp = GameManager.instance.GetXpToLevel(currentLevel - 1);
    //        int curLevelXp = GameManager.instance.GetXpToLevel(currentLevel);

    //        int diff = curLevelXp - prevLevelXp;
    //        int curXpIntoLevel = GameManager.instance.experience - prevLevelXp;
    //        float completionRaito = (float)curXpIntoLevel / (float)curLevelXp;

    //        xpBar.localScale = new Vector3(completionRaito, 1, 1);
    //        xpText.text = curXpIntoLevel.ToString() + "/" + diff.ToString();
    //    }
    //}
}
