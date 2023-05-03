using System;
using UnityEngine;

public class EasyDamageable : MonoBehaviour, IDamageable
{
    public event Action OnTakeDamage;

    public void TakeDamage(int damage)
    {
        print("I took damage");
    }
}