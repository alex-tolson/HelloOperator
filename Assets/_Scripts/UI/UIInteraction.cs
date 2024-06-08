using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIInteraction : MonoBehaviour
{
    //dont forget to install the new input system!

    [SerializeField] private GameObject _canvas;
    private GraphicRaycaster _uiRaycaster;
    private PointerEventData _clickData;
    [SerializeField] private List<RaycastResult> _clickResults;



    // Start is called before the first frame update
    void Start()
    {
        _uiRaycaster = _canvas.GetComponent<GraphicRaycaster>();
        if(_uiRaycaster == null)
        {
            Debug.LogError("UI Raycaster is null");
        }
        _clickData = new PointerEventData(EventSystem.current);
        if (_clickData == null)
        {
            Debug.LogError("Raycast Click Data is null");
        }
        _clickResults = new List<RaycastResult>();
        if (_clickResults == null)
        {
            Debug.LogError("Raycast Result is null");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current.leftButton.wasReleasedThisFrame)
        {
            GetUIElementClicked();
        }
    }

    private void GetUIElementClicked()
    {
        _clickData.position = Mouse.current.position.ReadValue();
        _clickResults.Clear();
        _uiRaycaster.Raycast(_clickData, _clickResults);

        foreach(RaycastResult result in _clickResults)
        {
            GameObject uiElement = result.gameObject;
            Debug.Log("name is " + uiElement.name);
        }
    }
}
