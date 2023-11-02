using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 7.5f;
    public float inclinacionMax = 30.0f;
    private Transform transform1;


    private Vector3 angulos = Vector3.zero;
    private void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 direccionMovimiento = new Vector3(movimientoHorizontal, movimientoVertical, 0);

        Vector3 velocidadMovimiento = direccionMovimiento.normalized * velocidad;

        transform.Translate(velocidadMovimiento * Time.deltaTime);
        Vector3 newPos = transform.position;
        newPos.z = 0;
        transform.position = newPos;
        // Inclinación 
        angulos.y = movimientoHorizontal * inclinacionMax;
        angulos.x = -movimientoVertical * inclinacionMax;
    }
    private void FixedUpdate()
    {
        // Rotación X -> Y -> Z
        float anguloSenX = Mathf.Sin(Mathf.Deg2Rad * angulos.x * 0.5f);
        float anguloCosX = Mathf.Cos(Mathf.Deg2Rad * angulos.x * 0.5f);
        Quaternion qx = new Quaternion(anguloSenX, 0, 0, anguloCosX);

        float anguloSenY = Mathf.Sin(Mathf.Deg2Rad * angulos.y * 0.5f);
        float anguloCosY = Mathf.Cos(Mathf.Deg2Rad * angulos.y * 0.5f);
        Quaternion qy = new Quaternion(0, anguloSenY, 0, anguloCosY);

        float anguloSenZ = Mathf.Sin(Mathf.Deg2Rad * angulos.z * 0.5f);
        float anguloCosZ = Mathf.Cos(Mathf.Deg2Rad * angulos.z * 0.5f);
        Quaternion qz = new Quaternion(0, 0, anguloSenZ, anguloCosZ);

        Quaternion r = qx * qy * qz;

        transform.rotation = r;
    }

}
