using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public int light, medium, heavy;
    public float speed = 5f;
    public float explosionRadius = 0f;
    public GameObject impactEffect;

    public int damage = 50;

    public void Seek(Transform _target)
    {
        target=_target;
    }

    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized*distanceThisFrame,Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        
        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            if (Enemy.enemyType == "Light")
            {
                e.TakeDamage(damage + light);
            }
            else if (Enemy.enemyType == "Medium")
            {
                e.TakeDamage(damage + medium);
            }
            else if (Enemy.enemyType == "Heavy")
            {
                e.TakeDamage(damage + heavy);
            }

        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
