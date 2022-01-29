using Core;
using System;
using UnityEngine;

namespace UI
{
    public class BaseCoin : MonoBehaviour
    {
        [SerializeField]
        private PlayerDataSystem PlayerDataSystem;
        
        private float rotationSpeed = 75f;
        
        private void Start()
        {
            
        }

        private void Update()
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                PlayerDataSystem.AddCoin();
                Destroy(gameObject);
            }
        }
    }
}