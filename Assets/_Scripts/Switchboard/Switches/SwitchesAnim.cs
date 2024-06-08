using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SwitchesAnim : MonoBehaviour
{
    //when switch is pressed
    //toggle up
    //when switch is pressed again
    //toggle down
    //if pressed a third time
    //toggle off

    [SerializeField] private SpriteRenderer _mainToggle;
    [SerializeField] private Sprite _toggleUp;
    [SerializeField] private Sprite _toggleDown;
    [SerializeField] private Sprite _toggleOff;
    private Vector3 mousePosition;
    int i = 0;

    public void OnToggleClicked()
    {
        
        ++i;

        if (i == 3)
        {
            _mainToggle.sprite = _toggleUp;
            i = 0;
        }
        else if (i == 1)
        {
            _mainToggle.sprite = _toggleDown;
        }
        else if (i == 2)
        {
            _mainToggle.sprite = _toggleOff;
            
        }
        //Debug.Log("i = " + i);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            //if (hit.collider.name == null)
            //{
            //    Debug.Log("Hit collider is null");
            //    return;
            //}
            //else
            if (hit.collider.name == _mainToggle.name)
            {
                Debug.Log("clicked " + hit.collider.name);
                OnToggleClicked();
            }
            else
            {
                return;
            }
        }
    }
}
