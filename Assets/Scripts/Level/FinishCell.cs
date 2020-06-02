using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestWork
{
    public class FinishCell : BaseCell
    {
        private void OnEnable()
        {
            transform.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
        private void OnTriggerEnter(Collider other)
        {
            var controller = other.GetComponent<PlayerController>();
            controller.Grid.UI.gameObject.SetActive(true);
            controller.enabled = false;
        }
    }
}
