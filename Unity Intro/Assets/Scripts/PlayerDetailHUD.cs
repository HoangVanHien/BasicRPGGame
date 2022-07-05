using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDetailHUD : MonoBehaviour
{
    private Player player;

    public RectTransform hpBar;
    public Text hpText;
    public RectTransform manaBar;
    public Text manaText;
    public RectTransform xpBar;
    public Text xpText;

    private void Start()
    {
        player = GameManager.instance.player;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        UpdateDetailHUD(hpBar, hpText, player.healthpoint, player.maxHealthpoint);
        UpdateDetailHUD(manaBar, manaText, player.mana, player.maxMana);

        int currentLevel = GameManager.instance.GetCurrentLevel();
        int prevLevelXp = GameManager.instance.GetXpToLevel(currentLevel - 1);
        int curLevelXp = GameManager.instance.GetXpToLevel(currentLevel);
        UpdateDetailHUD(xpBar, xpText, GameManager.instance.experience - prevLevelXp, curLevelXp - prevLevelXp);
    }

    private void UpdateDetailHUD(RectTransform detailBar, Text detailText, int curDetail, int maxDetail)
    {
        detailBar.localScale = new Vector3((float)curDetail / (float)maxDetail, 1, 1);
        detailText.text = curDetail.ToString() + "/" + maxDetail.ToString();
    }
}
