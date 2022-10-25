using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Utils
{

    public static class Utils
    {
        
        public static bool TocaSuelo(GameObject go, float dist)
        {
            Vector3 centro = go.GetComponent<Collider2D>().bounds.center;
            Vector3 destAbajo = new Vector3(0, -(go.GetComponent<Collider2D>().bounds.extents.y + 0.0001f));
            
            RaycastHit2D toca = Physics2D.Raycast(centro + destAbajo, Vector2.down, dist);
            
            return (toca.collider?.CompareTag("Floor") ?? false);
        }

    }

}


