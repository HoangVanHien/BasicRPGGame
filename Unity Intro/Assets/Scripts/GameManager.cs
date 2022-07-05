using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (GameManager.instance != null)//if there is already a GameManager
        {
            Destroy(gameObject);//Destroy the new GameManager that being duplicated
            Destroy(player.gameObject);
            Destroy(floatingTextManager.gameObject);
            return;
        }
        instance = this;//To make all the instance being call become this
        //DontDestroyOnLoad(gameObject);//prevent this gameObject (GameManager) from being deleted when load a new scene
    }

    //game
    public EndGame endGame;

    //ressources
    //public List<Sprite> playerSprites;
    //public List<Sprite> weaponSprites;
    public int weaponPrice = 40;
    public List<int> xpTable;

    //references
    public Player player;
    public Weapon weapon;
    public FloatingTextManager floatingTextManager;

    //index
    public int gold;
    public int experience;
    
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    public bool TryUpgradeWeapon()
    {
        if(gold >= weaponPrice)
        {
            gold -= weaponPrice;
            weaponPrice += 50;
            weapon.UpgradeWeapon();
            return true;
        }

        return false;
    }

    public int GetCurrentLevel()
    {
        int lv = 0;
        int xp = 0;
        for (; experience >= xp; lv++)
        {
            if (lv == xpTable.Count+1) break;
            xp += xpTable[lv];
        }
        return lv;
    }

    public int GetXpToLevel(int level)
    {
        int lv = 0;
        int xp = 0;
        for (; lv < level; lv++)
        {
            xp += xpTable[lv];
        }
        return xp;
    }

    public void GrantXp(int xp)
    {
        int curLevel = GetCurrentLevel();
        experience += xp;
        if (curLevel < GetCurrentLevel())
        {
            OnLevelUp();
        }
    }

    public void OnLevelUp()
    {
        player.OnLevelUp();
    }

    //SaveState
    //Skin, Gold, Exp, weaponLv
    //public void SaveState()
    //{
    //    string s = "";

    //    s += "0" + "|";
    //    s += gold.ToString() + "|";
    //    s += experience.ToString() + "|";
    //    s += weapon.weaponLevel.ToString() +"|";

    //    PlayerPrefs.SetString("SaveState", s);
    //    Debug.Log("SaveState");
    //}

    //public void LoadState(Scene s, LoadSceneMode mode)
    //{
    //    //SceneManager.sceneLoaded -= LoadState;//prevent sceneLoaded from duplicate LoadState twice

    //    if (!PlayerPrefs.HasKey("SaveState")) return;

    //    string[] data = PlayerPrefs.GetString("SaveState").Split('|');//split the whole string with '|'
    //    gold = int.Parse(data[1]);

    //    experience = int.Parse(data[2]);
    //    player.SetLevel(GetCurrentLevel());

    //    weapon.SetWeaponLevel(int.Parse(data[3]));
    //    Debug.Log("LoadState");

    //    player.transform.position = GameObject.Find("SpawnPlace").transform.position;
    //    GameObject.Find("Generator").GetComponentInChildren<MapGenerator>().DifficultyMapGenerate(difficulty);
    //}
}
