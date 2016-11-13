using Borodar.FarlandSkies.Core.Helpers;
using UnityEngine;

namespace Borodar.FarlandSkies.LowPoly
{
    [ExecuteInEditMode]
    public class SkyboxControllerSimple : Singleton<SkyboxControllerSimple>
    {
        public Material SkyboxMaterial;

        // Sky

        [SerializeField]
        [Tooltip("Color at the top pole of skybox sphere")]
        private Color _topColor = Color.gray;

        [SerializeField]
        [Tooltip("Color on equator of skybox sphere")]
        private Color _middleColor = Color.gray;

        [SerializeField]
        [Tooltip("Color at the bottom pole of skybox sphere")]
        private Color _bottomColor = Color.gray;

        [SerializeField]
        [Range(0.01f, 5f)]
        [Tooltip("Color interpolation coefficient between top pole and equator")]
        private float _topExponent = 1f;

        [SerializeField]
        [Range(0.01f, 5f)]
        [Tooltip("Color interpolation coefficient between bottom pole and equator")]
        private float _bottomExponent = 1f;

        // Stars

        [SerializeField]
        private Color _starsTint = Color.gray;

        [SerializeField]
        [Range(0f, 10f)]
        [Tooltip("Reduction in stars apparent brightness closer to the horizon")]
        private float _starsExtinction = 2f;

        [SerializeField]
        [Range(0f, 25f)]
        [Tooltip("Variation in stars apparent brightness caused by the atmospheric turbulence")]
        private float _starsTwinklingSpeed = 10f;        

        // Clouds

        [SerializeField]
        private Color _cloudsTint = Color.gray;

        [SerializeField]
        [Range(-0.75f, 0.75f)]
        [Tooltip("Height of the clouds relative to the horizon.")]
        private float _cloudsHeight = 0f;

        [SerializeField]
        [Range(0, 360f)]
        [Tooltip("Rotation of the clouds around the positive y axis.")]
        private float _cloudsRotation = 0f;

        // General

        [SerializeField]
        [Range(0, 8f)]
        private float _exposure = 1f;

        [SerializeField]
        [Tooltip("Keep fog color in sync with the sky middle color automatically")]
        private bool _adjustFogColor;

        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        // Sky

        public Color TopColor
        {
            get { return _topColor; }
            set
            {
                _topColor = value;
                SkyboxMaterial.SetColor("_TopColor", _topColor);
            }
        }

        public Color MiddleColor
        {
            get { return _middleColor; }
            set
            {
                _middleColor = value;
                SkyboxMaterial.SetColor("_MiddleColor", _middleColor);
            }
        }

        public Color BottomColor
        {
            get { return _bottomColor; }
            set
            {
                _bottomColor = value;
                SkyboxMaterial.SetColor("_BottomColor", _bottomColor);
            }
        }

        public float TopExponent
        {
            get { return _topExponent; }
            set
            {
                _topExponent = value;
                SkyboxMaterial.SetFloat("_TopExponent", _topExponent);
            }
        }

        public float BottomExponent
        {
            get { return _bottomExponent; }
            set
            {
                _bottomExponent = value;
                SkyboxMaterial.SetFloat("_BottomExponent", _bottomExponent);
            }
        }

        // Stars

        public Color StarsTint
        {
            get { return _starsTint; }
            set
            {
                _starsTint = value;
                SkyboxMaterial.SetColor("_StarsTint", _starsTint);
            }
        }

        public float StarsExtinction
        {
            get { return _starsExtinction; }
            set
            {
                _starsExtinction = value;
                SkyboxMaterial.SetFloat("_StarsExtinction", _starsExtinction);
            }
        }

        public float StarsTwinklingSpeed
        {
            get { return _starsTwinklingSpeed; }
            set
            {
                _starsTwinklingSpeed = value;
                SkyboxMaterial.SetFloat("_StarsTwinklingSpeed", _starsTwinklingSpeed);
            }
        }        

        // Clouds

        public Color CloudsTint
        {
            get { return _cloudsTint; }
            set
            {
                _cloudsTint = value;
                SkyboxMaterial.SetColor("_CloudsTint", _cloudsTint);
            }
        }

        public float CloudsRotation
        {
            get { return _cloudsRotation; }
            set
            {
                _cloudsRotation = value;
                SkyboxMaterial.SetFloat("_CloudsRotation", _cloudsRotation);
            }
        }

        public float CloudsHeight
        {
            get { return _cloudsHeight; }
            set
            {
                _cloudsHeight = value;
                SkyboxMaterial.SetFloat("_CloudsHeight", _cloudsHeight);
            }
        }

        // General

        public float Exposure
        {
            get { return _exposure; }
            set
            {
                _exposure = value;
                SkyboxMaterial.SetFloat("_Exposure", _exposure);
            }
        }

        public bool AdjustFogColor
        {
            get { return _adjustFogColor; }
            set
            {
                _adjustFogColor = value;
                if (_adjustFogColor) RenderSettings.fogColor = MiddleColor;
            }
        }

        //---------------------------------------------------------------------
        // Messages
        //---------------------------------------------------------------------

        protected void Awake()
        {
            if (SkyboxMaterial != null)
            {
                RenderSettings.skybox = SkyboxMaterial;
                UpdateSkyboxProperties();
            }
            else
            {
                Debug.LogWarning("SkyboxController: Skybox material is not assigned.");
            }
        }

        protected void OnValidate()
        {
            UpdateSkyboxProperties();
        }

        protected void Update()
        {
            if (SkyboxMaterial == null) return;
            if (_adjustFogColor) RenderSettings.fogColor = MiddleColor;
        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

        private void UpdateSkyboxProperties()
        {
            if (SkyboxMaterial == null) return;

            // Sky
            SkyboxMaterial.SetColor("_TopColor", _topColor);
            SkyboxMaterial.SetColor("_MiddleColor", _middleColor);
            SkyboxMaterial.SetColor("_BottomColor", _bottomColor);
            SkyboxMaterial.SetFloat("_TopExponent", _topExponent);
            SkyboxMaterial.SetFloat("_BottomExponent", _bottomExponent);
            // Stars
            SkyboxMaterial.SetColor("_StarsTint", _starsTint);
            SkyboxMaterial.SetFloat("_StarsExtinction", _starsExtinction);
            SkyboxMaterial.SetFloat("_StarsTwinklingSpeed", _starsTwinklingSpeed);
            // Clouds
            SkyboxMaterial.SetColor("_CloudsTint", _cloudsTint);
            // General
            SkyboxMaterial.SetFloat("_Exposure", _exposure);
            SkyboxMaterial.SetFloat("_CloudsRotation", _cloudsRotation);
            SkyboxMaterial.SetFloat("_CloudsHeight", _cloudsHeight);
        }
    }
}