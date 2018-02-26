Shader "hidden/preview"
{
    Properties
    {
        [NoScaleOffset] Texture_8872AB52("Texture", 2D) = "white" {}
        Vector1_E277A997("Tiling Scale", Float) = 1
        [Toggle] Boolean_42DB9499("Use Adaptive Tiling", Float) = 1
    }
    HLSLINCLUDE
    #define USE_LEGACY_UNITY_MATRIX_VARIABLES
    #include "CoreRP/ShaderLibrary/Common.hlsl"
    #include "CoreRP/ShaderLibrary/Packing.hlsl"
    #include "CoreRP/ShaderLibrary/Color.hlsl"
    #include "CoreRP/ShaderLibrary/UnityInstancing.hlsl"
    #include "CoreRP/ShaderLibrary/EntityLighting.hlsl"
    #include "ShaderGraphLibrary/ShaderVariables.hlsl"
    #include "ShaderGraphLibrary/ShaderVariablesFunctions.hlsl"
    #include "ShaderGraphLibrary/Functions.hlsl"
    float Vector1_6E7935BD;
    TEXTURE2D(Texture_8872AB52); SAMPLER(samplerTexture_8872AB52);
    float Vector1_E277A997;
    float Boolean_42DB9499;
    float4 Vector2_F39967C6;
    float Vector1_7CECB7DD;
    float4 _TilingAndOffset_59F05D81_UV;
    SAMPLER(SamplerState_Point_Repeat_sampler);
    struct SurfaceInputs{
    	half4 uv0;
    };

    void Unity_Multiply_float3(float3 A, float3 B, out float3 Out)
    {
        Out = A * B;
    }

    void Unity_Branch_float2(float Predicate, float2 True, float2 False, out float2 Out)
    {
        Out = (Predicate * True) + abs((Predicate - 1) * False);
    }

    void Unity_TilingAndOffset_float(float2 UV, float2 Tiling, float2 Offset, out float2 Out)
    {
        Out = UV * Tiling + Offset;
    }
    struct GraphVertexInput
    {
    	float4 vertex : POSITION;
    	float3 normal : NORMAL;
    	float4 tangent : TANGENT;
    	float4 texcoord0 : TEXCOORD0;
    	UNITY_VERTEX_INPUT_INSTANCE_ID
    };
    struct SurfaceDescription{
    	float4 PreviewOutput;
    };
    GraphVertexInput PopulateVertexData(GraphVertexInput v){
    	return v;
    }
    SurfaceDescription PopulateSurfaceData(SurfaceInputs IN) {
    	SurfaceDescription surface = (SurfaceDescription)0;
    	float _Property_5DDC9544_Out = Boolean_42DB9499;
    	float _Property_7375FA0B_Out = Vector1_E277A997;
    	float3 _Multiply_31562833_Out;
    	Unity_Multiply_float3(float3(length(float3(unity_ObjectToWorld[0].x, unity_ObjectToWorld[1].x, unity_ObjectToWorld[2].x)),
    	                             length(float3(unity_ObjectToWorld[0].y, unity_ObjectToWorld[1].y, unity_ObjectToWorld[2].y)),
    	                             length(float3(unity_ObjectToWorld[0].z, unity_ObjectToWorld[1].z, unity_ObjectToWorld[2].z))), (_Property_7375FA0B_Out.xxx), _Multiply_31562833_Out);
    	if (Vector1_6E7935BD == 7) { surface.PreviewOutput = half4(_Multiply_31562833_Out.x, _Multiply_31562833_Out.y, _Multiply_31562833_Out.z, 1.0); return surface; }
    	float _Split_D2F64430_R = _Multiply_31562833_Out[0];
    	float _Split_D2F64430_G = _Multiply_31562833_Out[1];
    	float _Split_D2F64430_B = _Multiply_31562833_Out[2];
    	float _Split_D2F64430_A = 0;
    	float2 _Branch_BE015F33_Out;
    	Unity_Branch_float2(_Property_5DDC9544_Out, (_Split_D2F64430_R.xx), Vector2_F39967C6, _Branch_BE015F33_Out);
    	if (Vector1_6E7935BD == 12) { surface.PreviewOutput = half4(_Branch_BE015F33_Out.x, _Branch_BE015F33_Out.y, 0.0, 1.0); return surface; }
    	float3 _Multiply_827D9ABC_Out;
    	Unity_Multiply_float3(unity_ObjectToWorld._m03_m13_m23, (Vector1_7CECB7DD.xxx), _Multiply_827D9ABC_Out);
    	if (Vector1_6E7935BD == 9) { surface.PreviewOutput = half4(_Multiply_827D9ABC_Out.x, _Multiply_827D9ABC_Out.y, _Multiply_827D9ABC_Out.z, 1.0); return surface; }
    	float2 _TilingAndOffset_59F05D81_Out;
    	Unity_TilingAndOffset_float(IN.uv0.xy, _Branch_BE015F33_Out, (_Multiply_827D9ABC_Out.xy), _TilingAndOffset_59F05D81_Out);
    	if (Vector1_6E7935BD == 3) { surface.PreviewOutput = half4(_TilingAndOffset_59F05D81_Out.x, _TilingAndOffset_59F05D81_Out.y, 0.0, 1.0); return surface; }
    	float4 _SampleTexture2D_FF791B92_RGBA = SAMPLE_TEXTURE2D(Texture_8872AB52, SamplerState_Point_Repeat_sampler, _TilingAndOffset_59F05D81_Out);
    	float _SampleTexture2D_FF791B92_R = _SampleTexture2D_FF791B92_RGBA.r;
    	float _SampleTexture2D_FF791B92_G = _SampleTexture2D_FF791B92_RGBA.g;
    	float _SampleTexture2D_FF791B92_B = _SampleTexture2D_FF791B92_RGBA.b;
    	float _SampleTexture2D_FF791B92_A = _SampleTexture2D_FF791B92_RGBA.a;
    	if (Vector1_6E7935BD == 1) { surface.PreviewOutput = half4(_SampleTexture2D_FF791B92_RGBA.x, _SampleTexture2D_FF791B92_RGBA.y, _SampleTexture2D_FF791B92_RGBA.z, 1.0); return surface; }
    	return surface;
    }
    ENDHLSL

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            struct GraphVertexOutput
            {
                float4 position : POSITION;
                half4 uv0 : TEXCOORD;

            };

            GraphVertexOutput vert (GraphVertexInput v)
            {
                v = PopulateVertexData(v);

                GraphVertexOutput o;
                float3 positionWS = TransformObjectToWorld(v.vertex);
                o.position = TransformWorldToHClip(positionWS);
                o.uv0 = v.texcoord0;

                return o;
            }

            float4 frag (GraphVertexOutput IN) : SV_Target
            {
                float4 uv0 = IN.uv0;


                SurfaceInputs surfaceInput = (SurfaceInputs)0;;
                surfaceInput.uv0 = uv0;


                SurfaceDescription surf = PopulateSurfaceData(surfaceInput);
                return surf.PreviewOutput;

            }
            ENDHLSL
        }
    }
}
