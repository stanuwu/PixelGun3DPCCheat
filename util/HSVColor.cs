using System;
using UnityEngine;

namespace PixelGunCheat.util
{
    public class HSVColor
    {
        public HSVColor(float hue, float saturation, float value)
        {
            Hue = hue;
            Saturation = saturation;
            Value = value;
        }
        
        public float Hue { get; set; }
        public float Saturation { get; set; }
        public float Value { get; set; }

        public static HSVColor FromRGB(float r, float g, float b)
        {
            Color.RGBToHSV(new Color(r, g, b, 1), out float h, out float s, out float v);
            return new HSVColor(h * 360, s, v);
        }
        
        public Color AsARGB(float alpha)
        {
            float hue = Hue / 360;
            float R = 0;
            float G = 0;
            float B = 0;
            if ( Saturation == 0 )
            {
                R = Value;
                G = Value;
                B = Value;
            }
            else
            {
                float var_r = 0;
                float var_g = 0;
                float var_b = 0;
                float var_h = hue * 6;
                if (var_h == 6) var_h = 0;
                float var_i = (int)var_h;
                float var_1 = Value * (1 - Saturation);
                float var_2 = Value * (1 - Saturation * (var_h - var_i));
                float var_3 = Value * (1 - Saturation * (1 - (var_h - var_i)));

                if ( var_i == 0 ) { 
                    var_r = Value; 
                    var_g = var_3;
                    var_b = var_1;
                }
                else if ( var_i == 1 ) { 
                    var_r = var_2;
                    var_g = Value;
                    var_b = var_1;
                }
                else if ( var_i == 2 ) { 
                    var_r = var_1;
                    var_g = Value;
                    var_b = var_3;
                }
                else if ( var_i == 3 ) {
                    var_r = var_1;
                    var_g = var_2;
                    var_b = Value;
                }
                else if ( var_i == 4 ) {
                    var_r = var_3;
                    var_g = var_1;
                    var_b = Value;
                }
                else { 
                    var_r = Value;
                    var_g = var_1 ;
                    var_b = var_2;
                }

                R = var_r;
                G = var_g;
                B = var_b;
            }

            return new Color(R, G, B, alpha);
        }
    }
}