using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public GameObject ZombieBody;
    public GameObject ZombieHead;
    public int ZombieHealth;

    public void TakeDamage(int damage)
    {
        if (ZombieBody)
        {
            ZombieHealth -= damage;
        }
        else
        {
            ZombieHealth -= damage*5;
        }
        

    }
 
}
