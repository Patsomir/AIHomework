using JetBrains.Annotations;
using System;
using UnityEngine;

public class MonkEvents : MonoBehaviour
{
    public Action OnTakeDamage = null;

    public Action OnDeath = null;

    public Action OnPunch = null;

    public Action OnLowKick = null;

    public Action OnJumpKick = null;
}
