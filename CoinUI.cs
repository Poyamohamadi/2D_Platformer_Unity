using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
	public static System.Action<int> OnPlayerGrabbedCoin;
	 
	TMPro.TextMeshProUGUI CoinText;
	
    void Start()
    {
	    CoinUI.OnPlayerGrabbedCoin += funcOnPlayerGrabbedCoin;
	    CoinText = GameObject.Find("CoinUI/Text").GetComponent<TMPro.TextMeshProUGUI>();
	    
	    CoinText.SetText( Player.CoinAmount.ToString() );
    }

	void funcOnPlayerGrabbedCoin( int CoinAmount )
	{
		CoinText.SetText( CoinAmount.ToString() );
	}
}
