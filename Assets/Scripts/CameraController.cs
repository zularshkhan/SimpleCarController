using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float followspeed;
    public float lookspeed;

    void looktarget()
    {
        Vector3 lookposition = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(lookposition, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, lookspeed * Time.fixedDeltaTime);
    }

    void movetarget()
    {
        Vector3 moveposition = target.position + (target.forward * offset.z) + (target.right * offset.x) + (target.up * offset.y);
        transform.position = Vector3.Lerp(transform.position, moveposition, followspeed * Time.fixedDeltaTime);
    }
    private void FixedUpdate()
    {
        looktarget();
        movetarget();
    }
}
