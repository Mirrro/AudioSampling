using UnityEngine;

namespace Mirrro.AudioSampling
{
    public class AudioVisualizer : MonoBehaviour
    {
        [SerializeField] private Transform subBasObject;
        [SerializeField] private Transform BasObject;
        [SerializeField] private Transform lowMidObject;
        [SerializeField] private Transform midObject;
        [SerializeField] private Transform highMidObject;
        [SerializeField] private Transform presenceObject;
        [SerializeField] private Transform brillianceObject;

        [SerializeField] private float smoothSpeed = 10f;

        private void Update()
        {
            var sampleData = AudioSampler.GetSamples();

            SmoothScale(subBasObject, sampleData.SubBase);
            SmoothScale(BasObject, sampleData.Base);
            SmoothScale(lowMidObject, sampleData.LowMid);
            SmoothScale(midObject, sampleData.Mid);
            SmoothScale(highMidObject, sampleData.HighMid);
            SmoothScale(presenceObject, sampleData.Presence);
            SmoothScale(brillianceObject, sampleData.Brilliance);
        }

        private void SmoothScale(Transform target, float intensity)
        {
            Vector3 targetScale = Vector3.one + Vector3.up * intensity;
            target.localScale = Vector3.Lerp(target.localScale, targetScale, Time.deltaTime * smoothSpeed);
        }
    }

}