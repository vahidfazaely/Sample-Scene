using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] private GameObject effect;
    [SerializeField] private float destroyTime = 3f;
    [SerializeField] private bool isSkillShot = false;
    [SerializeField] private float speed = 6f;

    private void Awake()
    {
        Destroy(gameObject, destroyTime);
    }

    private void Update()
    {
        if (isSkillShot)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }



}
