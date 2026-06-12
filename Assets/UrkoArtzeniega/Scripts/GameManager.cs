using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<CuboTopo> cubos = new List<CuboTopo>();
    public float tiempoReaccion = 3f;
    public int puntosVictoria = 100;

    // variable para guardar el texto de la ui
    public TextMeshProUGUI textoPuntuacion;

    private int puntosActuales = 0;
    private CuboTopo cuboActivo;
    private float temporizador = 0f;

    private void Start()
    {
        ActualizarTexto();

        foreach (CuboTopo cubo in cubos)
        {
            if (cubo != null)
            {
                cubo.Inicializar(this);
            }
        }
        Invoke(nameof(InvocarSiguiente), 1f);
    }

    private void Update()
    {
        if (cuboActivo != null)
        {
            temporizador -= Time.deltaTime;
            if (temporizador <= 0)
            {
                cuboActivo.Fallar();
                cuboActivo = null;
                Invoke(nameof(InvocarSiguiente), 1.5f);
            }
        }
    }

    private void InvocarSiguiente()
    {
        if (puntosActuales >= puntosVictoria)
        {
            SceneManager.LoadScene(0);
            return;
        }

        if (cubos.Count == 0) return;

        int indiceAleatorio = Random.Range(0, cubos.Count);
        cuboActivo = cubos[indiceAleatorio];

        if (cuboActivo != null)
        {
            cuboActivo.Activar();
            temporizador = tiempoReaccion;
        }
    }

    public void SumarPuntos(int puntos)
    {
        puntosActuales += puntos;
        ActualizarTexto();
    }

    public void CuboGolpeado()
    {
        cuboActivo = null;
        Invoke(nameof(InvocarSiguiente), 1.5f);
    }

    // funcion para cambiar lo que pone en el texto
    private void ActualizarTexto()
    {
        if (textoPuntuacion != null)
        {
            textoPuntuacion.text = "Puntos: " + puntosActuales + " / " + puntosVictoria;
        }
    }
}