using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void Update()
    {
        GetComponent<CharacterController>().Move(Vector3.Normalize(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0)) * Time.deltaTime * speed);
    }
}
