using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchColor : MonoBehaviour, IHit
{
    private Renderer render = null;

    public void Hit(Collider collider, Vector3 HitPoint, Vector3 Force)
    {
        render.material.color = Random.ColorHSV();
    }

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        Hit(null, Vector3.zero, Vector3.zero);
    }
}
