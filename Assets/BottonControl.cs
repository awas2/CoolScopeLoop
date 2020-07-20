using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BottonControl : MonoBehaviour
{

    [SerializeField] GameObject currentObject;
    Animator currentAnim = null;
    [SerializeField] Transform playerCamera = null;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(playerCamera.position, playerCamera.rotation * Vector3.forward);
        RaycastHit hit;
        GameObject hitObject = null;
        PointerEventData data = new PointerEventData(EventSystem.current);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "Button")
            {
                hitObject = hit.transform.gameObject;
            }
            else
            {
                hitObject = null;
            }
        }
        if (currentObject != hitObject)
        {
            if (currentObject != null)
            {
                ExecuteEvents.Execute(currentObject, data, ExecuteEvents.pointerExitHandler);
                currentAnim.SetTrigger("Normal");
            }
            currentObject = hitObject;
            if (currentObject != null)
            {
                currentAnim = currentObject.GetComponent<Animator>();
                ExecuteEvents.Execute(currentObject, data, ExecuteEvents.pointerEnterHandler);
                currentAnim.SetTrigger("Highlighted");
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (currentObject == null) return;
            ExecuteEvents.Execute(currentObject, data, ExecuteEvents.pointerClickHandler);
            currentAnim.SetTrigger("Pressed");
        }

    }

    public void Hoge()
    {
        Debug.Log("hogehoge");
    }
}