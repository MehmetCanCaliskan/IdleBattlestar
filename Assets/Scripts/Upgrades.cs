using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public int UpgradeID;
    public Text levelText;
    public Text explanationText;
    public Text costText;
    public GameObject UpgradeImage;
    public Text buyMaxCountText;
    

    private string dataFileName = "PlayerData";

    #region Singleton

    public static Upgrades Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion
    //public void BuyClickUpgrade() => UpgradeManager.Instance.BuyUpgrade("click",UpgradeID);
    public void BuyProductionUpgrade()
    {
        UpgradeManager.Instance.BuyUpgradeMax(UpgradeID);
        MoneyManager.Instance.BuxPerSecond();
        SaveSystem.SaveData(MoneyManager.data, dataFileName);

    }

    





    

}
