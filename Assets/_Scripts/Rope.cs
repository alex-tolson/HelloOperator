using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class Rope : MonoBehaviour
{

    [Header("----Rope----")]
    [SerializeField] private int _numOfRopeSegments = 50;
    [SerializeField] private float _ropeSegmentLength = 0.225f;

    [Header("----Physics----")]
    [SerializeField] private Vector2 _gravity = new Vector2(0, -3.81f);
    [SerializeField] private float _dampingFactor = 0.98f;//optional

    [Header("----Constraints----")]
    [SerializeField] private int _numOfConstraintRuns;

    private LightsSlot[] _lightSlots;



    private LineRenderer _lineRenderer;
    [SerializeField] private List<RopeSegment> _ropeSegments = new List<RopeSegment>();

    private Vector3 _ropeStartPoint;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = _numOfRopeSegments;
        _lightSlots = GameObject.Find("SwitchboardLights").GetComponentsInChildren<LightsSlot>();
        foreach (LightsSlot light in _lightSlots)
        {
            if (light.IsActivated())
            {
                _ropeStartPoint = light.StartingPosition();
            }

        }
        //_ropeStartPoint = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        for (int i = 0; i < _numOfRopeSegments; i++)
        {
            _ropeSegments.Add(new RopeSegment(_ropeStartPoint));
            _ropeStartPoint.y -= _ropeSegmentLength;
        }
    }


    private void Update()
    {
        DrawRope();
    }

    private void DrawRope()
    {
        Vector3[] ropePositions = new Vector3[_numOfRopeSegments];
        for (int i = 0; i < _ropeSegments.Count; i++)
        {
            ropePositions[i] = _ropeSegments[i].currentPosition;
            _lineRenderer.SetPositions(ropePositions);
        }
    }
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

        for (int i = 0; i < _ropeSegments.Count ; i++)
        {
            RopeSegment segment = _ropeSegments[i];
            Vector2 velocity = (segment.currentPosition - segment.oldPosition) * _dampingFactor;

            segment.oldPosition = segment.currentPosition;
            segment.currentPosition += velocity;
            segment.currentPosition += _gravity * Time.fixedDeltaTime;
            _ropeSegments[i] = segment;
        }
    }

    private void ApplyConstraints()
    {
        RopeSegment firstSegment = _ropeSegments[0];

        firstSegment.currentPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        _ropeSegments[0] = firstSegment;

        for (int i = 0; i < _numOfRopeSegments-1; i++)
        {
            RopeSegment currentSeg = _ropeSegments[i];
            RopeSegment nextSeg = _ropeSegments[i + 1];

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

            _ropeSegments[i] = currentSeg;
            _ropeSegments[i + 1] = nextSeg;
        }
    }


    public struct RopeSegment
    {
        //public GameObject bone;
        public Vector2 currentPosition;
        public Vector2 oldPosition;

        public RopeSegment(Vector2 pos)
        {
            currentPosition = pos;
            oldPosition = pos;
        }
    }
}


