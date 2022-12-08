using System.Collections;
using System.Collections.Generic;
using BreakInfinity;
using UnityEngine;
using UnityEngine.UI;
using static BreakInfinity.BigDouble;


public class UpgradeManager : MonoBehaviour
{
    
    public int buyMode = 1;

    public UpgradeHandler[] UpgradeHandlers;
    public GameObject UpgradeList;

    float nextAction = 0.0f;
    float actionRate = 1f;

    #region Singleton

    public static UpgradeManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public void StartUpgradeManager()
    {        
        Methods.UpgradeCheck(MoneyManager.data.productionUpgradeLevel, 6);
        Methods.UpgradeCheck(MoneyManager.data.missileGunUpgradesLevel, 11);
        Methods.UpgradeCheck(MoneyManager.data.shieldUpgradesLevel, 11);


        // Production upgrades here
        UpgradeHandlers[0].UpgradeNames  = new[]                {"Missile Gun", "Shield",   "Navigation",   "Laser Cannon", "Nuclear Warhead",  "Engine",};
        UpgradeHandlers[0].UpgradesBaseCost  = new BigDouble[]  { 15,               100,    1000,           5000,           100000,             1000000  };
        UpgradeHandlers[0].UpgradesCostMult = new BigDouble[]   { 1.2,              1.2,      1.2,          1.2,            1.2,                1.2       };
        UpgradeHandlers[0].UpgradesBasePower = new BigDouble[]  { 0.1,              1,         10,          100,            1000,               100000     };
        UpgradeHandlers[0].UpgradesUnlock = new BigDouble[]     { 6,                40,        400,         2000,           40000,              400000     };
        


        // general upgrades here starts with first equipment missile gun ..

        UpgradeHandlers[1].UpgradeNames  = new[] {
            "Plastic Missile Gun",
            "Wooden Missile Gun",
            "Stone Missile Gun",
            "Bronze Missile Gun",
            "Iron Missile Gun",
            "Steel Missile Gun",
            "Platinum Missile Gun",
            "Titanium Missile Gun",
            "Golden Missile Gun",
            "Great Missile Gun",
            "Galaxy Missile Gun",
        };
        UpgradeHandlers[1].UpgradesBaseCost = new BigDouble[]   { 30, 12000, 1.5e7, 2.1e10, 3.2e13, 4.7e16, 7e19, 1e23, 1.5e26, 2.3e29, 2.9e32, };
        UpgradeHandlers[1].UpgradesUnlock = new BigDouble[]     { 5, 30, 100, 150, 200, 250, 300, 350, 400, 450, 500, };

        UpgradeHandlers[2].UpgradeNames = new[] {
            "Plastic Shield",
            "Wooden Shield",
            "Stone Shield",
            "Bronze Shield",
            "Iron Shield",
            "Steel Shield",
            "Platinum Shield",
            "Titanium Shield",
            "Golden Shield",
            "Great Shield",
            "Galaxy Shield",
        };
        UpgradeHandlers[2].UpgradesBaseCost = new BigDouble[] { 30, 12000, 1.5e7, 2.1e10, 3.2e13, 4.7e16, 7e19, 1e23, 1.5e26, 2.3e29, 2.9e32, };
        UpgradeHandlers[2].UpgradesUnlock = new BigDouble[] { 5, 50, 100, 150, 200, 250, 300, 350, 400, 450, 500, };


        CreateUpgrades(MoneyManager.data.productionUpgradeLevel, 0);
        CreateUpgrades(MoneyManager.data.missileGunUpgradesLevel, 1);
        CreateUpgrades(MoneyManager.data.shieldUpgradesLevel, 2);

        void CreateUpgrades<T>(List<T> level, int index)
        {
            for (int i = 0; i < level.Count; i++)
            {
                Upgrades upgrade = Instantiate(UpgradeHandlers[index].UpgradesPrefab, UpgradeHandlers[index].UpgradesPanel);
                upgrade.UpgradeID = i;
                upgrade.gameObject.SetActive(false);
                UpgradeHandlers[index].Upgrades.Add(upgrade);
            }
        }



        UpgradeHandlers[0].UpgradesScroll.normalizedPosition = new Vector2(0, 0);
        UpgradeHandlers[1].UpgradesScroll.normalizedPosition = new Vector2(0, 0);

        UpdateUpgradeUI("production");
        UpdateUpgradeUI("missileGun");

        Debug.Log("General Upgrade level sayýsý" + MoneyManager.data.missileGunUpgradesLevel);
        
    }



