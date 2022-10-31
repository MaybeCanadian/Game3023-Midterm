using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlcPackageStatusController : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]
    private Slider healthSlider;
    [SerializeField]
    private TMP_Text healthText;

    [SerializeField]
    private int startingHealth = 100;
    [SerializeField]
    private int currentHealth = 100;

    [Header("Mana")]
    [SerializeField]
    private Slider manaSlider;
    [SerializeField]
    private TMP_Text manaText;

    [SerializeField]
    private int startingMana = 100;
    [SerializeField]
    private int currentMana = 100;

    [Header("Stamina")]
    [SerializeField]
    private Slider staminaSlider;
    [SerializeField]
    private TMP_Text staminaText;

    [SerializeField]
    private int startingStamina = 100;
    [SerializeField]
    private int currentStamina = 100;

    [Header("Stats")]
    [SerializeField]
    private TMP_Text strengthText;
    [SerializeField]
    private int strengthValue = 10;
    [SerializeField]
    private TMP_Text dexterityText;
    [SerializeField]
    private int dexterityValue = 10;
    [SerializeField]
    private TMP_Text inteligenceText;
    [SerializeField]
    private int inteligenceValue = 10;
    [SerializeField]
    private TMP_Text defenceText;
    [SerializeField]
    private int defenceValue = 10;
    [SerializeField]
    private TMP_Text staminaStatText;
    [SerializeField]
    private int staminaStatValue = 10;

    private void LateUpdate()
    {
        UpdateHealth();
        UpdateMana();
        UpdateStamina();
        UpdateStats();
    }

    private void UpdateHealth()
    {
        healthSlider.value = (float)currentHealth / (float)startingHealth;
        healthText.text = currentHealth.ToString() + "/" + startingHealth.ToString();
    }

    private void UpdateMana()
    {
        manaSlider.value = (float)currentMana / (float)startingMana;
        manaText.text = currentMana.ToString() + "/" + startingMana.ToString();
    }

    private void UpdateStamina()
    {
        staminaSlider.value = (float)currentStamina / (float)startingStamina;
        staminaText.text = currentStamina.ToString() + "/" + startingStamina.ToString();
    }

    private void UpdateStats()
    {
        strengthText.text = strengthValue.ToString();
        dexterityText.text = dexterityValue.ToString();
        inteligenceText.text = inteligenceValue.ToString();
        defenceText.text = defenceValue.ToString();
        staminaStatText.text = staminaStatValue.ToString();
    }
}
