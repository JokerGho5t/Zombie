using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New BulletData", menuName = "Bullet Data", order = 51)]
public class BulletData : ScriptableObject
{
    public GameObject PrefabBullet => _prefabBullet;
    [SerializeField]
    private GameObject _prefabBullet = null;

    public float Speed => _speed;
    [SerializeField]
    private float _speed = 0;

    public float Force => _force;
    [SerializeField]
    private float _force = 0;

    public float Lifetime => _lifetime;
    [SerializeField]
    private float _lifetime = 0;
}