    public void Update()
    {
        if (Time.time > nextAction && UpgradeList.activeSelf)
        {
            Debug.Log("Çalýþýyor");
            Invoke("UpdateProductionUpgradesEverySceond", .1f);
            nextAction = Time.time + actionRate;
        }        
    }


    public void UpdateProductionUpgradesEverySceond()
    {
        
        // Production upgradelerini günceller. Eðer false ise UpgradesUnlock'a göre kontrol eder.
        for (int i = 0; i < UpgradeHandlers[0].Upgrades.Count; i++)
        {
            if (!UpgradeHandlers[0].Upgrades[i].gameObject.activeSelf)
            {
                UpgradeHandlers[0].Upgrades[i].gameObject.SetActive(MoneyManager.data.bux >= UpgradeHandlers[0].UpgradesUnlock[i]);
            }
            else
            {
                //Burada cost elementinin rengi mevcut paraya gore renk degistirmesi gerekiyor.
                if (MoneyManager.data.bux <= UpgradeCost("production", i))
                {
                    UpgradeHandlers[0].Upgrades[i].gameObject.transform.Find("Cost").GetComponent<Image>().color = Color.red;
                }
                else
                {
                    UpgradeHandlers[0].Upgrades[i].gameObject.transform.Find("Cost").GetComponent<Image>().color = Color.blue;
                    UpdateUpgradeUI("production");
                }
            }
        }
    }

    public void UpdateGeneralUpgradesEverySceond()
    {

        // Production upgradelerini günceller. Eðer false ise UpgradesUnlock'a göre kontrol eder.
        for (int i = 1; i < 2; i++)
        {
            
        }
    }


    // Updatelerde yazan bilgileri günceller . Açýklama, fiyat , level bilgisi gibi.
    public void UpdateUpgradeUI(string type, int UpgradeID = -1)
    {
        switch (type)
        {            
            case "production":
                if (UpgradeID == -1)
                {
                    for (int i = 0; i < UpgradeHandlers[0].Upgrades.Count; i++)
                    {
                        UpdateProductionUI(UpgradeHandlers[0].Upgrades, MoneyManager.data.productionUpgradeLevel, UpgradeHandlers[0].UpgradeNames, i, 0);
                    }                        
                }
                else UpdateProductionUI(UpgradeHandlers[0].Upgrades, MoneyManager.data.productionUpgradeLevel, UpgradeHandlers[0].UpgradeNames, UpgradeID , 0);
                break;
            case "missileGun":
                if (UpgradeID == -1)
                {
                    for (int i = 0; i < UpgradeHandlers[1].Upgrades.Count; i++)
                    {
                        UpdateGeneralUI(UpgradeHandlers[1].Upgrades,  UpgradeHandlers[1].UpgradeNames, i, 1);
                    }
                }
                else UpdateGeneralUI(UpgradeHandlers[1].Upgrades, UpgradeHandlers[1].UpgradeNames, UpgradeID, 1);
                break;
        }
        
        void UpdateProductionUI<T>(List<Upgrades> upgrades,List<T> upgradeLevels, string[] upgradeNames, int ID, int handlersNo )
        {
            upgrades[ID].explanationText.text =""+ upgradeNames[ID] ;
            upgrades[ID].UpgradeImage.GetComponent<Image>().sprite = UpgradeHandlers[handlersNo].UpgradeSprites[ID];
            upgrades[ID].buyMaxCountText.text = "Buy " + UpgradeMaxCount(ID);
            upgrades[ID].costText.text = $"{UpgradeCost(type, ID).Notate(1)}";
            upgrades[ID].levelText.text = "Lv. " + upgradeLevels[ID].ToString();
        }

        void UpdateGeneralUI(List<Upgrades> upgrades, string[] upgradeNames, int ID, int handlersNo)
        {
            upgrades[ID].explanationText.text = "" + upgradeNames[ID];
            upgrades[ID].UpgradeImage.GetComponent<Image>().sprite = UpgradeHandlers[handlersNo].UpgradeSprites[ID];
            upgrades[ID].costText.text = $"{UpgradeHandlers[handlersNo].UpgradesBaseCost[ID].Notate(1)}";
        }
    }

    





    void UpgradeEquipmentUnlockSystem(BigDouble currency, BigDouble[] unlock , int index)
    {
        for (var i = 0; i < UpgradeHandlers[index].Upgrades.Count; i++)
        {
            
            if (!UpgradeHandlers[index].Upgrades[i].gameObject.activeSelf)
            {
                UpgradeHandlers[index].Upgrades[i].gameObject.SetActive(currency >= unlock[i]);
            }
        }
    }

