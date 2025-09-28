using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PlantingZone : XRSocketInteractor
{
    protected override void Awake()
    {
        base.Awake();
        selectEntered.AddListener(OnFlowerSocketed);
    }

     private void OnFlowerSocketed(SelectEnterEventArgs args)
    {
        Debug.Log($"Socket selected: {args.interactableObject.transform.name}");
        StartCoroutine(AutoUnsocket(args.interactableObject));
    }
    
    private System.Collections.IEnumerator AutoUnsocket(IXRSelectInteractable interactable)
    {
        yield return new WaitForSeconds(0.5f);

        // Force the socket to release the object
        if (this.hasSelection && this.interactablesSelected.Contains(interactable))
        {
            Debug.Log("Auto-unsocketing flower");
            this.EndManualInteraction();
            this.enabled = false;
        }
    }
}
