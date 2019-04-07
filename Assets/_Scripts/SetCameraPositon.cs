using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraPositon : MonoBehaviour
{
    [SerializeField]
    public Vector2 worldExtents;
    // Start is called before the first frame update
    void Start()
    {
        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        //Set view to "emulate" origin at top left corner
        transform.position = new Vector3(horzExtent, -vertExtent, transform.position.z);

        worldExtents.x = horzExtent;
        worldExtents.y = vertExtent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
