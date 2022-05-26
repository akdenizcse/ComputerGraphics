
using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    public GameObject Block;
    public GameObject previewBlock;

    private void Update()
    {
        //Converting point on screen to mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        //Checkt the distance
        if(Physics.Raycast(ray,out hit,5))
        {
            //Check if ground tag is "Buildable"
            if(hit.transform.tag == "Buildable")
            {
                //for preview of block
                Vector3 prewPos = hit.point;
                previewBlock.transform.position = new Vector3(Mathf.Round(prewPos.x), Mathf.Round(prewPos.y), Mathf.Round(prewPos.z));

                //Check mouse left click
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    //add new block
                    GameObject Build = Instantiate(Block, transform.position, transform.rotation);
                    Vector3 buildPos = hit.point;

                    //Block positions z,y,z
                    Build.transform.rotation = new Quaternion(0, 0, 0, 0);
                    //if block position is not integer, round it. exp: if 2.3 round to 2
                    Build.transform.position = new Vector3(Mathf.Round(buildPos.x), Mathf.Round(buildPos.y), Mathf.Round(buildPos.z));

                }
                //Check mouse right click
                if(Input.GetKeyDown(KeyCode.Mouse1))
                {
                    //delete object
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}
