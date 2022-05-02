using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
	[SerializeField]
	private PlayerMovement playerMovement;
    public GameObject UIParent;
	public Text boostTimerUI;
	
    // Start is called before the first frame update
    void Awake()
    {
        boostTimerUI.text = playerMovement.boostTimer.ToString("F0");
    }

    // Update is called once per frame
    void Update()
    {
        if ( playerMovement.boosting == true )
		{
			UIParent.SetActive(true);
			boostTimerUI.text = playerMovement.boostTimer.ToString("F0");
		}
		else
			UIParent.SetActive(false);	
    }
}
