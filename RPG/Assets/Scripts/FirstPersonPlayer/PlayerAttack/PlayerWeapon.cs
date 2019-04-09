using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject fireBallPrefab;

    public Transform FirePoint;
    public float bulletSpeed;
    public float lifeTime = 3;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }

    }

    private void Fire()
    {
        GameObject fireBall = Instantiate(fireBallPrefab);
        Physics.IgnoreCollision(fireBall.GetComponent<Collider>(), FirePoint.parent.GetComponent<Collider>());

        fireBall.transform.position = FirePoint.position;

        Vector3 rotation = fireBall.transform.rotation.eulerAngles;

        fireBall.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);

        fireBall.GetComponent<Rigidbody>().AddForce(FirePoint.forward * bulletSpeed, ForceMode.Impulse);

        StartCoroutine(DestroySpellAfterTime(fireBall, lifeTime));
    }

    private IEnumerator DestroySpellAfterTime (GameObject fireBall, float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(fireBall);
    }
}
