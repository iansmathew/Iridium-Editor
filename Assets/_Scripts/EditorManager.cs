using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorManager : MonoBehaviour
{
    [Header("Editor Prefabs")]
    [SerializeField]
    private GameObject IRGameobject;

    /// <summary>
    /// Spawns an Iridium Gameobject at the origin
    /// </summary>
    public void SpawnIRGameobject()
    {
        var go = Instantiate(IRGameobject, Vector3.zero, Quaternion.identity);
    }
}
