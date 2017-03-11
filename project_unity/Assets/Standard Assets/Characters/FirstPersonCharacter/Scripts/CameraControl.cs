using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class CameraControl : MonoBehaviour
    {

        public Camera FirstPersonCamera;
        public Camera PanoramicCamera;
        public CreateMaze MazeData;
        public float rotationSpeed = 1.0f;

        private bool cameraIsUp = false;
        private bool cameraIsRotating = false;
        private float points;
        private float startTime;
        private float spentTime;
        // Use this for initialization
        void Start()
        {
            //FirstPersonCamera.gameObject.SetActive(false);
            PanoramicCamera.gameObject.transform.position = new Vector3 (MazeData.getCenterOfMaze().x, MazeData.getHeightOfMaze() + 1.5f, MazeData.getCenterOfMaze().z);
            PanoramicCamera.gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);
            startTime = Time.time;
           // PanoramicCamera = Camera.main;
        }

        public void initialActiveCamera() {
            FirstPersonCamera.gameObject.SetActive(false);
            cameraIsUp = true;
        }

        public void initiatePanoramicCoordinates(Vector3 coordinates)
        {
            PanoramicCamera.gameObject.transform.position = coordinates;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            spentTime = Time.time - startTime;
            points = Mathf.Pow(MazeData.getN(), 2) - spentTime - MazeData.getK() * 50;

            if (Input.GetKeyDown(KeyCode.V)) {
                if (cameraIsUp)
                {
                    FirstPersonCamera.gameObject.SetActive(true);
                    cameraIsUp = false;
                }
                else {
                    FirstPersonCamera.gameObject.SetActive(false);
                    cameraIsUp = true;
                    //PanoramicCamera = Camera.main;
                }
            }

            if (Input.GetKeyDown(KeyCode.R)) {
                if (cameraIsUp) {
                    if (!cameraIsRotating)
                    {
                        PanoramicCamera.gameObject.transform.position = new Vector3(MazeData.getCenterOfMaze().x, MazeData.getHeightOfMaze() + 4.0f, MazeData.getCenterOfMaze().z - 10.0f);
                        PanoramicCamera.gameObject.transform.rotation = Quaternion.Euler(45, 0, 0);
                    }
                    cameraIsRotating = !cameraIsRotating;
                }
            }


            if (cameraIsRotating) {
                PanoramicCamera.gameObject.transform.LookAt(MazeData.getCenterOfMaze());
                PanoramicCamera.gameObject.transform.Translate(Vector3.right * rotationSpeed * Time.deltaTime);
            }

            if (points <= 0)
            {
                Application.Quit();
            }

            if (Input.GetKeyDown(KeyCode.X)) {
                points = 0;
                Application.Quit();
            }

            if (Input.GetKeyDown(KeyCode.E) && FirstPersonCamera.gameObject.transform.position.y > MazeData.getHeightOfMaze()) {
                Debug.Log(points);
                Application.Quit();
            }
        }
    }
}  
