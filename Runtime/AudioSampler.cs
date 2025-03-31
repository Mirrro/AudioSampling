using UnityEngine;

namespace Mirrro.AudioSampling
{
    public class AudioSampler
    {
        public static SampleData GetSamples()
        {
            float[] spectrumData = new float[512];
            float[] band = new float[7];
        
            AudioListener.GetSpectrumData(spectrumData, 0, FFTWindow.Blackman);

            int count = 0;

            for (int i = 0; i < band.Length; i++)
            {
                float average = 0;
                int sampleCount = (int) (Mathf.Pow(2, i) * 2);

                for (int j = 0; j < sampleCount; j++)
                {
                    average += spectrumData[count] * (count + 1);
                    count++;
                }

                average /= count;

                band[i] = average * 10;
            }

            return new SampleData()
            {
                SubBase = band[0],
                Base = band[1],
                LowMid = band[2],
                Mid = band[3],
                HighMid = band[4],
                Presence = band[5],
                Brilliance = band[6],
            };
        }

        public struct SampleData
        {
            public float SubBase;
            public float Base;
            public float LowMid;
            public float Mid;
            public float HighMid;
            public float Presence;
            public float Brilliance;
        }
    }
}