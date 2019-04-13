using UnityEngine;

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