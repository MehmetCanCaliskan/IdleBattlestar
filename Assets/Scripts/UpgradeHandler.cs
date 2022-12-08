using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BreakInfinity;

public class UpgradeHandler : MonoBehaviour
{
    public List<Upgrades> Upgrades;
    public Upgrades UpgradesPrefab;
    public Sprite[] UpgradeSprites;
    public ScrollRect UpgradesScroll;
    public Transform UpgradesPanel;
    public string[] UpgradeNames;
    
    public BigDouble[] UpgradesBaseCost;
    public BigDouble[] UpgradesCostMult;
    public BigDouble[] UpgradesBasePower;
    public BigDouble[] UpgradesUnlock;
    
}
