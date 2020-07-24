using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(MeshRenderer))]
public class LaserSight : MonoBehaviour
{
    private LineRenderer line = null;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    public void SetLaserSight(Vector3 StartPoint, Vector3 EndPoint, Vector3 vectorNormal)
    {
        line?.SetPosition(0, StartPoint);
        line?.SetPosition(1, EndPoint);

        transform.position = EndPoint;
        transform.rotation = Quaternion.FromToRotation(-Vector3.forward, vectorNormal);
    }
}
