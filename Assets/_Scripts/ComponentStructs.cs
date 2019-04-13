using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct NameDetails
{
    public string name;
}

[System.Serializable]
public struct TransformDetails
{
    public int posX;
    public int posY;
    public int scaleX;
    public int scaleY;
    
    public TransformDetails(Vector2 _pos, Vector2 _scale)
    {
        posX = (int)_pos.x;
        posY = (int)_pos.y;

        scaleX = (int)_scale.x;
        scaleY = (int)_scale.y;
    }
}

[System.Serializable]
public struct RigidbodyDetails
{
    public float mass;
    public bool isEnabled;
    public bool isAffectedByGravity;

    public RigidbodyDetails(float _mass = 1.0f, bool _isEnabled = true, bool _isAffectedByGravity = true)
    {
        mass = _mass;
        isEnabled = _isEnabled;
        isAffectedByGravity = _isAffectedByGravity;
    }
}

[System.Serializable]
public struct RendererDetails
{
    public bool isRendered;
    public string imagePath;

    public RendererDetails(bool _isRendered = true)
    {
        isRendered = _isRendered;
        imagePath = "";
    }
}

[System.Serializable]
public struct AudioDetails
{
    public string[] clipNames;
    public string[] clipPaths;

    public AudioDetails(int _clipCount = 0)
    {
        clipNames = new string[_clipCount];
        clipPaths = new string[_clipCount];
    }
}