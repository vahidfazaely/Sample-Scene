using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private Collider ground;



    private Camera cam;
    private static Manager _instance;

    private void Awake()
    {
        cam = Camera.main;
    }

    public static Manager instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<Manager>();
            return _instance;
        }
    }

    public Vector3 mousePos
    {
        get
        {
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            ground.Raycast(ray, out RaycastHit hit, Mathf.Infinity);
            if (hit.point.x >= 1000)
                return Vector3.zero;
            return hit.point;
        }
    }


}
