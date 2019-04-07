using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EditorPlayerController : MonoBehaviour
{
    [Header("Editor Properties")]
    [SerializeField]
    private LayerMask doubleClickLayerMask;
    

    //Misc References
    private float lastClickTime = 0;

    private void Start()
    {
        lastClickTime = Time.time;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray camToScreenRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            //If user clicked on IRGameobject
            if (Physics.Raycast(camToScreenRay, out hitInfo, 1000.0f, doubleClickLayerMask))
            {
                GameobjectWindow irGo = hitInfo.transform.GetComponent<GameobjectWindow>();
                irGo.SetWindowVisibility(EWindowIds.Main_IRGameobject_View, true);
            }
        }
    }
}
