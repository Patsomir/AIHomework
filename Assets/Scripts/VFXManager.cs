using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    private ParticleSystem blood = null;
    private MonkEvents events = null;

    [SerializeField]
    private float damageShakeInstensity = 0.05f;

    [SerializeField]
    private float deathShakeInstensity = 0.5f;

    [SerializeField]
    private float damageShakeDuration = 0.1f;

    [SerializeField]
    private float deathShakeDuration = 0.5f;

    void Start()
    {
        blood = GetComponent<ParticleSystem>();
    }

    public void DisplayBlood()
    {
        blood.Play();
    }

    public void DamageShake()
    {
        ScreenShaker.ShakeScreen(damageShakeInstensity, damageShakeDuration);
    }

    public void DeathShake()
    {
        ScreenShaker.ShakeScreen(deathShakeInstensity, deathShakeInstensity);
    }

    public void OnEnable()
    {
        events = GetComponentInParent<MonkEvents>();
        events.OnTakeDamage += DisplayBlood;
        events.OnTakeDamage += DamageShake;
        events.OnDeath += DeathShake;
    }

    private void OnDisable()
    {
        events = GetComponentInParent<MonkEvents>();
        events.OnTakeDamage -= DisplayBlood;
        events.OnTakeDamage -= DamageShake;
        events.OnDeath -= DeathShake;
    }
}
