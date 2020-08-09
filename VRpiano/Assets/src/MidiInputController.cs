using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

namespace MidiJack {
    public class MidiInputController : MonoBehaviour {
        public GameObject[] pianoKeys;
        bool check = true;
        public Material whiteKeyMat;
        public Material blackKeyMat;
        int[] pianoMats = new int[88];

        public ParticleSystem particleLauncher;
        public ParticleSystem worldParticleLauncher;
        // Update is called once per frame
        void Update() {
            bool[] pianoValues = new bool[88];
            // Total of 88 keys
            for(int i = 0; i < 88; i++) {
                if(MidiMaster.GetKey(i+21) != 0) {
                    pianoValues[i] = true; 
                } else {
                    pianoValues[i] = false;
                }
            }
            
            for(int i = 0; i < 88; i++) {
                if (pianoValues[i])
                {
                    pianoKeys[i].GetComponent<Renderer>().material.color = Color.red;
                    particleLauncher.transform.position = new Vector3(pianoKeys[i].transform.position.x + 0.07f, pianoKeys[i].transform.position.y, pianoKeys[i].transform.position.z);
                    particleLauncher.Emit(1);
                    int shineUp = UnityEngine.Random.Range(0,150);
                    if(shineUp > 145) {
                        float randX = UnityEngine.Random.Range(10.0f,1.0f);
                        float randZ = UnityEngine.Random.Range(-10.0f,+10.0f);
                        worldParticleLauncher.transform.position = new Vector3(randX,0,randZ);
                        worldParticleLauncher.Emit(10);
                    } 
                } else {
                    pianoKeys[i].GetComponent<Renderer>().material = whiteKeyMat;   
                }
                
            }
        }
    }

}
