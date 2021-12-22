using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : StickmanCore
{
    [SerializeField] private GameObject Arrow;
    [SerializeField] private FloatingJoystick Joystick;
    void Start()
    {
        
    }
    void Update()
    {
        Move();
        ArrowDirection();
        
    }
    private void Move()
    {
        transform.position = new Vector3(transform.position.x, 0.3f, transform.position.z);

        /*if (!CanMove || LifeStatus == Status.Dead)
            return;*/

        Vector3 direction = new Vector3(Joystick.Horizontal, 0, Joystick.Vertical);

        Move(direction);
    }

    private void ArrowDirection()
    {
        if (LifeStatus == Status.DeliveringOrder)
        {
            Arrow.transform.LookAt(GameObject.FindGameObjectWithTag("Delivering").transform);
        }
        else if (LifeStatus == Status.Live)
        {
            Arrow.transform.LookAt(GameObject.FindGameObjectWithTag("PlayerShop").transform);
        }
    }
}
