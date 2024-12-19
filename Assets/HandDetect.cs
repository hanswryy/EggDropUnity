using UnityEngine;
using OpenCvSharp;
using System.Collections.Generic;

public class HandDetect : MonoBehaviour {
    WebCamTexture _webcamTexture;
    CascadeClassifier _cascadeClassifier;
    OpenCvSharp.Rect _hands;
    [SerializeField]
    GameObject sphere;
    
    void Start() {
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length > 0) {
            _webcamTexture = new WebCamTexture(devices[0].name, 640, 360, 30);
            Debug.Log("width" + _webcamTexture.width);
            Debug.Log("height" + _webcamTexture.height);
            _webcamTexture.Play();
            _cascadeClassifier = new CascadeClassifier(Application.dataPath + "/haarcascade_frontalface_default.xml");
        } else {
            Debug.LogError("No webcam found");
        }
    }

    void Update() {
        if (_webcamTexture != null && _webcamTexture.isPlaying) {
            Mat frame = OpenCvSharp.Unity.TextureToMat(_webcamTexture);
            findNewHands(frame);
            // displayHands(frame);
            GetComponent<Renderer>().material.mainTexture = _webcamTexture;
        } else {
            return;
        }
    }

    void findNewHands(Mat frame) {
        var hands = _cascadeClassifier.DetectMultiScale(frame, 1.1, 3, HaarDetectionType.ScaleImage, new OpenCvSharp.Size(30, 30));

        if (hands.Length >= 1) {
            // Debug.Log(hands[0].Location);
            // make the sphere follow the hand
            Vector3 pos = new Vector3(-hands[0].Location.X, -hands[0].Location.Y+90, -50);
            sphere.transform.position = pos;
            sphere.gameObject.SetActive(true);
            _hands = hands[0];
        } else {
            sphere.gameObject.SetActive(false);
        }
    }

    void displayHands(Mat frame) {
        if (_hands != null) {
            frame.Rectangle(_hands, new Scalar(0, 255, 0), 3);
        }

        Texture2D newTexture = OpenCvSharp.Unity.MatToTexture(frame);
        GetComponent<Renderer>().material.mainTexture = newTexture;
        // Destroy(newTexture); // Destroy the texture to free memory
    }

    void OnDestroy() {
        if (_webcamTexture != null) {
            _webcamTexture.Stop();
            Destroy(_webcamTexture);
        }
    }
}
