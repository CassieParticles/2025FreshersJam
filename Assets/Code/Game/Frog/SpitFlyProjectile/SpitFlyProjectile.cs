using System;
using UnityEngine;

public class SpitFlyProjectile : MonoBehaviour
{
    //This gets set in the FrogAttack Script
    [NonSerialized] public int projectileDamage = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        Vector2 screenPos = Camera.main.WorldToViewportPoint(transform.position);
        //Bullet is off screen
        if (screenPos.x < 0 || screenPos.x > 1 || screenPos.y < 0 || screenPos.y > 1) {
            Destroy(gameObject);
        }
    }
}
