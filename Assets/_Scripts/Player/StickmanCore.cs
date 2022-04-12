using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class StickmanCore : TableList
{
    //[Header("Core Settings")]

    public bool CanMove { get; private set; }
    public static Status LifeStatus { get; set; }
    public bool IsPlayer { get; protected set; }
    
    private CharacterController _myController;
    private Vector3 _velocity;

    [SerializeField] private float _speedBonus = 2f;
    private float _mySpeed = 10f;
    protected Animator _myAnimator;



    public virtual void Awake()
    {
        _myAnimator = GetComponent<Animator>();
        _myController = GetComponent<CharacterController>();

        CanMove = true;
        LifeStatus = Status.Live;
    }
    
    protected void Move(Vector3 direction)
    {
        _myController.Move(direction * Time.deltaTime * _mySpeed);

        MoveAnimationSpeed(direction.magnitude);

        if (direction != Vector3.zero)
            transform.forward = Vector3.SmoothDamp(transform.forward, direction, ref _velocity, 1f * Time.deltaTime);
    }
    
    protected void MoveAnimationSpeed(float speed)
    {
        _myAnimator.SetFloat("Speed", speed);
    }

    public enum Status
    {
        Live,
        DeliveringOrder
    }

}
