using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PortalManager : MonoBehaviour
{
    public GameObject MainCamera;

    public GameObject Sponza;

    /*
    private Material[] EastWallSponzaMaterials;
    private Material[] WestWallSponzaMaterials;
    private Material[] SouthWallSponzaMaterials;
    private Material[] NorthWallSponzaMaterials;
    private Material[] FloorSponzaMaterials;*/

    // private Material PortalPlaneMaterial;
    // Start is called before the first frame update
    void Start()
    {
        // SponzaMaterials = Sponza.GetComponent<Renderer>().sharedMaterials;
        //EastWallSponzaMaterials = Sponza.GetComponentsInChildren<Renderer>().Material;
            //eastWall.GetComponent<Renderer>().sharedMaterials;
            /*
        EastWallSponzaMaterials = Sponza.GetComponent<MazeCell>().eastWall.GetComponent<Renderer>().sharedMaterials;
        WestWallSponzaMaterials = Sponza.GetComponent<MazeCell>().westWall.GetComponent<Renderer>().sharedMaterials;
        SouthWallSponzaMaterials = Sponza.GetComponent<MazeCell>().southWall.GetComponent<Renderer>().sharedMaterials;
        NorthWallSponzaMaterials = Sponza.GetComponent<MazeCell>().northWall.GetComponent<Renderer>().sharedMaterials;
        FloorSponzaMaterials = Sponza.GetComponent<MazeCell>().floor.GetComponent<Renderer>().sharedMaterials;*/
    }

    // Update is called once per frame
    void OnTriggerStay(Collider collider)
    {
        Vector3 camPositionInPortalSpace = transform.InverseTransformPoint(MainCamera.transform.position);

        if(camPositionInPortalSpace.y < 0.5f)
        {
            // Disable Stencil test
            int numOfChildren = Sponza.transform.childCount;
            for (int i = 0; i < numOfChildren; ++i)
            {
                GameObject child = Sponza.transform.GetChild(i).gameObject;
                child.GetComponent<Renderer>().material.SetInt("_StencilComp", (int)CompareFunction.Always);
            }




            /*

            for (int i = 0; i < EastWallSponzaMaterials.Length; ++i)
            {
                EastWallSponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Always);
            }

            for (int i = 0; i < WestWallSponzaMaterials.Length; ++i)
            {
                WestWallSponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Always);
            }

            for (int i = 0; i < SouthWallSponzaMaterials.Length; ++i)
            {
                SouthWallSponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Always);
            }

            for (int i = 0; i < NorthWallSponzaMaterials.Length; ++i)
            {
                NorthWallSponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Always);
            }

            for (int i = 0; i < FloorSponzaMaterials.Length; ++i)
            {
                FloorSponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Always);
            }*/

        }
        else
        {
            //Enable stencil test

            int numOfChildren = Sponza.transform.childCount;
            for (int i = 0; i < numOfChildren; ++i)
            {
                GameObject child = Sponza.transform.GetChild(i).gameObject;
                child.GetComponent<Renderer>().material.SetInt("_StencilComp", (int)CompareFunction.Equal);
            }

            /*
            for (int i = 0; i < EastWallSponzaMaterials.Length; ++i)
            {
                EastWallSponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Equal);
            }

            for (int i = 0; i < WestWallSponzaMaterials.Length; ++i)
            {
                WestWallSponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Equal);
            }

            for (int i = 0; i < SouthWallSponzaMaterials.Length; ++i)
            {
                SouthWallSponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Equal);
            }

            for (int i = 0; i < NorthWallSponzaMaterials.Length; ++i)
            {
                NorthWallSponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Equal);
            }

            for (int i = 0; i < FloorSponzaMaterials.Length; ++i)
            {
                FloorSponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Equal);
            }*/
        }
    }
}

