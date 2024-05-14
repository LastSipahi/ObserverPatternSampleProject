using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour, IDamageable
{
    [SerializeField] float MyHP;
    public static Action OnEnemyDestroyed;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        MyHP -= amount;
        if (MyHP <= 0)
        { 
            KillMe();
        }
    }
    void KillMe()
    { 
        OnEnemyDestroyed?.Invoke();
        gameObject.SetActive(false);
    }
}
