using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

//using DG.Tweening;

public class StickmanCore : MonoBehaviour
{
    #region Variables
    //[Header("Core Settings")]

    public bool CanMove { get; private set; }
    public Status LifeStatus { get; private set; }
    public bool IsPlayer { get; protected set; }

    [SerializeField] private GameObject _tray;
    [SerializeField] private GameObject _text;
    private CharacterController _myController;
    private Rigidbody[] _bodyRigidbodies;
    private Vector3 _velocity;
    private float _timePause = 5f;
    private GameObject _coin;
    
    [SerializeField] protected float _speedBonus = 2f;
    [SerializeField] protected List<GameObject> _emptyTables = new List<GameObject>();
    protected float _mySpeed = 10f;
    protected int _randomNumber;
    protected Animator _myAnimator;
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
        
    }
    
    private IEnumerator _timeToDelivering()
    {
        
        yield return new WaitForSeconds(1f);
        _text.SetActive(false);
    }
    
    private IEnumerator _timeSpeedBonus()
    {
        
        yield return new WaitForSeconds(3f);
        _mySpeed = 10f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerShop") && LifeStatus != Status.DeliveringOrder)
        {
            _randomNumber = Random.Range(0, _emptyTables.Count);
            _emptyTables[_randomNumber].gameObject.tag = "Delivering";
            LifeStatus = Status.DeliveringOrder;
            _myAnimator.SetBool("Delivery", true);
            _tray.SetActive(true);
        }
        else if (other.CompareTag("Delivering") && LifeStatus == Status.DeliveringOrder)
        {
            other.tag = "Untagged";
            LifeStatus = Status.Live;
            _text.SetActive(true);
            _tray.SetActive(false);
            StartCoroutine(_timeToDelivering());
            _myAnimator.SetBool("Delivery", false);
        }
        else if (other.CompareTag("SpeedCoin") && _mySpeed == 10f)
        {
            _mySpeed = _mySpeed * _speedBonus;
            StartCoroutine(_timeSpeedBonus());
            StartCoroutine(_pauseCoin());
            other.gameObject.SetActive(false);
            _coin = other.gameObject;
        }
    }
    
    private IEnumerator _pauseCoin()
    {
        yield return new WaitForSeconds(_timePause);
        _coin.SetActive(true);
    }
    #endregion

    #region Movement
    public void Move(Vector3 direction)
    {
        _myController.Move(direction * Time.deltaTime * _mySpeed);

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
    #endregion
}
