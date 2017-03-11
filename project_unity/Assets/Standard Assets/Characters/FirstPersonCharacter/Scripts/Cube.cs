using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson {
    public class Cube : MonoBehaviour
    {

        private int cubeLife = 3;

        public void decreaseLife() {
            cubeLife--;
            if (cubeLife <= 0) {
                Destroy(gameObject);
            }
        }
    }
}

