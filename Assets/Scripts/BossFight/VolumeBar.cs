using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeBar : MonoBehaviour
{

    public GameObject marker;

    public float value=0f;

    public float maxVolumeVal;
    public float minVolumeVal;

    public float maxVisualizationVal;
    public float minVisualizationVal;


    float visValue;
    float oldVisValue=-100;

    float val;
    public float gravity =0.2f;



    private void Start()
    {
        StartCoroutine(VolumeDo());
    }
    private void Update()
    {


        /*val = (float)System.Math.Round(MicInput.MicLoudness * 10, 1);

        value = (val - minVolumeVal) / (maxVolumeVal - minVolumeVal) * 100;

        visValue = minVisualizationVal + (maxVisualizationVal - minVisualizationVal) / 100f * value ;
        marker.transform.SetLocalPositionAndRotation(new Vector3(0, visValue, 0), transform.localRotation);*/

    }


    IEnumerator VolumeDo()
    {
        while (true)
        {



            yield return new WaitForSeconds(0.1f);

            val = (float)System.Math.Round(MicInput.MicLoudness * 10, 1);

            value = (val - minVolumeVal) / (maxVolumeVal - minVolumeVal) * 100;

            visValue = minVisualizationVal + (maxVisualizationVal - minVisualizationVal) / 100f * value;
            //marker.transform.SetLocalPositionAndRotation(new Vector3(0, visValue, 0), transform.localRotation);

            //не учитывать слишком маленькие изменения
            if(Mathf.Abs(visValue - oldVisValue) > 0.01)
            {
                //если значение больше чем предыдущее то будет оно
                if (visValue > oldVisValue)
                {
                    gravity = 0f;

                }
                //если нет то от предыдущего большего применяем гравитацию
                else
                {
                    gravity = 0.2f;
                    visValue = oldVisValue;
                }


                marker.transform.SetLocalPositionAndRotation(new Vector3(0, visValue - gravity, 0), transform.localRotation);


                oldVisValue = visValue - gravity;
            }
            








        }
    }








}
