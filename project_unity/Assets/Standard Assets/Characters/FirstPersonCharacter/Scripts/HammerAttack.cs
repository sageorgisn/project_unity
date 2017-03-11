using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson {
    public class HammerAttack : MonoBehaviour
    {
        private bool isAttacking = false;
        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                isAttacking = true;
                transform.Rotate(new Vector3(45, 0, 0));
            }
            else {
                isAttacking = false;
            }
            if(Input.GetMouseButtonUp(0))
            {
                isAttacking = false;
                transform.Rotate(new Vector3(-45, 0, 0));
            }
        }

        void OnTriggerStay(Collider other) {
            if (other.tag.Equals("Cube") && this.gameObject.tag.Equals("hammer")) {
                Debug.Log("Cube!");
                if (isAttacking && other.GetComponent<Cube>()) {
                    Debug.Log("hit");
                    other.GetComponent<Cube>().decreaseLife();
                }
            }
        }
    }
}

