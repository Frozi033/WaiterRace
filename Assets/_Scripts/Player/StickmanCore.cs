using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterController))]
public class StickmanCore : MonoBehaviour
{
    //[Header("Core Settings")]

    public bool CanMove { get; private set; }
    public static Status LifeStatus { get; set; }
    public bool IsPlayer { get; protected set; }
    
    private CharacterController _myController;
    private Rigidbody[] _bodyRigidbodies;
    private Vector3 _velocity;

    [SerializeField] private float _speedBonus = 2f;
    private float _mySpeed = 10f;
    protected int _randomNumber;
    protected Animator _myAnimator;



    public virtual void Awake()
    {
        _myAnimator = GetComponent<Animator>();
        _bodyRigidbodies = GetComponentsInChildren<Rigidbody>();
        _myController = GetComponent<CharacterController>();

        CanMove = true;
        LifeStatus = Status.Live;
        
        SetRagdollActive(false);
        ChangeMass(20f);
    }
    
    public void Move(Vector3 direction)
    {
        _myController.Move(direction * Time.deltaTime * _mySpeed);

        MoveAnimationSpeed(direction.magnitude);

        if (direction != Vector3.zero)
            transform.forward = Vector3.SmoothDamp(transform.forward, direction, ref _velocity, 1f * Time.deltaTime);
    }

    public void SetRagdollActive(bool active)
    {
        for (int i = 0; i < _bodyRigidbodies.Length; i++)
            _bodyRigidbodies[i].isKinematic = !active;
    }

    private void ChangeMass(float mult)
    {
        for (int i = 0; i < _bodyRigidbodies.Length; i++)
            _bodyRigidbodies[i].mass *= mult;
    }


    public void MoveAnimationSpeed(float speed)
    {
        _myAnimator.SetFloat("Speed", speed);
    }

    /*private void PlayAnimation(AnimationType animation)
    {
        foreach (var item in System.Enum.GetNames(typeof(AnimationType)))
            _myAnimator.ResetTrigger(item);

        _myAnimator.Play(animation.ToString());
    }
    #endregion

    #region Enums
    public enum AnimationType
    {
        Move,
        Delivering
    }*/

    public enum Status
    {
        Live,
        DeliveringOrder
    }

}
