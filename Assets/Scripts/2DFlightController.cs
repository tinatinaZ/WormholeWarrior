using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 2DFlightController : MonoBehaviour
{
    public Transform flightImage;
    public int _currentLayer = 0; //the current position of the flight, from 0 to 3

    private float[] _layerPositions = {-125.0f, -85.0f, -50.0f, -25.0f};
    private float[] _layerFlightScales = {0.3f, 0.27f, 0.22f, 0.18f};
    private Vector3 _flightPosition;
    private Vector3 _flightScale;
    private Vector3 _flightRotation;
    // Start is called before the first frame update
    void Start()
    {
        InitFlight();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && _currentLayer<3)
        {
            _currentLayer = _currentLayer + 1;
            _flightPosition = new Vector3(0.0f, _layerPositions[_currentLayer], 0.0f);
            _flightScale = new Vector3(_layerFlightScales[_currentLayer], _layerFlightScales[_currentLayer], _layerFlightScales[_currentLayer]);

            flightImage.localPosition = _flightPosition;
            flightImage.localScale = _flightScale;
        }
        else if(Input.GetKeyDown(KeyCode.S) && _currentLayer>0)
        {
            _currentLayer -= 1;
            _flightPosition = new Vector3(0.0f, _layerPositions[_currentLayer], 0.0f);
            _flightScale = new Vector3(_layerFlightScales[_currentLayer], _layerFlightScales[_currentLayer], _layerFlightScales[_currentLayer]);

            flightImage.localPosition = _flightPosition;
            flightImage.localScale = _flightScale;
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            _flightRotation = new Vector3(0.0f, 0.0f, _flightRotation.z + 60.0f);
            if(_flightRotation.z >= 360.0f){
                _flightRotation = new Vector3(0.0f, 0.0f, _flightRotation.z - 360.0f);
            }
            this.transform.localRotation = Quaternion.Euler(_flightRotation);
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            _flightRotation = new Vector3(0.0f, 0.0f, _flightRotation.z - 60.0f);
            if(_flightRotation.z <= 0.0f){
                _flightRotation = new Vector3(0.0f, 0.0f, _flightRotation.z + 360.0f);
            }
            this.transform.localRotation = Quaternion.Euler(_flightRotation);
        }
    }

    private void InitFlight()
    {
        _flightPosition = new Vector3(0.0f, _layerPositions[0], 0.0f);
        _flightScale = new Vector3(_layerFlightScales[0], _layerFlightScales[0], _layerFlightScales[0]);
        _flightRotation = new Vector3(0.0f, 0.0f, 0.0f);

        flightImage.localPosition = _flightPosition;
        flightImage.localScale = _flightScale;
        flightImage.localRotation = Quaternion.Euler(_flightRotation);
    }
}
