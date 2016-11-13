Shader "Skybox/Farland Skies/Low Poly Simple" {
	
	Properties{
		[Header(Sky)]

			_TopColor("Color Top", Color) = (.5, .5, .5, 1.0)
			_MiddleColor("Color Middle", Color) = (.5, .5, .5, 1.0)
			_BottomColor("Color Bottom", Color) = (.5, .5, .5, 1.0)

		[Space]

			_TopExponent("Exponent Top", Range(0.01, 5)) = 1.0
			_BottomExponent("Exponent Bottom", Range(0.01, 5)) = 1.0

		[Header(Stars)]

			_StarsTint("Stars Tint", Color) = (.5, .5, .5, 1.0)
			_StarsExtinction("Stars Extinction", Range(0, 10)) = 2.0
			_StarsTwinklingSpeed("Stars Twinkling Speed", Range(0, 15)) = 4.0
			[NoScaleOffset]
			_StarsTex("Stars Cubemap", Cube) = "grey" {}
			[NoScaleOffset]
			_StarsTwinklingTex("Stars Twinkling Cubemap", Cube) = "grey" {}

		[Header(Clouds)]

			_CloudsTint("Clouds Tint", Color) = (.5, .5, .5, 1.0)
			_CloudsRotation("Clouds Rotation", Range(0, 360)) = 0
			_CloudsHeight("Clouds Height", Range(-0.75, 0.75)) = 0
			[NoScaleOffset]
			_CloudsTex("Clouds Cubemap", Cube) = "grey" {}

		[Header(General)]

			[Gamma] _Exposure("Exposure", Range(0, 8)) = 1.0
	}

	SubShader{
		Tags{ "Queue" = "Background" "RenderType" = "Background" "PreviewType" = "Skybox" }
		Cull Off ZWrite Off

		Pass{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			// Exposed
			half3 _TopColor;
			half3 _MiddleColor;
			half3 _BottomColor;

			half _TopExponent;
			half _BottomExponent;

			half4 _StarsTint;
			fixed _StarsTwinklingSpeed;
			fixed _StarsExtinction;
			samplerCUBE _StarsTex;
			samplerCUBE _StarsTwinklingTex;

			half3 _CloudsTint;
			fixed _CloudsRotation;
			fixed _CloudsHeight;
			samplerCUBE _CloudsTex;

			half _Exposure;

			// -----------------------------------------
			// Structs
			// -----------------------------------------

			struct v2f {
				float4 position : SV_POSITION;
				float3 vertex : TEXCOORD0;
				float3 twinklingPosition : TEXCOORD1;
				float3 cloudsPosition : TEXCOORD2;				
			};

			// -----------------------------------------
			// Functions
			// -----------------------------------------

			float4 RotateAroundYInDegrees(float4 vertex, float degrees)
			{
				float alpha = degrees * UNITY_PI / 180.0;
				float sina, cosa;
				sincos(alpha, sina, cosa);
				float2x2 m = float2x2(cosa, -sina, sina, cosa);
				return float4(mul(m, vertex.xz), vertex.yw).xzyw;
			}

			v2f vert(appdata_base v)
			{
				v2f OUT;
				OUT.position = mul(UNITY_MATRIX_MVP, v.vertex);
				OUT.vertex = v.vertex;
				OUT.twinklingPosition = RotateAroundYInDegrees(v.vertex, _Time.y * _StarsTwinklingSpeed);
				OUT.cloudsPosition = RotateAroundYInDegrees(v.vertex, _CloudsRotation);
				OUT.cloudsPosition.y -= _CloudsHeight;
				return OUT;
			}

			half4 frag(v2f IN) : SV_Target
			{
				float t1 = max(+IN.vertex.y, 0);
				float t2 = max(-IN.vertex.y, 0);
				
				// Gradient
				half3 color = lerp(lerp(_MiddleColor, _TopColor, pow(t1, _TopExponent)), _BottomColor, pow(t2, _BottomExponent));

				// Stars
				half3 starsTex = texCUBE(_StarsTex, IN.vertex);
				half3 twinklingTex = texCUBE(_StarsTwinklingTex, IN.twinklingPosition);
				half extinction = saturate(abs(IN.vertex.y * _StarsExtinction));

				half starsCoef = starsTex.r * _StarsTint.a * extinction * twinklingTex;
				color = color * (1 - starsCoef) + (_StarsTint.rgb * unity_ColorSpaceDouble.rgb) * starsCoef;

				// Clouds
				half3 cloudsTex = texCUBE(_CloudsTex, IN.cloudsPosition);
				color = (cloudsTex.r * (unity_ColorSpaceDouble.rgb * _CloudsTint.rgb) + cloudsTex.b * color) * _Exposure;

				return half4(color, 1);
			}
			ENDCG
		}
	}
}