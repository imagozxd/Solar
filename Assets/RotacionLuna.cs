using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionLuna : MonoBehaviour
{
    [SerializeField] private float velocidadRotacion = 45.0f; // Velocidad de rotación en grados por segundo
    [SerializeField] private float angulo = 0.0f;
    [SerializeField] private Quaternion q = Quaternion.identity;
    private float anguloSen;
    private float anguloCos;

    public float rangoMaximo = 360.0f;

    private void FixedUpdate()
    {
        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angulo * 0.5f); 
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angulo * 0.5f);

        q.Set(0, anguloSen, 0, anguloCos);

        transform.rotation = q;

        angulo -= velocidadRotacion * Time.deltaTime;

    }
    private void Update()
    {        
        if (angulo < -rangoMaximo)
        {
            angulo = 0.0f;
        }
    }
}
