using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacgkround : MonoBehaviour
{
    [SerializeField] private float followSpeed;
    [SerializeField] private float yOffset;
    [SerializeField] private Transform target;


    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -11f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}