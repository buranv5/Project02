using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] Transform Terra, NotTerra;

    void Start() {
        for (int i = -10; i < 10; i++) {
            for (int j = -2; j > -10; j--) {
                switch (Random.Range(0, 5)) {
                    case 1: case 2: case 3: case 4: Transform _t = Instantiate(Terra, new Vector2(i * 1.28f, j * 1.28f), Quaternion.identity); break;
                    case 0: Transform _nt = Instantiate(NotTerra, new Vector2(i * 1.28f, j * 1.28f), Quaternion.identity); break;
                }
            }
        }
    }
}
