using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Aether
{
    public class CoinTextManager : MonoBehaviour
    {
        // Start is called before the first frame update

        public Inventory playerInventory;
        public TextMeshProUGUI coinDisplay;
        public void UpdateCoinsCount()
        {

            coinDisplay.text = "" + playerInventory.coins;
        }
    }
}
