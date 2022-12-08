using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using BreakInfinity;
using System;

[Serializable]
public class Data
{
    // to count time for offline profress
    public string timebeforeCloseApp;
    public BigDouble bux;
    public BigDouble buxPerSecond;
    

    //public List<int> clickUpgradeLevel;
    public List<int> productionUpgradeLevel;
    public List<int> missileGunUpgradesLevel;
    public List<int> shieldUpgradesLevel;



    public Data()
    {
        bux = 0;
        buxPerSecond = 0;
        
        // kac tane upgrade olmasýný istiyorsan buraya yazman gerekiyor.
        productionUpgradeLevel = new int[6].ToList();
        missileGunUpgradesLevel = new int[11].ToList();
        shieldUpgradesLevel = new int[11].ToList();
    }
    
}
