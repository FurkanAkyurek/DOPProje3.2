using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCanvasLockScript : MonoBehaviour
{
    public Transform enemyTransform;
    Transform t;
    public float fixedRotation = 90;
    void Start()
    {
        t = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyTransform.transform.rotation.y >= 80 && enemyTransform.transform.rotation.y <= 100)
        {
            fixedRotation = 90;
            t.eulerAngles = new Vector3(t.eulerAngles.x, fixedRotation, t.eulerAngles.z);
        }else if (enemyTransform.transform.rotation.y >= 170 && enemyTransform.transform.rotation.y <= 190)
        {
            fixedRotation = 180;
            t.eulerAngles = new Vector3(t.eulerAngles.x, fixedRotation, t.eulerAngles.z);
        }
        else if (enemyTransform.transform.rotation.y >= -10 && enemyTransform.transform.rotation.y <= 10)
        {
            fixedRotation = 0;
            t.eulerAngles = new Vector3(t.eulerAngles.x, fixedRotation, t.eulerAngles.z);
        }
        else if (enemyTransform.transform.rotation.y >= 260 && enemyTransform.transform.rotation.y <= 280)
        {
            fixedRotation = 270;
            t.eulerAngles = new Vector3(t.eulerAngles.x, fixedRotation, t.eulerAngles.z);
        }


    }
}
