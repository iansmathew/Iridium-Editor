using System;

[System.Serializable]
public class XMLGameobject
{
    public bool hasRenderComponent;
    public bool hasRigidbodyComponent;
    public bool hasAudioComponent;

    public NameDetails nameDetails;
    public TransformDetails transformDetails;
    public RigidbodyDetails rigidbodyDetails;
    public RendererDetails rendererDetails;
    public AudioDetails audioDetails;

    public XMLGameobject()
    {
        hasRenderComponent = false;
        hasRigidbodyComponent = false;
        hasAudioComponent = false;

        nameDetails = new NameDetails();
        transformDetails = new TransformDetails();
        rigidbodyDetails = new RigidbodyDetails();
        rendererDetails = new RendererDetails();
        audioDetails = new AudioDetails();
    }
}