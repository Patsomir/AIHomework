using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private MonkEvents events = null;

    [SerializeField]
    private AudioSource punchSound = null;

    [SerializeField]
    private AudioSource flyingKickSound = null;

    [SerializeField]
    private AudioSource lowKickSound = null;

    [SerializeField]
    private AudioSource hurtSound = null;

    [SerializeField]
    private AudioSource deathSound = null;

    public void PlayPunchSound()
    {
        if (punchSound != null)
        {
            punchSound.Play();
        }
    }

    public void PlayHurtSound()
    {
        if (hurtSound != null)
        {
            hurtSound.Play();
        }
    }

    public void PlayDeathSound()
    {
        if (deathSound != null)
        {
            deathSound.Play();
        }
    }

    public void PlayFlyingKickSound()
    {
        if (flyingKickSound != null)
        {
            flyingKickSound.Play();
        }
    }

    public void PlayLowKickSound()
    {
        if (lowKickSound != null)
        {
            lowKickSound.Play();
        }
    }

    private void OnEnable()
    {
        events = GetComponentInParent<MonkEvents>();
        events.OnPunch += PlayPunchSound;
        events.OnTakeDamage += PlayHurtSound;
        events.OnDeath += PlayDeathSound;
        events.OnJumpKick += PlayFlyingKickSound;
        events.OnLowKick += PlayLowKickSound;
    }

    private void OnDisable()
    {
        events = GetComponentInParent<MonkEvents>();
        events.OnPunch -= PlayPunchSound;
        events.OnTakeDamage -= PlayHurtSound;
        events.OnDeath -= PlayDeathSound;
        events.OnJumpKick -= PlayFlyingKickSound;
        events.OnLowKick -= PlayLowKickSound;
    }
}
