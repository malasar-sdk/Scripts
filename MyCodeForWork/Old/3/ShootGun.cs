using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject posBull;

    public int maxAmmo = 15;
    public int currentAmmo;

    public float fireRate = 15f;
    public float nextTimeToFire = 0f;

    public float reloadTime = 2;
    private bool isReloading = false;

    public AudioSource shootSound;
    public AudioSource ammoEndSound;
    public AudioSource reloadSound;

    static public int ammoOridg;

    void Start()
    {
        currentAmmo = maxAmmo;
        ammoOridg = currentAmmo;
    }

    void Update()
    {
        if (isReloading)
        {
            return;
        }

        if (currentAmmo <= 0 && PlayerSystematic.ammoPlayerMove > 0 || Input.GetButtonDown("Reload"))
        {
            reloadSound.Play();
            StartCoroutine(Reload());

            ammoOridg -= currentAmmo;

            return;
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && currentAmmo > 0 && !Input.GetKey(KeyCode.LeftShift))
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            --currentAmmo;
            Shoot();
            ammoOridg = currentAmmo;
        }
    }

    IEnumerator Reload()
    {
        reloadSound.Play();

        isReloading = true;
        yield return new WaitForSeconds(reloadTime);

        if (PlayerSystematic.ammoPlayerMove < 15  && PlayerSystematic.ammoPlayerMove > 0)
        {
            currentAmmo = PlayerSystematic.ammoPlayerMove;
            PlayerSystematic.ammoPlayerMove = 0;
            ammoOridg = currentAmmo;
        }
        else if (PlayerSystematic.ammoPlayerMove == 0)
        {
            currentAmmo = 0;
            ammoOridg = currentAmmo;
        }
        else
        {
            currentAmmo = maxAmmo;
            PlayerSystematic.ammoPlayerMove -= currentAmmo;
            ammoOridg = currentAmmo;
        }
        isReloading = false;
    }

    void Shoot()
    {
        GameObject bulletObject = Instantiate(bulletPrefab);
        bulletObject.transform.position = posBull.transform.position + posBull.transform.forward;
        bulletObject.transform.forward = posBull.transform.forward;

        shootSound.Play();
    }
}
