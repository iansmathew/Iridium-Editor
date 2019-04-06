using UnityEngine;

[System.Serializable]
public struct TransformDetails
{
    public string posX;
    public string posY;
    public string scaleX;
    public string scaleY;
    
    public TransformDetails(Vector2 _pos, Vector2 _scale)
    {
        posX = _pos.x.ToString();
        posY = _pos.y.ToString();

        scaleX = _scale.x.ToString();
        scaleY = _scale.y.ToString();
    }
}