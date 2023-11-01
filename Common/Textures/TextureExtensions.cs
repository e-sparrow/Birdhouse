using System;
using Birdhouse.Common.Textures.Enums;
using UnityEngine;

namespace Birdhouse.Common.Textures
{
    public static class TextureExtensions
    {
        public static byte[] EncodeTo(this Texture2D self, ETextureEncodingType type)
        {
            switch (type)
            {
                case ETextureEncodingType.PNG:
                    return self.EncodeToPNG();
                
                case ETextureEncodingType.JPG:
                    return self.EncodeToJPG();
                    
                case ETextureEncodingType.EXR:
                    return self.EncodeToEXR();
                
                case ETextureEncodingType.TGA:
                    return self.EncodeToTGA();
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}