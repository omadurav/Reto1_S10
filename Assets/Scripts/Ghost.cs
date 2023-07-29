using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Ghost : MonoBehaviour
{
    [SerializeField] private Transform[] puntosObjetivo;
    [SerializeField] private float speed;
    [SerializeField] private float tiempoDeEspera;

    private int indexSiguienteObjetivo;
    private bool estaEsperando;


    private void Update()
    {
        if (transform.position != puntosObjetivo[indexSiguienteObjetivo].position)
        {
            MoverFantasma();
        }
        else if (!estaEsperando)
        {
            StartCoroutine(Espera());
        }
    }

    private void MoverFantasma()
    {
        Vector3 nuevaPosicion = Vector3.MoveTowards(transform.position, puntosObjetivo[indexSiguienteObjetivo].position, speed * Time.deltaTime);

        transform.position = nuevaPosicion;
    }

    IEnumerator Espera()
    {
        estaEsperando = true;
        yield return new WaitForSeconds(tiempoDeEspera);
        indexSiguienteObjetivo++;

        if (indexSiguienteObjetivo == puntosObjetivo.Length)
        {
            indexSiguienteObjetivo = 0;
        }
        estaEsperando = false;
        RotarVista();
    }

    private void RotarVista()
    {
        if (puntosObjetivo[indexSiguienteObjetivo].position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else if (puntosObjetivo[indexSiguienteObjetivo].position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
        else if (puntosObjetivo[indexSiguienteObjetivo].position.z < transform.position.z)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}

