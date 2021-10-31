using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public int bulletPower, bulletSpeed = 500;
    public float attackSpeed = 3f;
    public GameObject bullet, player;

    float delayShoot;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        delayShoot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        delayShoot += Time.deltaTime;
        if(Input.GetButtonDown("Fire1") && delayShoot >= attackSpeed)
        {
            Bullet(player.transform.position, bulletSpeed);
        }
    }
    public void Bullet(Vector2 playerPos, float bulletSpeed)
    {
        GameObject a = Instantiate(bullet, playerPos, Quaternion.identity);
        a.tag = "Bullet";
        a.GetComponent<Rigidbody2D>().AddForce(Vector2.right * bulletSpeed);
        StartCoroutine(DestroyBullet(a));
        delayShoot = 0f;
    }
    IEnumerator DestroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(3);
        Destroy(bullet);
    }
}
