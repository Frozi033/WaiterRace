using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using DG.Tweening;

public class StickmanCore : MonoBehaviour
{
    #region Variables
    //[Header("Core Settings")]

    public bool CanMove { get; private set; }
    public Status LifeStatus { get; private set; }
    public bool IsPlayer { get; protected set; }

    [SerializeField] private List<GameObject> _emptyTables = new List<GameObject>();
    private CharacterController _myController;
    private Animator _myAnimator;
    private Rigidbody[] _bodyRigidbodies;
    private Vector3 _velocity;
    private float _playerSpeed = 12f;
    private int _tablesCount;
    private int _randomNumber;
    private GameObject _enteredTable;
    [SerializeField] private GameObject Text;
    #endregion

    #region UnityMethods
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

    public virtual void Start()
    {
        /*for (int i = 0; i <= _tablesCount; i++)
        {
            _emptyTables.Add(GameObject.FindGameObjectWithTag("Table"));
        }*/

        _tablesCount = _emptyTables.Count + 1;
    }

    private IEnumerator _timeToDelivering()
    {
        
        yield return new WaitForSeconds(1f);
        if (LifeStatus == Status.DeliveringOrder)
        {
            Debug.Log("Ты опоздал!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerShop") && LifeStatus != Status.DeliveringOrder)
        {
            _randomNumber = Random.Range(0, _tablesCount);
            _enteredTable = _emptyTables[_randomNumber];
            _enteredTable.tag = "Delivering";
            LifeStatus = Status.DeliveringOrder;
            Debug.Log(_randomNumber);
        }
        else if (other.CompareTag("Delivering") && LifeStatus == Status.DeliveringOrder)
        {
            other.tag = "Untagged";
            LifeStatus = Status.Live;
            Text.SetActive(true);
            Debug.Log("Заказ доставлен!");
        }
    }
    #endregion

    #region Movement
    public void Move(Vector3 direction)
    {
        _myController.Move(direction * Time.deltaTime * _playerSpeed);

        MoveAnimationSpeed(direction.magnitude);

        if (direction != Vector3.zero)
            transform.forward = Vector3.SmoothDamp(transform.forward, direction, ref _velocity, 1f * Time.deltaTime);
    }
    #endregion

    #region Logic

    #endregion

    #region Physics
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
    #endregion

    #region Animations
    public void MoveAnimationSpeed(float speed)
    {
        _myAnimator.SetFloat("Speed", speed);
    }

    private void PlayAnimation(AnimationType animation)
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
        Plant
    }

    public enum Status
    {
        Live,
        Dead,
        DeliveringOrder
    }
    #endregion
}
