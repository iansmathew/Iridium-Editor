using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorManager : MonoBehaviour
{
    [Header("Editor Prefabs")]
    [SerializeField]
    public static float worldPositionScale = 1;
    [SerializeField]
    private GameObject IRGameobject;

    /// <summary>
    /// Spawns an Iridium Gameobject at the origin
    /// </summary>
    public void SpawnIRGameobject()
    {
        var go = Instantiate(IRGameobject, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0), Quaternion.identity);
    }
}
