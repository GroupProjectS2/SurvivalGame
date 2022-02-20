using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    [Header("References")]

    public Camera cam;

    public Transform gunMuzzle;

    public GameObject hitReg;

    public GameObject laser;

    [Header("Values")]
    public float range = 100f;

    public int bullets = 6;

    public float fadeDuration = 0.3f;

    //used to delay shots/set fire rate
    public bool gunOnCooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //add ADS feature

        //detects player shoot input
        if (Input.GetKeyDown(KeyCode.Mouse0) && !gunOnCooldown && bullets > 0)
        {
            StartCoroutine(GunShoot());
        }
    }

    IEnumerator GunShoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            CreateLaser(hit.point);
            GameObject point = Instantiate(hitReg, hit.point, Quaternion.identity);
            Destroy(point.gameObject, 1);
        }
        else
        {
            CreateLaser(cam.transform.position + cam.transform.forward * range);
        }

        gunOnCooldown = true;
        yield return new WaitForSeconds(0.5f);
        gunOnCooldown = false;
    }
    //this is to show where the player is shooting (delete if needed)
    #region LaserManager

    void CreateLaser(Vector3 end)
    {

        LineRenderer lr = Instantiate(laser).GetComponent<LineRenderer>();
        lr.SetPositions(new Vector3[2] { gunMuzzle.position, end });
        StartCoroutine(FadeLaser(lr));
    }

    IEnumerator FadeLaser(LineRenderer lr)
    {
        float alpha = 1;

        while (alpha > 0)
        {
            alpha -= Time.deltaTime / fadeDuration;
            lr.startColor = new Color(lr.startColor.r, lr.startColor.g, lr.startColor.b, alpha);
            lr.endColor = new Color(lr.endColor.r, lr.endColor.g, lr.endColor.b, alpha);
            Destroy(lr.gameObject, fadeDuration + 1);
            yield return null;
        }
    }

    #endregion
}
