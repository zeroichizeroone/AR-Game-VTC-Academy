using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movekey : MonoBehaviour
{
    public float Speed = 5f;

    public void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(Horizontal, 0, Vertical);
        transform.Translate(movement * Speed * Time.deltaTime, Space.World);
        Debug.Log(transform.position);
    }

}
