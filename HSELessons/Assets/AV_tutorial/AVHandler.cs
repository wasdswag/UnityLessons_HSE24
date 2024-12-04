using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AVHandler : MonoBehaviour
{

    [SerializeField] private bool useMicro;
    [SerializeField] private AudioMixerGroup micMixer;
    
    
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Transform cubeBarPrefab;
    [SerializeField] private int numSamples = 512;

    [SerializeField] private float[] samples;
    [SerializeField] private float amplifier = 10f;

    private List<Transform> bars = new List<Transform>();

    private int bandsCount = 8;
    private float[] bands;


    private void Awake()
    {
        if (useMicro)
        {
            audioSource.playOnAwake = false;
            audioSource.Stop();

            for (int i = 0; i < Microphone.devices.Length; i++)
            {
                Debug.Log(Microphone.devices[i]);
            }

            audioSource.outputAudioMixerGroup = micMixer;
            audioSource.clip = Microphone.Start(Microphone.devices[0], true, 1, AudioSettings.outputSampleRate);
            
            while(Microphone.GetPosition(Microphone.devices[0]) > 0 == false) { }

            audioSource.Play();

        }
        
        
    }
    

    private void Start()
    {
        samples = new float[numSamples];
        bands = new float[bandsCount];
        
        for (int i = 0; i < bandsCount; i++)
        {
            var bar = Instantiate(cubeBarPrefab, new Vector3(i, 0, 0), Quaternion.identity);
            bars.Add(bar);
        }

    }

 
    private void Update()
    {
        // audioSource.GetOutputData(samples, 0);
      

        audioSource.GetSpectrumData(samples, 0, FFTWindow.BlackmanHarris);
        SetFrequencyBands();
        for (int i = 0; i < bandsCount; i++)
        {
            bars[i].localScale = Vector3.one + (Vector3.up * samples[i] * amplifier);
        }
        
        

    }

    private void SetFrequencyBands()
    {
        int count = 0;
        for (int i = 0; i < bandsCount; i++)
        {
            float average = 0f;
            int samplesPerBand = (int)(Mathf.Pow(2, i)) * 2;
            // 2+4+8+16+32+64+128+256 = 510 

            for(int j = 0; j < samplesPerBand; j++)
            {
                average += samples[count];
                count++;
            }

            average /= count;
            bands[i] = average * amplifier;


        }


    }
}
