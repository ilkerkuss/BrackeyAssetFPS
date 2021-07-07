using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    //Gun Attributes
    public float GunDamage = 10f;
    public float GunRange = 100f;

    public float FireRate = 15f;
    private float _nextTimeToFire = 0f;

    public int BulletAmount ;
    public int MaxBulletAmount = 30;

    //hit object
    private RaycastHit _hit;

    //Firing Effect
    public ParticleSystem MuzzleFlash;
    public GameObject ImpactEffect;
    public GameObject ImpactParent;

    //Firing Animation
    private Animator _gunAnim;

    //Firing Sound Effect
    private AudioSource _audioSource;
    public AudioClip GunSound;

    //Ammo UI 
    public Text BulletAmountText;
    public Text MaxBulletText;

    private void Start()
    {
        BulletAmount = MaxBulletAmount;
        BulletAmountText.text = BulletAmount.ToString();
        MaxBulletText.text = "/ " + MaxBulletAmount.ToString() ;

        _gunAnim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= _nextTimeToFire && BulletAmount > 0)
        {
            _nextTimeToFire = Time.time + 1 / FireRate;
            Shoot();
            _gunAnim.SetTrigger("Shoot");
        }

        if (Input.GetKeyDown(KeyCode.R) && BulletAmount < MaxBulletAmount)
        {
            BulletAmount = MaxBulletAmount;
            BulletAmountText.text = BulletAmount.ToString();
        }
        
    }

    void Shoot()
    {
        MuzzleFlash.Play();
        _audioSource.PlayOneShot(GunSound);
        BulletAmount -= 1;
        BulletAmountText.text = BulletAmount.ToString();
        //MaxBullet.text = "/ 30";

        //Debug.Log(BulletAmount);

        if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out _hit, GunRange))
        {
            Debug.Log("hit transform : "+_hit.collider);
            //Debug.Log(_hit.transform.name);
        
            Target target = _hit.transform.GetComponent<Target>();

            if (target != null)
            {
                if (target.transform.parent.name=="Zombies")
                {
                    if (_hit.collider.name=="Z_Head")
                    {
                        target.KillZombies(GunDamage*5);
                        Debug.Log(target._targetHealth);

                    }
                    target.KillZombies(GunDamage);
                    Debug.Log(target._targetHealth);
                }
                target.TakeDamage(GunDamage);
                Debug.Log(target._targetHealth);
                Debug.Log(target.transform);
                
                
            }

            if (_hit.rigidbody != null)
            {
                _hit.rigidbody.AddForce(_hit.normal * 50 * -1);
            }

            GameObject impactGO = Instantiate(ImpactEffect,_hit.point,Quaternion.LookRotation(_hit.normal));
            impactGO.transform.parent = ImpactParent.transform;
            Destroy(impactGO, 2f);

        }

    }
}
