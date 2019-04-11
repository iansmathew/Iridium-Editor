using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions; 

public class GameobjectWindow : MonoBehaviour
{
    //Gameobject Properties
    string irName = "Gameobject";
    Vector2 positionOffset;

    //Window properties
    bool bShowWindow0 = false;
    bool bShowWindow1 = false;
    [SerializeField]
    float windowWidth = 300;
    [SerializeField]
    float windowHeight = 200;
    [SerializeField]
    float scrollViewHeight = 500;
    Vector2 scrollPosition = Vector2.zero;

    //Component Properties
    bool hasTransform = true;
    bool hasRigidbody = false;
    bool hasScript = false;
    bool hasRenderer = false;
    bool hasAudio = false;
    string userFeedbackText = "Add a component";

    //Transform window properties
    string posX = "400";
    string posY = "300";
    string scaleX = "1";
    string scaleY = "1";

    //Component Details
    TransformDetails transformDetails;

    private void Start()
    {
        //Set window detail values to whatever on instantiate
        posX = transform.position.x.ToString();
        posY = transform.position.y.ToString();
        scaleX = transform.localScale.x.ToString();
        scaleY = transform.localScale.y.ToString();

        //Set default detail values to on instantiate values
        transformDetails = new TransformDetails(new Vector2(transform.position.x, -transform.position.y), transform.localScale); //flip y to correct for unity origin
    }

    private void Update()
    {
        //Unity origin is centered, Iridium is top left, hence we apply changes to visually correct this.
        Vector2 setPosition = new Vector2(transformDetails.posX, -transformDetails.posY); //apply camera offset to "simulate" top left origin
        Vector2 setScale = new Vector2(transformDetails.scaleX * 50.0f, transformDetails.scaleY * 50.0f);

        transform.position = setPosition;
        transform.localScale = setScale;
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
        float lastItemYnHeight = 0;

        scrollPosition = GUI.BeginScrollView(new Rect(0, 0, windowWidth, windowHeight), scrollPosition, new Rect(0, 0, windowWidth + 1, scrollViewHeight));

        //Close window toggle
        bShowWindow0 = GUI.Toggle(new Rect(0, 0, 50, 15), bShowWindow0, "Close");

        #region MAIN_WINDOW_REQUIRED_ITEMS
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
        lastItemYnHeight = yOffset + buttonHeight * yOrderIndex + buttonHeight;


        float componentLabelYPos = lastItemYnHeight;
        GUI.Label(new Rect(windowWidth * 0.3f, componentLabelYPos, windowWidth * 0.6f, 50.0f), "Component Details");
        #endregion

        //New row
        lastItemYnHeight = componentLabelYPos + 50.0f;

        #region TRANSFORM_COMPONENT_DETAILS
        if (hasTransform)
        {
            float detailsYStartPos = lastItemYnHeight;

            GUI.Label(new Rect(10, detailsYStartPos, windowWidth, 20), "Transform Component");

            //Remove button
            float deleteButtonWidth = 30;
            if (GUI.Button(new Rect(windowWidth - (2 * deleteButtonWidth) , detailsYStartPos, deleteButtonWidth, 20), "X"))
                hasTransform = false;

            //Position
            GUI.Label(new Rect(10, detailsYStartPos + 20, 100, 50), "Position: ");

            posX = GUI.TextField(new Rect(100, detailsYStartPos + 20, 80, 20), posX);
            posX = Regex.Replace(posX, @"[^0-9]", ""); //Restricting text field to numbers

            posY = GUI.TextField(new Rect(100 + 80, detailsYStartPos + 20, 80, 20), posY);
            posY = Regex.Replace(posY, @"[^0-9]", ""); //Restricting text field to numbers

            //Scale
            float scaleStartY = detailsYStartPos + 50;
            GUI.Label(new Rect(10, scaleStartY, 100, 50), "Scale: ");

            scaleX = GUI.TextField(new Rect(100, scaleStartY, 80, 20), scaleX);
            scaleX = Regex.Replace(scaleX, @"[^0-9]", ""); //Restricting text field to numbers

            scaleY = GUI.TextField(new Rect(100 + 80, scaleStartY, 80, 20), scaleY);
            scaleY = Regex.Replace(scaleY, @"[^0-9]", ""); //Restricting text field to numbers

            //Apply values
            transformDetails.posX = int.Parse(posX);
            transformDetails.posY = int.Parse(posY);
            transformDetails.scaleX = int.Parse(scaleX);
            transformDetails.scaleY = int.Parse(scaleY);

            lastItemYnHeight = scaleStartY + 20;
            
        }
        #endregion

        GUI.EndScrollView();

        GUI.DragWindow();
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

        #region COMPONENT_BUTTONS

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

        #endregion

        //Next row
        yOrderIndex++;

        GUI.Label(new Rect(windowWidth * 0.25f, yOffset + (buttonHeight * yOrderIndex), windowWidth * 0.66f, 50), userFeedbackText);

        GUI.DragWindow();
    }

    /// <summary>
    /// Given a window enum, sets it to visible or not
    /// </summary>
    /// <param name="_windowView"></param>
    /// <param name="_visibility"></param>
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
