using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]
    private Health health = null;

    private int maxHealth;
    private int actualBlueHealth;
    private int actualRedHealth;
    private int effectiveBlueHealth;
    private int effectiveRedHealth;

    private Transform blueBar;

    private Transform redBar;

    [SerializeField]
    private int healthStep = 15;

    [SerializeField]
    private bool inverted = true;

    [SerializeField]
    private float redBarDelay = 0.8f;

    private int lastHealthValue;
    private float redBarTimeLeft;

    [SerializeField]
    private Gradient blinkColor = new Gradient();

    private Image image;

    void Start()
    {
        if (inverted)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        blueBar = transform.Find("Health");
        redBar = transform.Find("DamagedHeath");
        maxHealth = health.HP;
        actualBlueHealth = maxHealth;
        actualRedHealth = maxHealth;
        effectiveBlueHealth = maxHealth;
        effectiveRedHealth = maxHealth;
        lastHealthValue = maxHealth;
        redBarTimeLeft = redBarDelay;

        /*blinkColor.colorKeys = new GradientColorKey[]
        {
            new GradientColorKey(new Color(0.5f, 0.7f, 0.9f), 0),
            new GradientColorKey(new Color(0.6f, 0.8f, 1f), 1)
        };*/
        image = transform.Find("Health").GetComponent<Image>();
    }

    void Update()
    {
        actualBlueHealth = health.HP;
        if (RedBarShouldShrink())
        {
            actualRedHealth = actualBlueHealth;
        }
        HandleEffectiveHealth();
        HandleHealtBars();
        RecolorBlueBar();
    }

    private bool RedBarShouldShrink()
    {
        if(health.HP != lastHealthValue)
        {
            lastHealthValue = health.HP;
            redBarTimeLeft = redBarDelay;
            return false;
        }
        else
        {
            redBarTimeLeft -= Time.deltaTime;
            if(redBarTimeLeft <= 0)
            {
                redBarTimeLeft = redBarDelay;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
    private void HandleEffectiveHealth()
    {
        int newEffectiveHealth = effectiveBlueHealth - (int)Time.deltaTime * healthStep - 1;
        effectiveBlueHealth = Math.Max(actualBlueHealth, newEffectiveHealth);
        newEffectiveHealth = effectiveRedHealth - (int)Time.deltaTime * healthStep - 1;
        effectiveRedHealth = Math.Max(actualRedHealth, newEffectiveHealth);
    }

    private void HandleHealtBars()
    {
        blueBar.localScale = new Vector3((float)effectiveBlueHealth / maxHealth, 1, 1);
        redBar.localScale = new Vector3((float)effectiveRedHealth / maxHealth, 1, 1);
    }

    private void RecolorBlueBar()
    {
        image.color = blinkColor.Evaluate((Time.time * (float)maxHealth/ actualBlueHealth)%1);
    }
}
