using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : StickmanCore
{
    void Start()
    {
        
    }
    void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.position = new Vector3(transform.position.x, 0.3f, transform.position.z);

        /*if (!CanMove || LifeStatus == Status.Dead)
            return;*/

        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Move(direction);
    }
}
