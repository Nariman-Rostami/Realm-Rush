using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoint = 5;
    [Tooltip("Adds amount to maxHitPoints when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;
    int currentHitPoint = 0;
    Enemy enemy;
    void Start()
    {        
        enemy = GetComponent<Enemy>();
    }
    void OnEnable()
    {
        currentHitPoint = maxHitPoint;
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }
    void ProcessHit()
    {
        currentHitPoint--;
        
        if (currentHitPoint <= 0)
        {           
            enemy.RewardGold();
            maxHitPoint += difficultyRamp;
            gameObject.SetActive(false);
        }
    }
}
