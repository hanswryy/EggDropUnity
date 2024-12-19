using UnityEngine;
using OpenCvSharp;
using OpenCvSharp.Demo;
using System.Collections.Generic;

public class FindContour : WebCamera {
    Mat image;

    protected override void Awake() {
        base.Awake();

        // Set the camera device name
        DeviceName = WebCamTexture.devices[0].name;

        // log the device name
        Debug.Log(DeviceName);
    }

    protected override bool ProcessTexture(WebCamTexture input, ref Texture2D output) {
        image = OpenCvSharp.Unity.TextureToMat(input);

        

        if (output == null) {
            output = OpenCvSharp.Unity.MatToTexture(image);
        } else {
            OpenCvSharp.Unity.MatToTexture(image, output);
        }

        return true;
    }
}
