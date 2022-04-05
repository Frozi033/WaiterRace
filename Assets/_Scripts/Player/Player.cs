using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: StickmanCore
{
    [SerializeField] private GameObject Arrow;
    [SerializeField] private GameObject _tray;
    [SerializeField] private GameObject _kitchen;
    [SerializeField] private FloatingJoystick _joystick;

    private GameObject _target;
    void OnEnable()
    {
        KitchenLogic.DileveryAction += Delivery;
        Table.DileveryIsOver += DeliveryIsOver;
        _target = _kitchen;
    }
    void Update()
    {
        Move();
        ArrowDirection(Target: _target);
        Debug.Log(LifeStatus);
        
    }
    private void Move()
    {
        transform.position = new Vector3(transform.position.x, 0.3f, transform.position.z);

        Vector3 direction = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);

        Move(direction);
    }
    
    private void Delivery(GameObject Target)
    {
        //LifeStatus = Status.DeliveringOrder;
        _tray.SetActive(true);
        _target = Target;
        _myAnimator.SetBool("Delivery", true);
    }

    private void DeliveryIsOver()
    {
        _tray.SetActive(false);
        _target = _kitchen;
        _myAnimator.SetBool("Delivery", false);
    }

    private void ArrowDirection(GameObject Target)
    {
        Arrow.transform.LookAt(Target.transform);
    }
}
