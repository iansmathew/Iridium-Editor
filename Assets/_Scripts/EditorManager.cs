using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using Crosstales.FB;

public class EditorManager : MonoBehaviour
{
    [Header("Editor Prefabs")]
    [SerializeField]
    public static float worldPositionScale = 1;
    [SerializeField]
    private GameObject IRGameobject;

    //Serializer properties


    /// <summary>
    /// Spawns an Iridium Gameobject at the origin
    /// </summary>
    public void SpawnIRGameobject()
    {
        var go = Instantiate(IRGameobject, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0), Quaternion.identity);
    }

    public void SaveScene()
    {
        string filePath = FileBrowser.SaveFile("", "xml");

        GameObject[] foundGameobjects = GameObject.FindGameObjectsWithTag("XMLGameobject");

        XMLGameobject[] xmlObjects = new XMLGameobject[foundGameobjects.Length];

        for (int i = 0; i < foundGameobjects.Length; i++)
        {
            var xmlGo = new XMLGameobject();
            var windowScript = foundGameobjects[i].GetComponent<GameobjectWindow>();


            //Save name
            xmlGo.nameDetails.name = windowScript.nameDetails.name;

            //Save transform details
            xmlGo.transformDetails = windowScript.transformDetails;

            //Save everything else accordingly
            if (windowScript.hasRenderer)
            {
                xmlGo.hasRenderComponent = true;
                xmlGo.rendererDetails = windowScript.rendererDetails;
            }
            if (windowScript.hasRigidbody)
            {
                xmlGo.hasRigidbodyComponent = true;
                xmlGo.rigidbodyDetails = windowScript.rigidbodyDetails;
            }
            if (windowScript.hasAudio)
            {
                xmlGo.hasAudioComponent = true;
                xmlGo.audioDetails = windowScript.audioDetails;
            }
            

            xmlObjects[i] = xmlGo;
        }

        if (filePath.Length <= 0)
            return;

        XmlSerializer serializer = new XmlSerializer(typeof(XMLGameobject[]));
        var stream = new FileStream(filePath, FileMode.Create);
        serializer.Serialize(stream, xmlObjects);
        stream.Close();
    }
}
