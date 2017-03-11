using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

namespace UnityStandardAssets.Characters.FirstPerson {
    public class CreateMaze : MonoBehaviour
    {

        public GameObject RedCube; //dilwsi prefab
        public GameObject GreenCube;
        public GameObject BlueCube;
        public GameObject T1Cube;
        public GameObject T2Cube;
        public GameObject T3Cube;
        public GameObject floor; //dilwsi dapedou
        public GameObject Wall1;
        public GameObject Wall2;
        public GameObject Wall3;
        public GameObject Wall4;

        public GameObject player;
        public CameraControl firstCameraPosition;

        private int Levels = 0; //L
        private int Size = 0; //N
        private int hammers = 0; //K
        private int thisLevel = 0;


        // Use this for initialization
        void Start()
        {
            string line;
            StreamReader file = new StreamReader(Application.dataPath + "/Resources/maze.txt"); //load text file with data
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains("L="))
                {
                    char[] seperator = { '=' };
                    string[] sections = line.Split(seperator);
                    Levels = Convert.ToInt32(sections[1]);
                    //camera.setHeightFromData(numberOfLevels);
                    //player.setMaximumHeight(numberOfLevels);
                }

                if (line.Contains("N="))
                {
                    char[] seperator = { '=' };
                    string[] sections = line.Split(seperator);
                    Size = Convert.ToInt32(sections[1]);
                }

                if (line.Contains("K="))
                {
                    char[] seperator = { '=' };
                    string[] sections = line.Split(seperator);
                    hammers = Convert.ToInt32(sections[1]);
                    //hatchets.setNumberOfHatchets(numberOfHatchets);
                }

                if (line.Contains("LEVEL"))
                { //an vrw Level
                    char[] seperator = { ' ' }; //to diaxwristiko einai to keno
                    string[] sections = line.Split(seperator); //xwrizw
                    thisLevel = Convert.ToInt32(sections[1]);// allazw se int kai ma8ainw se pio epipedo vriskomai
                    for (int i = 0; i < Size; i++)
                    { // anagnwsi cubes
                        line = file.ReadLine();// grammi pros grammi
                        sections = line.Split(seperator);// xwrizw ana grammi
                        for (int j = 0; j < Size; j++)
                        {
                            if (sections[j] == "R")//kanw spawn mesw tis class LabyrinthCreator opou exei i metavliti cube
                            {
                                Instantiate(RedCube, new Vector3 (i,thisLevel,j), Quaternion.identity);
                            }
                            else if (sections[j] == "G")
                            {
                                Instantiate(GreenCube, new Vector3(i, thisLevel, j), Quaternion.identity);
                            }
                            else if (sections[j] == "B")
                            {
                                Instantiate(BlueCube, new Vector3(i, thisLevel, j), Quaternion.identity);
                            }
                            else if (sections[j] == "T1")
                            {
                                Instantiate(T1Cube, new Vector3(i, thisLevel, j), Quaternion.identity);
                            }
                            else if (sections[j] == "T2")
                            {
                                Instantiate(T2Cube, new Vector3(i, thisLevel, j), Quaternion.identity);
                            }
                            else if (sections[j] == "T3")
                            {
                                Instantiate(T3Cube, new Vector3(i, thisLevel, j), Quaternion.identity);
                            }
                            else if (sections[j] == "E" && thisLevel == 1)
                            {
                                if (thisLevel == 1) {
                                    int r = (int)UnityEngine.Random.Range(1, 10);
                                    if (r > 7) {
                                        player.transform.position = new Vector3(i, 1.0f, j);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Instantiate(floor, new Vector3(Size / 2.0f - 0.5f, 0.0f, Size / 2.0f - 0.5f), Quaternion.identity);
            floor.GetComponent<BoxCollider>().size = new Vector3(Size, 1.0f, Size);

            Instantiate(Wall1, new Vector3(Size, Levels / 2.0f + 0.5f, Size / 2.0f - 0.5f), Quaternion.identity);
            Wall1.GetComponent<BoxCollider>().size = new Vector3(1.0f, Levels, Size);

            Instantiate(Wall2, new Vector3(-1.0f, Levels / 2.0f + 0.5f, Size / 2.0f - 0.5f), Quaternion.identity);
            Wall2.GetComponent<BoxCollider>().size = new Vector3(1.0f, Levels, Size);

            Instantiate(Wall3, new Vector3(Size / 2.0f - 0.5f, Levels / 2.0f + 0.5f, Size), Quaternion.identity);
            Wall3.GetComponent<BoxCollider>().size = new Vector3(Size, Levels, 1.0f);

            Instantiate(Wall4, new Vector3(Size / 2.0f - 0.5f, Levels / 2.0f + 0.5f, -1.0f), Quaternion.identity);
            Wall4.GetComponent<BoxCollider>().size = new Vector3(Size, Levels, 1.0f);

            firstCameraPosition.initiatePanoramicCoordinates(new Vector3(Size / 2.0f, Levels + 10.0f, Size / 2.0f));
        }

        public int getN() {
            return Size;
        }

        public int getK()
        {
            return hammers;
        }

        public Vector3 getCenterOfMaze() {
            return new Vector3(Size / 2.0f, 0.0f, Size / 2.0f);
        }

        public float getHeightOfMaze() {
            return Levels;
        }
    }
}



