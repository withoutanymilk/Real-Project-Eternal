using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotGun : MonoBehaviour
{
    public Transform firePoint;

    public GameObject bulletPreFab;

    public GameObject bulletFlash;

    public float bulletForce = 20f;

    public float firerate = 2f;

    private float nextTimeToFire = 0f;

    public int ClipAmmo = 10;

    public int MaxAmmo = 60;

    public int MaxClip;

    public GameObject CurrentWeapon;

    private bool isReloading = false;

    private bool CanShoot = true;

    private int AmmoDifference;

    public Animator animator;

    public float reloadTime = 1f;

    public Text ammoUi;
    // Start is called before the first frame update
    void Start()
    {
        MaxClip = ClipAmmo;
    }
    void OnEnable()
    {
        isReloading = false;

        animator.SetBool("Reloading", false);
    }

    // Update is called once per frame
    void Update()
    {

        if (isReloading)
            return;

        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            CanShoot = false;
            StartCoroutine(Reload());

            return;
        }

        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
        {


            if (ClipAmmo > 0)
            {
                FindObjectOfType<AudioManager>().Play("FiringShotGun");
                nextTimeToFire = Time.time + 1f / firerate;
                Fire();
            }
            else if (ClipAmmo <= 0)
            {
                StartCoroutine(Reload());

                return;

            }
        }

        updateUI();

    }
    void Fire()
    {
        if (ClipAmmo > 0 && CanShoot)
        {
            //CurrentWeapon.GetComponent<Animator>().Play("HandGunRecoil");
            ClipAmmo = ClipAmmo - 1;

                GameObject bullet = Instantiate(bulletPreFab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                GameObject flash = Instantiate(bulletFlash, firePoint.position, firePoint.rotation);

        }
    }
    IEnumerator Reload()
    {

        CanShoot = false;

        if (ClipAmmo == 0)
        {
            if (MaxAmmo >= MaxClip)
            {
                FindObjectOfType<AudioManager>().Play("ReloadingShotGun");

                isReloading = true;

                Debug.Log("Reloading...");

                animator.SetBool("Reloading", true);

                yield return new WaitForSeconds(reloadTime - .25f);

                animator.SetBool("Reloading", false);

                yield return new WaitForSeconds(.25f);

                ClipAmmo = MaxClip;

                MaxAmmo = MaxAmmo - MaxClip;

                isReloading = false;

            }
            else
            {
                Debug.Log("not enough bullets to reload");
                FindObjectOfType<AudioManager>().Play("NoAmmo");

            }

        }
        else
        {
            AmmoDifference = MaxClip - ClipAmmo;
            if (MaxAmmo < AmmoDifference)
            {
                Debug.Log("Not Enough to reload");
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("ReloadingShotGun");

                isReloading = true;

                Debug.Log("Reloading...");

                animator.SetBool("Reloading", true);

                yield return new WaitForSeconds(reloadTime - .25f);

                animator.SetBool("Reloading", false);

                yield return new WaitForSeconds(.25f);

                ClipAmmo = ClipAmmo + AmmoDifference;
                MaxAmmo = MaxAmmo - AmmoDifference;

                isReloading = false;
            }
        }
        CanShoot = true;
    }
    void updateUI()
    {
        ammoUi.text = ("Ammo: " + ClipAmmo + "/" + MaxAmmo);
    }
}
