using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameobjectWindow : MonoBehaviour
{
    //Gameobject Properties
    string irName = "Gameobject";

    //Window properties
    bool bShowWindow0 = false;
    bool bShowWindow1 = false;
    [SerializeField]
    float windowWidth = 300;
    [SerializeField]
    float windowHeight = 200;

    //Component Properties
    bool hasTransform = false;
    bool hasRigidbody = false;
    bool hasScript = false;
    bool hasRenderer = false;
    bool hasAudio = false;
    string userFeedbackText = "Add a component";


    private void Start()
    {
        
    }

    private void OnGUI()
    {

        //Display add component window if enabled, otherwise main view
        if (bShowWindow1)
        {
            GUI.Window(0, new Rect(10, 10, windowWidth, windowHeight), DoWindow1, "Add Components");
        }
        else if (bShowWindow0)
        {
            GUI.Window(0, new Rect(10, 10, windowWidth, windowHeight), DoWindow0, irName + " main view");
        }

    }

    /// <summary>
    /// Draw function for Main View window
    /// </summary>
    /// <param name="_windowId"></param>
    private void DoWindow0(int _windowId)
    {
        float leftColX = 0;
        float rightColX = windowWidth * 0.5f;
        float yOffset = 15;
        float buttonWidth = windowWidth * 0.5f;
        float buttonHeight = 50.0f;
        float yOrderIndex = 0;


        //Close window toggle
        bShowWindow0 = GUI.Toggle(new Rect(0, 0, 50, 15), bShowWindow0, "Close");

        //Delete button
        if (GUI.Button(new Rect(leftColX, yOffset + buttonHeight * yOrderIndex, buttonWidth, buttonHeight), "Delete"))
        {
            Destroy(this.gameObject);
        }

        //Add component button
        if (GUI.Button(new Rect(rightColX, yOffset + buttonHeight * yOrderIndex, buttonWidth, buttonHeight), "Add Component"))
        {
            SetWindowVisibility(EWindowIds.Add_Component_Window, true);
        }

        //Next row
        yOrderIndex++;

        float componentLabelYPos = yOffset + buttonHeight * yOrderIndex;
        GUI.Label(new Rect(windowWidth * 0.3f, componentLabelYPos, windowWidth * 0.6f, 50.0f), "Component Details");

        float detailsYStartPos = componentLabelYPos + 50.0f;

        if (hasTransform)
        {
            GUI.Label(new Rect(0, detailsYStartPos, windowWidth, 50), "Transform Component");

        }
    }

    /// <summary>
    /// Draw function for Add Component Window
    /// </summary>
    /// <param name="_windowId"></param>
    private void DoWindow1(int _windowId)
    {

        float leftColX = 0;
        float rightColX = windowWidth * 0.5f;
        float yOffset = 15;
        float buttonWidth = windowWidth * 0.5f;
        float buttonHeight = 50.0f;
        float yOrderIndex = 0;


        bShowWindow1 = GUI.Toggle(new Rect(0, 0, 50, yOffset), bShowWindow1, "Close");

        if (GUI.Button(new Rect(leftColX, yOffset + buttonHeight * yOrderIndex, buttonWidth, buttonHeight), "Transform"))
        {
            if (!hasTransform)
            {
                hasTransform = true;
                userFeedbackText = "Transform added.";
            }
            else
                userFeedbackText = "Component already exists!";
        }

        if (GUI.Button(new Rect(rightColX, yOffset + buttonHeight * yOrderIndex, buttonWidth, buttonHeight), "Rigidbody"))
        {
            if (!hasRigidbody)
            {
                hasRigidbody = true;
                userFeedbackText = "Rigidbody added.";
            }
            else
                userFeedbackText = "Component already exists!";
        }

        //Next row
        yOrderIndex++;

        if (GUI.Button(new Rect(leftColX, yOffset + buttonHeight * yOrderIndex, buttonWidth, buttonHeight), "Renderer"))
        {
            if (!hasRenderer)
            {
                hasRenderer = true;
                userFeedbackText = "Renderer added.";
            }
            else
                userFeedbackText = "Component already exists!";
        }

        if (GUI.Button(new Rect(rightColX, yOffset + buttonHeight * yOrderIndex, buttonWidth, buttonHeight), "Audio"))
        {
            if (!hasAudio)
            {
                hasAudio = true;
                userFeedbackText = "Audio added.";
            }
            else
                userFeedbackText = "Component already exists!";
        }

        //Next row
        yOrderIndex++;

        if (GUI.Button(new Rect(leftColX, yOffset + buttonHeight * yOrderIndex, buttonWidth, buttonHeight), "Script"))
        {

            userFeedbackText = "Script added.";
        }

        //Next row
        yOrderIndex++;

        GUI.Label(new Rect(windowWidth * 0.25f, yOffset + (buttonHeight * yOrderIndex), windowWidth * 0.66f, 50), userFeedbackText);
    }

    public void SetWindowVisibility(EWindowIds _windowView, bool _visibility = true)
    {
        switch(_windowView)
        {
            case EWindowIds.Main_IRGameobject_View:
                bShowWindow0 = _visibility;
                break;

            case EWindowIds.Add_Component_Window:
                bShowWindow1 = _visibility;
                break;

            default:
                break;

        }
    }

}
