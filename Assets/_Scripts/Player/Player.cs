using UnityEngine;

public class Player: StickmanCore
{
    [SerializeField] private GameObject Arrow;
    [SerializeField] private GameObject _tray;
    [SerializeField] private GameObject _kitchen;
    [SerializeField] private FloatingJoystick _joystick;

    private Vector3 _target;
    private Vector3 _kitchenPos;
    void OnEnable()
    {
        KitchenLogic.DileveryAction += Delivery;
        Table.DileveryIsOver += DeliveryIsOver;
        _kitchenPos = _kitchen.transform.position;
        _target = _kitchenPos;
    }
    void Update()
    {
        Move();
        ArrowDirection(_target);

    }
    private void Move()
    {
        transform.position = new Vector3(transform.position.x, 0.3f, transform.position.z);

        Vector3 direction = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);

        Move(direction);
    }
    
    private void Delivery(Vector3 Target)
    {
        LifeStatus = Status.DeliveringOrder;
        _tray.SetActive(true);
        _target = Target;
        _myAnimator.SetBool("Delivery", true);
    }

    private void DeliveryIsOver()
    {
        LifeStatus = Status.Live;
        _tray.SetActive(false);
        _target = _kitchen.transform.position;
        _myAnimator.SetBool("Delivery", false);
    }

    private void ArrowDirection(Vector3 Target)
    {
        Arrow.transform.LookAt(Target);
    }
}
