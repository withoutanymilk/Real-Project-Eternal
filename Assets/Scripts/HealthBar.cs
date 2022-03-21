using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private Slider healthBar;
    public Image fillImage;
    public PlayerHealth playerHealth;

    [SerializeField]
    public Text healthText;


    // Start is called before the first frame update
    void Awake()
    {
        healthBar = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar.value <= healthBar.minValue)
        {
            fillImage.enabled = false;
        }
        if (healthBar.value > healthBar.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }
        float fillValue = playerHealth.maxHealth / playerHealth.currentHealth;

        if (fillValue <= healthBar.maxValue / 3)
        {
            fillImage.color = Color.red;
        }
        else if (fillValue > healthBar.maxValue / 3)
        {
            fillImage.color = Color.green;
        }
        healthBar.value = fillValue;

        healthText.text = healthBar.value.ToString("0");
    }
}
