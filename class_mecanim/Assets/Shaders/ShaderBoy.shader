Shader "Custom/ShaderBoy" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_SpecularColor ("Specular Color", Color) = (1, 1, 1, 1)
		_SpecPower ("Specular Power", Range(0.1, 100)) = 2
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf BlinnPhong

		sampler2D _MainTex;
		fixed4 _SpecularColor;
		fixed _SpecPower;

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}

		inline fixed4 LightingCustomLight (SurfaceOutput s, fixed3 lightDir, fixed3 viewDir, fixed etten)
		{
			fixed3 halfVector = normalize(lightDir + viewDir);
			fixed diff = max(0, dot(lightDir, s.Normal));
			fixed norhalf = max(0, dot(s.Normal, halfVector));
			fixed spec = pow(norhalf, _SpecPower) * _SpecularColor;
			fixed4 c;
			c.rgb = (s.Albedo * _LightColor0.rgb * diff) + (_LightColor0.rgb * spec * _SpecularColor) * etten * 2;
			c.a = s.Alpha;
			return c;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
