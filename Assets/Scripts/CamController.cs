using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YY_Games_Scripts
{
    public class CamController : MonoBehaviour
    {
        public static CamController instance;

        public Transform target;

        private float startFOV, targetFOV;
        public float zoomSpeed = 1f;
        public Camera myCam;

        private void Awake()
        {
            instance = this;
        }
        void Start()
        {
            startFOV = myCam.fieldOfView;
            targetFOV = startFOV;
        }

        // Update is called once per frame
        void LateUpdate()
        {
            transform.position = target.position;
            transform.rotation = target.rotation;

            myCam.fieldOfView = Mathf.Lerp(myCam.fieldOfView, targetFOV, zoomSpeed * Time.deltaTime);
        }

        public void ZoomIn(float newZoom)
        {
            targetFOV = newZoom;
        }
        public void ZoomOut()
        {
            targetFOV = startFOV;
        }
    }
}