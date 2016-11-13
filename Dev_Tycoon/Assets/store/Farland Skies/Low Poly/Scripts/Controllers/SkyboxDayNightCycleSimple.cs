#pragma warning disable 649
using System.Diagnostics.CodeAnalysis;
using Borodar.FarlandSkies.Core.Helpers;
using Borodar.FarlandSkies.LowPoly.DotParams;
using UnityEngine;

namespace Borodar.FarlandSkies.LowPoly
{
    [ExecuteInEditMode]
    [SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Local")]
    public class SkyboxDayNightCycleSimple : Singleton<SkyboxDayNightCycleSimple>
    {
        public const string SKY_TOOLTIP = "List of sky colors, based on time of day. Each list item contains “time” filed that should be specified in percents (0 - 100)";
        public const string STARS_TOOLTIP = "Allows you to manage stars tint color over time. Each list item contains “time” filed that should be specified in percents (0 - 100)";
        public const string CLOUDS_TOOLTIP = "Allows you to manage clouds tint color over time. Each list item contains “time” filed that should be specified in percents (0 - 100)";

        // Sky

        [SerializeField]
        [Tooltip(SKY_TOOLTIP)]
        private SkyParamsList _skyParamsList = new SkyParamsList();

        // Stars

        [SerializeField]
        [Tooltip(STARS_TOOLTIP)]
        private StarsParamsList _starsParamsList = new StarsParamsList();        

        // Clouds

        [SerializeField]
        [Tooltip(CLOUDS_TOOLTIP)]
        private CloudsParamsList _cloudsParamsList = new CloudsParamsList();

        // Private

        private SkyboxControllerSimple _skyboxController;

        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        private float _timeOfDay;

        /// <summary>
        /// Time of day, in percents (0-100).</summary>
        public float TimeOfDay
        {
            get { return _timeOfDay; }
            set { _timeOfDay = value % 100; }
        }

        public SkyParam CurrentSkyParam { get; private set; }
        public StarsParam CurrentStarsParam { get; private set; }
        public CloudsParam CurrentCloudsParam { get; private set; }

        //---------------------------------------------------------------------
        // Messages
        //---------------------------------------------------------------------

        protected void Awake()
        {
            // DOT params
            _skyParamsList.Init();
            _starsParamsList.Init();            
            _cloudsParamsList.Init();
        }

        public void Start()
        {
            _skyboxController = SkyboxControllerSimple.Instance;
            CurrentSkyParam = _skyParamsList.GetParamPerTime(TimeOfDay);
            CurrentStarsParam = _starsParamsList.GetParamPerTime(TimeOfDay);
            CurrentCloudsParam = _cloudsParamsList.GetParamPerTime(TimeOfDay);

        }

        public void Update()
        {
            // Sky colors
            CurrentSkyParam = _skyParamsList.GetParamPerTime(TimeOfDay);

            _skyboxController.TopColor = CurrentSkyParam.TopColor;
            _skyboxController.MiddleColor = CurrentSkyParam.MiddleColor;
            _skyboxController.BottomColor = CurrentSkyParam.BottomColor;
            _skyboxController.CloudsTint = CurrentSkyParam.CloudsTint;

            // Stars colors
            CurrentStarsParam = _starsParamsList.GetParamPerTime(TimeOfDay);
            _skyboxController.StarsTint = CurrentStarsParam.TintColor;

            // Clouds colors
            CurrentCloudsParam = _cloudsParamsList.GetParamPerTime(TimeOfDay);
            _skyboxController.CloudsTint = CurrentCloudsParam.TintColor;
        }

        protected void OnValidate()
        {
            // DOT params
            _skyParamsList.Update();
            _starsParamsList.Update();
            _cloudsParamsList.Update();
        }
    }
}