using UnityEngine;

public class CuboTopo : MonoBehaviour
{
    public Material matGris;
    public Material matRojo;
    public Material matVerde;
    public Material matNegro;
    public AudioSource sonidoAcierto;

    private bool estaActivo = false;
    private GameManager gameManager;
    private Renderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<Renderer>();
    }

    public void Inicializar(GameManager manager)
    {
        gameManager = manager;
        CambiarMaterial(matGris);
    }

    public void Activar()
    {
        estaActivo = true;
        CambiarMaterial(matRojo);
    }

    public void Fallar()
    {
        estaActivo = false;
        CambiarMaterial(matNegro);
        Invoke(nameof(ReiniciarCubo), 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (estaActivo && other.CompareTag("Hand"))
        {
            estaActivo = false;
            CambiarMaterial(matVerde);

            if (sonidoAcierto != null)
            {
                sonidoAcierto.Play();
            }

            if (gameManager != null)
            {
                gameManager.SumarPuntos(10);
                gameManager.CuboGolpeado();
            }

            Invoke(nameof(ReiniciarCubo), 1f);
        }
    }

    private void ReiniciarCubo()
    {
        CambiarMaterial(matGris);
    }

    private void CambiarMaterial(Material nuevoMaterial)
    {
        if (meshRenderer != null && nuevoMaterial != null)
        {
            meshRenderer.material = nuevoMaterial;
        }
    }
}