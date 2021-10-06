using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursoreRotation : MonoBehaviour
{
    [SerializeField]
    private float offset; // смещение по прицелу


    [Header("Weapons")]
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform shootPoint;
    [SerializeField]
    private float timeBtwShoots;
    [SerializeField]
    private float startTimeBetweenShoots;
    void Start()
    {

    }

    void Update()
    {
        // Начало скрипта смещение прицела
        Vector3 diffrence = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(diffrence.y, diffrence.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);

        Shoot();
    }

    private void Shoot()
    {


        if (timeBtwShoots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, shootPoint.position, transform.rotation);
                timeBtwShoots = startTimeBetweenShoots;
            }
        }
        else
        {
            timeBtwShoots -= Time.deltaTime;
        }
    }
}
