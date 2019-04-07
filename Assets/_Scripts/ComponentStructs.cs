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