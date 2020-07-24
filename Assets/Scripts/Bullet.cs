using System.Collections;
using System.Collections.Generic;
using JokerGho5t.MessageSystem;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private BulletData _data = null;

    private Vector3 _target;

    private float CurTime = 0.0f;

    public void Init(BulletData Data, Vector3 Target)
    {
        if (Data == null)
            Destroy(gameObject);

        _data = Data;
        _target = Target;
        transform.LookAt(Target);
    }

    private void Start()
    {
        if (_data == null)
            Destroy(gameObject);
    }

    
    void Update()
    {
        CurTime += Time.deltaTime;

        if (CurTime <= _data.Lifetime)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target, _data.Speed * Time.deltaTime);
        }
        else if(CurTime > _data.Lifetime || transform.position == _target)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var hit = other.GetComponentInParent<IHit>();

        if (hit != null)
        {
            hit.Hit(other, transform.position, transform.forward * _data.Force);
        }
        else
        {
            other.attachedRigidbody?.AddForceAtPosition(_data.Force * transform.forward, transform.position);
        }


        Destroy(gameObject);
    }
}
