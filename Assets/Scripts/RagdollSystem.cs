using JokerGho5t.MessageSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IHit
{
    void Hit(Collider collider, Vector3 HitPoint, Vector3 Force);
}


public class RagdollSystem : MonoBehaviour, IHit
{
    [SerializeField]
    private GameObject HitParticale = null;

    private Rigidbody[] rigidbodies;
    private Animator anim = null;
    

    private void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        anim = GetComponent<Animator>();

        OffRagdoll();
    }

    private void OffRagdoll()
    {
        anim.enabled = true;

        foreach (var item in rigidbodies)
        {
            item.isKinematic = true;
        }
    }

    private void OnRagdoll()
    {
        anim.enabled = false;

        foreach (var item in rigidbodies)
        {
            item.isKinematic = false;
        }
    }

    public void Hit(Collider collider, Vector3 HitPoint, Vector3 Force)
    {
        OnRagdoll();

        collider.attachedRigidbody.AddForce(Force, ForceMode.Impulse);

        if (HitParticale != null)
            Instantiate(HitParticale, HitPoint, Quaternion.FromToRotation(Vector3.right, -Force));

        if (Random.Range(0, 100) <= 30)
            Message.Send("SlowTime");

        StartCoroutine(RestartPosition());
    }

    IEnumerator RestartPosition()
    {
        yield return new WaitForSeconds(3.0f);

        OffRagdoll();
    }
}
