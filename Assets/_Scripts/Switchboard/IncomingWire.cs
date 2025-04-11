using System;
using System.Collections.Generic;
using UnityEngine;

using static Rope;

public class IncomingWire : MonoBehaviour  /*, IPointerClickHandler*/
{

    [Header("---- Rope ----")]
    [SerializeField] private int _numOfRopeSegments = 20;
    [SerializeField] private float _ropeSegmentLength = 0.225f;
    [SerializeField] private List<GameObject> _bones = new List<GameObject>();
    [SerializeField] private List<Bone> _listOfBones = new List<Bone>();

    [Header("---- Physics ----")]
    [SerializeField] private Vector2 _gravity = new Vector2(0, -6.81f);
    [SerializeField] private float _dampingFactor = 0.98f;//optional

    [Header("---- Constraints ----")]
    [SerializeField] private int _numOfConstraintRuns = 25;
    private LightsSlot[] _lightSlots;

    private Vector3 _ropeStartPoint;

    [Header("---- Incoming Wire ----")]

    private Switchboard2 _switchboard2;
    [SerializeField] private IncomingJack[] _incomingJacks;

    [SerializeField] private Vector3 _wireOffsetIncoming = new Vector3(0.01f, -0.65f, 0.0f);
    [SerializeField] private Vector3 _incomingJackOffset = new Vector3( 0.0f, .85f, 0.0f);
    [SerializeField] private GameObject _outgoingWire;
    [SerializeField] private bool _isWireConnectedToAnchor;
 

    //----------------
    //record lightslot vector3 in a variable for use in this script
    //record jack vector3 in a variable for use in this script
    [SerializeField] private LightsSlot _lightSlotVar;
    [SerializeField] private IncomingJack _incomingJack;
    [SerializeField] private Vector3 _lightSlotPosition;
    [SerializeField] private Vector3 _incomingJackPosition;

    private void Awake()
    {
        _lightSlots = GameObject.Find("SwitchboardLights").GetComponentsInChildren<LightsSlot>();
        _ropeStartPoint = transform.position;

        for (int i = 0; i < _bones.Count; i++)
        {

            _listOfBones.Add(new Bone(_ropeStartPoint));
            
            _bones[i].transform.position = _ropeStartPoint;
            _ropeStartPoint.y -= _ropeSegmentLength;
        }
    }

    private void OnEnable()
    {
        _incomingJacks = GameObject.Find("Call-Jacks-Container").GetComponentsInChildren<IncomingJack>();
        if (_incomingJacks == null)
        {
            Debug.Log("IncomingWire::Incoming Jacks array is null");
        }
        _switchboard2 = GameObject.Find("Switchboard").GetComponent<Switchboard2>();
        if (_switchboard2 == null)
        {
            Debug.LogError("IncomingWire::Switchboard2 is null");
        }
    }

    private void Update()
    {
        //DrawRope();
        _lightSlotPosition = _lightSlotVar.transform.position;
        _incomingJackPosition = _incomingJack.transform.position;
    }

    //private void DrawRope()
    //{
    //    Vector3[] bonePositions = new Vector3[_numOfRopeSegments];
    //    for (int i = 0; i < _listOfBones.Count; i++)
    //    {
    //        bonePositions[i] = _listOfBones[i].currentPosition;
    //        _bones[i].transform.position = bonePositions[i];
    //    }
    //    if (_isWireConnectedToAnchor)
    //    {
    //        _bones[0].transform.position = _lightSlotVar.transform.position + _wireOffsetIncoming;
    //        _bones[19].transform.position = _incomingJack.transform.position + _incomingJackOffset;

    //    }
    //}

    private void FixedUpdate()
    {
        Simulate();

        for (int i = 0; i < _numOfConstraintRuns; i++)
        {
            ApplyConstraints();
        }
    }

    private void Simulate()
    {
        for (int i = 1; i < _bones.Count-1; i++)
        {
            if (!_listOfBones[i].locked)
            {
                Bone bone = _listOfBones[i];
                Vector2 velocity = (bone.currentPosition - bone.oldPosition) * _dampingFactor;

                bone.oldPosition = bone.currentPosition;
                bone.currentPosition += velocity;
                bone.currentPosition += _gravity * Time.fixedDeltaTime;
                _listOfBones[i] = bone;
                _bones[i].transform.position = _listOfBones[i].currentPosition;
            }
        }
        _bones[19].transform.position = _incomingJack.transform.position + _incomingJackOffset;
    }

    private void ApplyConstraints()
    {
        Bone firstSegment = _listOfBones[0];
        firstSegment.locked = true;
        Bone lastSegment = _listOfBones[19];
        lastSegment.locked = true;

        firstSegment.currentPosition = _bones[0].transform.position; //set bone0 initial position

        _listOfBones[0] = firstSegment;
        _listOfBones[19] = lastSegment; //locks the bone

        for (int i = 0; i < _numOfRopeSegments - 1; i++)
        {
            Bone currentSeg = _listOfBones[i];
            Bone nextSeg = _listOfBones[i + 1];

            float dist = (currentSeg.currentPosition - nextSeg.currentPosition).magnitude;
            float difference = (dist - _ropeSegmentLength);

            Vector2 changeDir = (currentSeg.currentPosition - nextSeg.currentPosition).normalized;
            Vector2 changeVector = changeDir * difference;

            if (i != 0)
            {
                currentSeg.currentPosition -= (changeVector * 0.5f);
                nextSeg.currentPosition += (changeVector * 0.5f);
            }
            else
            {
                nextSeg.currentPosition += changeVector;
            }

            _listOfBones[i] = currentSeg;
            _listOfBones[i + 1] = nextSeg;
        }
    }

    public void ConnectWireAtAnchor(LightsSlot lightslot)
    {
        Debug.Log("Connecting wire at anchors");

        _isWireConnectedToAnchor = true;

        foreach (IncomingJack jack in _incomingJacks)
        {
            if (jack.name == lightslot.name)
            {
                _lightSlotVar = lightslot;

                _incomingJack = jack;
            }
        }
    }
    public void FlipWireToAnchorBool()
    {
        _isWireConnectedToAnchor = false;
    }

    public Vector3 ReturnIncomingWireEnd()
    {
        return _bones[19].transform.position;
    }
}

public struct Bone
{

    public Vector2 currentPosition;
    public Vector2 oldPosition;
    public bool locked;

    public Bone(Vector2 pos)
    {
        locked = false;
        currentPosition = pos;
        oldPosition = pos;
    }
}