using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityQ : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform spawnHole;
    [SerializeField] private float coolDown;
    private float cd;


    public bool Spawn()
    {
        if (Time.time > coolDown + cd)
        {
            cd = Time.time;
            Instantiate(projectile, spawnHole.position, spawnHole.rotation);
            return true;
        }
        return false;
    }




}
