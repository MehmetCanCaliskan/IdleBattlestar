using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;
using UnityEngine.UI;


public class OfflineManager : MonoBehaviour
{
    public Text GainText;

    public GameObject offlinePopup;
    

    public void LoadOfflineProduction()
    {
        if (MoneyManager.data.bux > 0)
        {
            // Offline time management
            var tempOfflineTime = Convert.ToInt64(MoneyManager.data.timebeforeCloseApp);
            var oldTime = DateTime.FromBinary(tempOfflineTime);
            var currentTime = DateTime.Now;

            var difference = currentTime.Subtract(oldTime);
            var rawTime = (float)difference.TotalSeconds;
            var offlineTime = rawTime / 10;

            offlinePopup.gameObject.SetActive(true);

            BigDouble gainedBux = MoneyManager.Instance.BuxPerSecond() * offlineTime;
            MoneyManager.data.bux += gainedBux;
            GainText.text = $"Welcome Back !\n\n\n While you were away,\n\n You earned:\n\n+{Methods.Notate(gainedBux, 2)} Bux\n\n Would you like to double it ?";

            Debug.Log("OfflineManager Time Difference = " + difference);
        }
    }

    public void YesDoubleButton()
    {

        offlinePopup.gameObject.SetActive(false);
    }
    public void NoDoubleButton()
    {
        offlinePopup.gameObject.SetActive(false);
    }
}
