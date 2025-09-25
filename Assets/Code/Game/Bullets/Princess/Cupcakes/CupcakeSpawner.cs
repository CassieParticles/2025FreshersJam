using System;
using UnityEngine;

public class CupcakeSpawner : MonoBehaviour
{
    private BulletManager bulletManager;

    private void Awake()
    {
        bulletManager = GetComponent<BulletManager>();
    }
}
