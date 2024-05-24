using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    // Add or remove an InteractionEvent component to this gameobject
    public bool useEvents;
    [SerializeField]
    public string promptMessage;

    public virtual string onLook()
    {
        return promptMessage;
    }
    public void BaseInteract()
    {
        if (useEvents)
        {
            GetComponent<InteractionEvent>().onInteract.Invoke();
        }
        Interact();
    }
    protected virtual void Interact()
    {
        // This method is meant to be overridden
    }
}
