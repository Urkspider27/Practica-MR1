using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorMenu : MonoBehaviour
{
    private int escenaPendiente = -1;

    public void PrepararCarga(int numeroEscena)
    {
        escenaPendiente = numeroEscena;
        Debug.Log("Esfera tocada. Esperando 2 segundos para cargar escena: " + numeroEscena);

        // Carga la escena automáticamente tras 2 segundos para poder testear en PC
        Invoke(nameof(ConfirmarConPulgar), 2f);
    }

    public void ConfirmarConPulgar()
    {
        if (escenaPendiente != -1)
        {
            SceneManager.LoadScene(escenaPendiente);
        }
    }

}