using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ColorChanger : MonoBehaviour
{
    private MeshRenderer _rend;
    public List<Color> colors = new();

    private Rigidbody _rb;
    float _startY;

    public float rotationSpeed = 10f;
    public float followSpeed = 5.0f;
    public LayerMask ignoreLayers;
    private Vector3 followTarget;

    void Start()
    {
        _rend = GetComponent<MeshRenderer>();
        _rb = GetComponent<Rigidbody>();
        _startY = transform.position.y;

        ChangeColor();

        followTarget = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ChangeColor();

        _rb.AddTorque(rotationSpeed * Time.deltaTime * (Vector3.right * Input.GetAxis("Horizontal") + Vector3.forward * Input.GetAxis("Vertical")));
        float rpm = Mathf.RoundToInt((_rb.angularVelocity.magnitude / 6) * Mathf.Rad2Deg);
        print("RPM: " + rpm);

        var pos = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(pos, out RaycastHit hit, Mathf.Infinity, ignoreLayers))
            followTarget = hit.point + (Vector3.up * _startY); 
 
        transform.position = Vector3.Lerp(transform.position, followTarget, followSpeed * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        ChangeColor();
    }

    void ChangeColor()
    {
        int idx = Random.Range(0, colors.Count);
        _rend.material.SetColor("_BaseColor", colors[idx]);
        _rend.material.SetColor("_EmissionColor", colors[idx]);

        transform.DOScale(1.1f, 0.5f).From().ChangeEndValue(Vector3.one);
    }

}
