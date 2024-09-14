Shader "Sprites/CustomColorShader"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        [HideInInspector] _RendererColor ("RendererColor", Color) = (1,1,1,1)
        [HideInInspector] _Flip ("Flip", Vector) = (1,1,1,1)
        [PerRendererData] _AlphaTex ("External Alpha", 2D) = "white" {}
        [PerRendererData] _EnableExternalAlpha ("Enable External Alpha", Float) = 0

        _ColorToReplace1 ("Color to Replace 1", Color) = (0.5, 0.5, 0.5, 1)
        _ColorToReplace2 ("Color to Replace 2", Color) = (0.5, 0.5, 0.5, 1)
        _ColorToReplace3 ("Color to Replace 3", Color) = (0.5, 0.5, 0.5, 1)
        _ColorToReplace4 ("Color to Replace 4", Color) = (0.5, 0.5, 0.5, 1)
        _ReplacementColor1 ("Replacement Color 1", Color) = (1, 0, 0, 1)
        _ReplacementColor2 ("Replacement Color 2", Color) = (0, 1, 0, 1)
        _ReplacementColor3 ("Replacement Color 3", Color) = (0, 0, 1, 1)
        _ReplacementColor4 ("Replacement Color 4", Color) = (1, 1, 0, 1)
        _Tolerance ("Tolerance", Range(0, 1)) = 0.1
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        Blend One OneMinusSrcAlpha

        Pass
        {
        CGPROGRAM
            #pragma vertex SpriteVert
            #pragma fragment SpriteFragCustom
            #pragma target 2.0
            #pragma multi_compile_instancing
            #pragma multi_compile_local _ PIXELSNAP_ON
            #pragma multi_compile _ ETC1_EXTERNAL_ALPHA
            #include "UnitySprites.cginc"

            // Declaram variabilele pentru culorile de înlocuit și cele de înlocuire
            float4 _ColorToReplace1;
            float4 _ColorToReplace2;
            float4 _ColorToReplace3;
            float4 _ColorToReplace4;
            float4 _ReplacementColor1;
            float4 _ReplacementColor2;
            float4 _ReplacementColor3;
            float4 _ReplacementColor4;
            float _Tolerance;

            // Modificăm fragment shader-ul să includă înlocuirea de culori
            fixed4 SpriteFragCustom(v2f IN) : SV_Target
            {
                fixed4 texColor = tex2D(_MainTex, IN.texcoord) * IN.color;

                float dist;

                // Verificăm prima culoare
                dist = distance(texColor.rgb, _ColorToReplace1.rgb);
                if (dist < _Tolerance)
                {
                    return _ReplacementColor1 * texColor.a;
                }

                // Verificăm a doua culoare
                dist = distance(texColor.rgb, _ColorToReplace2.rgb);
                if (dist < _Tolerance)
                {
                    return _ReplacementColor2 * texColor.a;
                }

                // Verificăm a treia culoare
                dist = distance(texColor.rgb, _ColorToReplace3.rgb);
                if (dist < _Tolerance)
                {
                    return _ReplacementColor3 * texColor.a;
                }

                // Verificăm a patra culoare
                dist = distance(texColor.rgb, _ColorToReplace4.rgb);
                if (dist < _Tolerance)
                {
                    return _ReplacementColor4 * texColor.a;
                }

                // Returnează culoarea originală dacă nu se face nicio înlocuire
                return texColor;
            }
        ENDCG
        }
    }
}