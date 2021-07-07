using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float _targetHealth = 50f;

    public void TakeDamage(float amount)
    {
        _targetHealth -= amount;

        if (_targetHealth <=0)
        {
            Destroy(gameObject);
        }

    }
    public void KillZombies(float amount)
    {
        _targetHealth -= amount;

        if (_targetHealth <= 0)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
    private void Update()
    {
        
    }
}
