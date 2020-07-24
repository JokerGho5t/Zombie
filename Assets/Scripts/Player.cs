using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    #region Public Variables

    public Transform TargetAim = null;

    #endregion

    #region SerializeField Variables

    [SerializeField]
    private BulletData LazyBullerData = null;
    [SerializeField]
    private BulletData LargeBullerData = null;
    [SerializeField]
    private BulletData HulkBullerData = null;
    [SerializeField]
    private Transform SpawnPointBullet = null;
    [SerializeField]
    private LaserSight laser = null;

    #endregion

    #region Private Variables

    private Camera mainCamera = null;
    private Vector3 TargetBullet;
    private Animator anim = null;
    private BulletData targetData;

    #endregion

    #region Standart Unity Events

    private void OnEnable()
    {
        if (!CheckVariables())
            return;

        mainCamera = Camera.main;
        targetData = LazyBullerData;

        if (anim == null)
            anim = GetComponent<Animator>();

        ControlSystem.OnUpdate += OnUpdate;
    }

    private void OnDisable()
    {
        ControlSystem.OnUpdate -= OnUpdate;
    }

    #endregion

    #region Priivate Functions

    private void OnUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            targetData = LazyBullerData;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            targetData = LargeBullerData;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            targetData = HulkBullerData;
        }

        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        ShowAim();
    }

    private void Shoot()
    {
        anim.SetTrigger("Shoot");

        var Bullet = Instantiate(targetData.PrefabBullet, SpawnPointBullet.position, SpawnPointBullet.rotation).GetComponent<Bullet>();
        Bullet.Init(targetData, TargetBullet);
    }

    private void ShowAim()
    {
        RaycastHit hit;

        var Ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(Ray, out hit, 1000))
        {
            TargetBullet = hit.point;

            TargetAim.position = hit.point;

            laser.SetLaserSight(SpawnPointBullet.transform.position, hit.point, hit.normal);
        }
    }

    private bool CheckVariables()
    {
        if (LazyBullerData == null || LargeBullerData == null || HulkBullerData == null)
        {
            Debug.LogError("Data is null!");
            enabled = false;
        }
        else if (SpawnPointBullet == null)
        {
            Debug.LogError("SpawnPointBullet is null!");
            enabled = false;
        }
        else if (laser == null)
        {
            Debug.LogError("LaserSight is null");
            enabled = false;
        }
        else if(TargetAim == null)
        {
            Debug.LogError("TargetAim is null");
            enabled = false;
        }

        return enabled;
    }

    #endregion
}
