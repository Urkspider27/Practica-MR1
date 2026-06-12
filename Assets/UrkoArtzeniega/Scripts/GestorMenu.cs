using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorMenu : MonoBehaviour
{
    private int escenaPendiente = -1;

    public void PrepararCarga(int numeroEscena)
    {
        // guarda el numero de la escena que hemos tocado
        escenaPendiente = numeroEscena;
    }

    public void ConfirmarConPulgar()
    {
        // si hay una escena tocada la carga al hacer el gesto
        if (escenaPendiente != -1)
        {
            SceneManager.LoadScene(escenaPendiente);
        }
    }
}