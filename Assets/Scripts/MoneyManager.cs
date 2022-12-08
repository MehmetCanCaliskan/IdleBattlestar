using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BreakInfinity;



public class MoneyManager : MonoBehaviour
{

    public static Data data;
    public OfflineManager offline;


    public UpgradeManager upgradeManager;

    [SerializeField] private Text buxText;
    [SerializeField] private Text buxPerSecondText;
    
    
    #region Singleton

    public static MoneyManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public static string dataFileName = "Mokoko12";

    private void Start()
    {
        data = SaveSystem.SaveExists(dataFileName) ? SaveSystem.LoadData<Data>(dataFileName) : new Data();
        //ResetData();
        Debug.Log("MoneyManager data.bux = " + data.bux);
        upgradeManager.StartUpgradeManager();
        
        BuxPerSecond();
        offline.LoadOfflineProduction();
        
    }

    public float SaveTime;

    private void Update()
    {
        Debug.Log("data.buxpersecond :" + data.buxPerSecond);
        buxText.text = $"{data.bux.Notate(1)}";
        buxPerSecondText.text = $"{data.buxPerSecond.Notate(1)}/s";
        GenerateMoney();
        

        SaveTime += Time.deltaTime;
        if (SaveTime >= 8)
        {
            data.timebeforeCloseApp = DateTime.Now.ToBinary().ToString();
            SaveSystem.SaveData(data, dataFileName);
            Debug.Log("data saved."+data.timebeforeCloseApp);
            SaveTime = 0;

        }
    }

    public BigDouble BuxPerSecond()
    {
        data.buxPerSecond = 0;

        for (int i = 0; i < data.productionUpgradeLevel.Count; i++)
        {
            data.buxPerSecond += UpgradeManager.Instance.UpgradeHandlers[0].UpgradesBasePower[i] * data.productionUpgradeLevel[i] ;
        }
        SaveSystem.SaveData(data, dataFileName);
        return data.buxPerSecond;
    }

    // this function should be written in start() after  data = SaveSystem.SaveExists(dataFileName) ? SaveSystem.LoadData<Data>(dataFileName) : new Data();
    public void ResetData()
    {
        
        for (int i = 0; i < data.productionUpgradeLevel.Count; i++)
        {
            data.productionUpgradeLevel[i] = 0;
        }

        data.buxPerSecond = 0;
        data.bux = 0;
        SaveSystem.SaveData(data, dataFileName);
    }
    


    // generates money +0,1 with a multiplier
    public void GenerateMoney()
    {
        data.bux += BuxPerSecond()*Time.deltaTime;
    }

    

    

}
