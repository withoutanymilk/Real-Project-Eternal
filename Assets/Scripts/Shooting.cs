using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;

    public GameObject bulletPreFab;

    public GameObject bulletFlash;

    public float bulletForce = 20f;

    public float firerate = 15f;
    
    private float nextTimeToFire = 0f;

    public int maxAmmo = 18;

    public int currentAmmo;

    public float reloadTime = 1f;

    private bool isReloading = false;

    public Animator animator;

    public Text ammoUi;

    void Start()
    {

        if (currentAmmo == -1)

            currentAmmo = maxAmmo;
    }

    void OnEnable()
    {
        isReloading = false;

        animator.SetBool("Reloading", false);
    }

    void Update()
    {
        if (isReloading)
            return;

        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            if(currentAmmo == maxAmmo){
                return;
            }
            else {
                StartCoroutine(Reload());

                return;
            }
        }

        if (currentAmmo <= 0f)
        {
            StartCoroutine(Reload());

            return;
        }
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            FindObjectOfType<AudioManager>().Play("FiringHandGun");
            nextTimeToFire = Time.time + 1f / firerate;
            Shoot();
        }

        updateUI();

    }

    IEnumerator Reload()
    {

        FindObjectOfType<AudioManager>().Play("ReloadingHandGun");

        isReloading = true;

        Debug.Log("Reloading...");

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .25f);

        animator.SetBool("Reloading", false);

        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;

        isReloading = false;
    }

    void Shoot()
    {
        currentAmmo--;
        GameObject bullet = Instantiate(bulletPreFab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        GameObject flash = Instantiate(bulletFlash, firePoint.position, firePoint.rotation);
    }

    void updateUI()
    {
        ammoUi.text = ("Ammo: " + currentAmmo + "/" + "Infinite");
    }
}

