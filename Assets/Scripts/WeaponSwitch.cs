using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitch : MonoBehaviour
{
    public int SelectedWeapon=0;

    //Ammo UI 
    public Text BulletAmountText;
    public Text MaxBulletText;

    void Start()
    {
        SelectWeapon();
    }


    void Update()
    {
        int previousSelectedWeapon = SelectedWeapon;

        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (SelectedWeapon >= transform.childCount-1)
            {
                SelectedWeapon = 0;
            }
            else
            {
                SelectedWeapon++;
            }   
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0) 
        {
            if (SelectedWeapon <= 0)
            {
                SelectedWeapon = transform.childCount-1;
            }
            else
            {
                SelectedWeapon--;
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectedWeapon = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount>=2) 
        {
            SelectedWeapon = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            SelectedWeapon = 2;
        }

        if (previousSelectedWeapon !=  SelectedWeapon)
        {
            SelectWeapon();
        }

    }

    void SelectWeapon()
    {
        int i=0;
        foreach (Transform weapon in transform)
        {
            if (i==SelectedWeapon)
            {
                weapon.gameObject.SetActive(true);

                BulletAmountText.text = weapon.GetComponent<Gun>().BulletAmount.ToString();
                MaxBulletText.text = "/ "+weapon.GetComponent<Gun>().MaxBulletAmount.ToString();

            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
