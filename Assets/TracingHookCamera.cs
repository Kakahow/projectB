using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracingHookCamera : MonoBehaviour
{
    /*  [SerializeField] GameObject m_Hook;
      const float Camera_rotation_speed = 10f;*/
    // Update is called once per frame
    public Transform Hook;
    void Update()
    {
        /* Vector3 diffVec = m_Hook.transform.position - this.transform.position;
         Vector2 xzProjection = new Vector2(diffVec.x, diffVec.z);
         float xyProjectedLength = xzProjection.magnitude;
         Quaternion Cameraquaternion = Quaternion.FromToRotation(Vector3.left, new Vector3(0, diffVec.y, diffVec.z));
         this.transform.localRotation = Quaternion.RotateTowards(this.transform.localRotation, Cameraquaternion, Camera_rotation_speed * Time.deltaTime);*/
        transform.LookAt(Hook);
    }
}
