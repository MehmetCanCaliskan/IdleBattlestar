using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_Handler : MonoBehaviour
{
    
    public GameObject UpgradeLists;

    public GameObject ProductionUpgradesSelected;
    public GameObject GeneralUpgradesSelected;

    public Text ProductionUpgradesTitleText;
    public Text GeneralUpgradesTitleText;

    public GameObject Buy1Button;
    public GameObject Buy10Button;
    public GameObject Buy50Button;
    public GameObject BuyMaxButton;
    


    public static int buyMode;
    




    void Start()
    {
        TurnOffAllUI();
        Buy1ProdUpgradeButton();
    }

    
    public void SwitchUpgrades(string location)
    {
        UpgradeManager.Instance.UpgradeHandlers[0].UpgradesScroll.gameObject.SetActive(false);
        UpgradeManager.Instance.UpgradeHandlers[1].UpgradesScroll.gameObject.SetActive(false);

        ProductionUpgradesSelected.SetActive(false);
        GeneralUpgradesSelected.SetActive(false);
        ProductionUpgradesTitleText.color = Color.gray;
        GeneralUpgradesTitleText.color = Color.gray;

        switch (location)
        {
            case "Production":
                UpgradeManager.Instance.UpgradeHandlers[0].UpgradesScroll.gameObject.SetActive(true);
                UpgradeManager.Instance.UpgradeHandlers[1].UpgradesScroll.gameObject.SetActive(false);
                ProductionUpgradesSelected.SetActive(true);
                ProductionUpgradesTitleText.color = Color.white;
                break;
            case "General":
                UpgradeManager.Instance.UpgradeHandlers[1].UpgradesScroll.gameObject.SetActive(true);
                UpgradeManager.Instance.UpgradeHandlers[0].UpgradesScroll.gameObject.SetActive(false);
                GeneralUpgradesSelected.SetActive(true);
                GeneralUpgradesTitleText.color = Color.white;
                break;
        }
    }

    public void SwitchOnOffUpgradeLists()
    {
        if (UpgradeLists.gameObject.activeSelf)
        {
            UpgradeLists.gameObject.SetActive(false);
        }
        else
        {
            UpgradeLists.gameObject.SetActive(true);
            SwitchUpgrades("Production");
            UpgradeManager.Instance.UpdateUpgradeUI("production");
        }        
    }

    

    public void TurnOffAllUI()
    {

        UpgradeLists.gameObject.SetActive(false);
    }

    public void Buy1ProdUpgradeButton()
    {
        UpgradeManager.Instance.buyMode = 1;
        AllUnclickedButtonsWhite();
        Buy1Button.GetComponent<Image>().color = Color.magenta;
        UpgradeManager.Instance.UpdateUpgradeUI("production");
    }

    public void Buy10ProdUpgradeButton()
    {
        UpgradeManager.Instance.buyMode = 10;
        AllUnclickedButtonsWhite();
        Buy10Button.GetComponent<Image>().color = Color.magenta;
        UpgradeManager.Instance.UpdateUpgradeUI("production");
        
    }

    public void Buy50ProdUpgradeButton()
    {
        UpgradeManager.Instance.buyMode = 50;
        AllUnclickedButtonsWhite();
        Buy50Button.GetComponent<Image>().color = Color.magenta;
        UpgradeManager.Instance.UpdateUpgradeUI("production");
        
    }

    public void BuyMaxProdUpgradeButton()
    {
        UpgradeManager.Instance.buyMode = 0;
        AllUnclickedButtonsWhite();
        BuyMaxButton.GetComponent<Image>().color = Color.magenta;
        UpgradeManager.Instance.UpdateUpgradeUI("production");
        
    }

    public void AllUnclickedButtonsWhite()
    {
        Buy1Button.GetComponent<Image>().color = Color.white;
        Buy10Button.GetComponent<Image>().color = Color.white;
        Buy50Button.GetComponent<Image>().color = Color.white;
        BuyMaxButton.GetComponent<Image>().color = Color.white;
    }

    
    


    

    

}
