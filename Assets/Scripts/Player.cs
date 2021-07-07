using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float PlayerMaxHealth = 100;
    public float CurrentHealth;

    public float PlayerMaxStamina = 250f;
    public float CurrentStamina;

    public HealthBar PlayerHealthBar;
    public StaminaBar PlayerStaminaBar;
    
    

    private void Start()
    {
        CurrentHealth = PlayerMaxHealth;
        CurrentStamina = PlayerMaxStamina;

        PlayerHealthBar.SetMaxHealth(PlayerMaxHealth);
        PlayerStaminaBar.SetMaxStamina(PlayerMaxStamina);
    }

    private void Update()
    {

       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
            UseStamina(3500);

        }else if (CurrentHealth < 0)
        {
            CurrentHealth = 0;
        }
        else if (CurrentHealth > PlayerMaxHealth)
        {
            CurrentHealth = PlayerMaxHealth;
        }
        RegenHealth();
        //Debug.Log(CurrentHealth);




        if (Input.GetKey(KeyCode.LeftShift) && CurrentStamina > 0)
        {
            UseStamina(10);
            Debug.Log(CurrentStamina);

        }else if (CurrentStamina < 0)
        {
            CurrentStamina = 0;
           
        }else if (CurrentStamina >PlayerMaxStamina)
        {
            CurrentStamina = PlayerMaxStamina;
        }

        RegenStamina();
        //Debug.Log(CurrentStamina);

        
    }

    void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        PlayerHealthBar.SetHealth(CurrentHealth);
    }

    void UseStamina(int amount)
    {
        CurrentStamina -= amount * Time.deltaTime;
        PlayerStaminaBar.SetStamina(CurrentStamina);
    }

    void RegenStamina()
    {
        CurrentStamina += 3 * Time.deltaTime ;
        PlayerStaminaBar.SetStamina(CurrentStamina);
    }
    void RegenHealth()
    {
        CurrentHealth += 1 * Time.deltaTime;
        PlayerHealthBar.SetHealth(CurrentHealth);
    }
}
