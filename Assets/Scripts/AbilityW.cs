using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityW : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float coolDown;
    private float cd;


    public bool Spawn(Vector3 pos)
    {
        if (Time.time > coolDown + cd)
        {
            cd = Time.time;
            pos.y += .5f;
            Instantiate(projectile, pos, Quaternion.identity);
            return true;
        }
        return false;
    }


}