    public BigDouble UpgradeCost(string type,int UpgradeID) {

        //var b = productionUpgradesBaseCost[UpgradeID];
        //var c = MoneyManager.data.bux;
        //var r = productionUpgradesCostMult[UpgradeID];
        //var k = MoneyManager.data.productionUpgradeLevel[UpgradeID];

        //BigDouble n = CalculateBuyCount(c, r, b, k);
        //var cost = b * (Pow(r, k) * (Pow(r, n) - 1) / (r - 1));

        switch (type)
        {
            case "production":
                return UpgradeHandlers[0].UpgradesBaseCost[UpgradeID] * BigDouble.Pow(UpgradeHandlers[0].UpgradesCostMult[UpgradeID], (BigDouble)MoneyManager.data.productionUpgradeLevel[UpgradeID]);
            //return cost;
              
        }

        return 0;  
        
    }


    public BigDouble UpgradeMaxCount(int ID)
    {
        var b = UpgradeHandlers[0].UpgradesBaseCost[ID];
        var c = MoneyManager.data.bux;
        var r = UpgradeHandlers[0].UpgradesCostMult[ID];
        var k = MoneyManager.data.productionUpgradeLevel[ID];
        //var n = Floor(Log((c * (r - 1)) / (b * Pow(r, k)) + 1, r));
        BigDouble n = CalculateBuyCount(c,r,b,k);

        
        return n;
    }

    public void BuyUpgradeMax(int ID)
    {
        var b = UpgradeHandlers[0].UpgradesBaseCost[ID];
        var c = MoneyManager.data.bux;
        var r = UpgradeHandlers[0].UpgradesCostMult[ID];
        var k = MoneyManager.data.productionUpgradeLevel[ID];

        BigDouble n = CalculateBuyCount(c, r, b, k) ;
        var cost = b * (Pow(r, k) * (Pow(r, n) - 1) / (r - 1));

        if (MoneyManager.data.bux >= cost)
        {
            MoneyManager.data.productionUpgradeLevel[ID] += (int)n;
            MoneyManager.data.bux -= cost;
            CheckProductionLevels(MoneyManager.data.productionUpgradeLevel[ID] , ID);


        }
        UpdateUpgradeUI("production");
    }

    public BigDouble CalculateBuyCount(BigDouble c, BigDouble r, BigDouble b, BigDouble k)
    {
        BigDouble n = 0;
        switch (buyMode)
        {
            case 0:
                n = Floor(Log((c * (r - 1)) / (b * Pow(r, k)) + 1, r));
                break;
            case 1:
                n = 1;
                break;
            case 10:
                if ((int)k % 10 != 0)
                {
                    BigDouble max = Floor(Log((c * (r - 1)) / (b * Pow(r, k)) + 1, r));
                    n =   10 - ((int)k % 10);
                    if (n>max)
                    {
                        n = max;
                    }
                }
                else n = 10;
                break;
            case 50:
                if ((int)k % 50 != 0)
                {
                    BigDouble max = Floor(Log((c * (r - 1)) / (b * Pow(r, k)) + 1, r));
                    n =  50 - ((int)k % 50);
                    if (n > max)
                    {
                        n = max;
                    }
                }
                else n = 50;
                break;
        }
        return n;
    }

    public void CheckProductionLevels(int level, int ID)
    {
        
        for (int i = 0; i < UpgradeHandlers[ID + 1].UpgradesUnlock.Length; i++)
        {
            UpgradeHandlers[ID+1].Upgrades[i].gameObject.SetActive(level >= UpgradeHandlers[ID + 1].UpgradesUnlock[i]);
            Debug.Log("UpgradeManager / CheckProductionLevels " + level);
            if (MoneyManager.data.missileGunUpgradesLevel[i] <= 1)
            {
                MoneyManager.data.missileGunUpgradesLevel[i] = 1;
            }
            
        }
    }

    //public void BuyUpgrade(string type, int UpgradeID)
    //{
    //    switch (type)
    //    {
            
    //        case "production":
    //            Buy(MoneyManager.data.productionUpgradeLevel);
    //            break;
    //    }


    //    void Buy(List<int> upgradeLevels)
    //    {
    //        if (MoneyManager.data.bux >= UpgradeCost(type, UpgradeID))
    //        {
    //            MoneyManager.data.bux -= UpgradeCost(type, UpgradeID);

    //            upgradeLevels[UpgradeID] += 1;
    //        }
    //    }
    //    UpdateUpgradeUI(type, UpgradeID);
    //}


    
}
