using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EsferaNivel : MonoBehaviour
{
    public int escenaDestino;
    public Material matBase;
    public Material matTocado;
    public GestorMenu gestor;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable interactable;
    private Renderer meshRenderer;

    void Awake()
    {
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();
        meshRenderer = GetComponent<Renderer>();
        meshRenderer.material = matBase;
    }

    void OnEnable()
    {
        interactable.hoverEntered.AddListener(TocarEsfera);
    }

    void OnDisable()
    {
        interactable.hoverEntered.RemoveListener(TocarEsfera);
    }

    void TocarEsfera(HoverEnterEventArgs args)
    {
        meshRenderer.material = matTocado;

        if (gestor != null)
        {
            gestor.PrepararCarga(escenaDestino);
        }
    }
}